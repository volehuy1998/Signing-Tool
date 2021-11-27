using SigningCore;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SigningCore
{
    public class Cms
    {
        public static void BouncyCastle_SignCMS(string originalFile, string signedFile, string pfxPath, string pfxPassword)
        {
            if (Common.CheckString(originalFile))
                throw new Exception("File to sign null");
            if (Common.CheckString(originalFile))
                throw new Exception("File to output sign null");
            if (Common.CheckString(pfxPath))
                throw new Exception("Pfx file null");
            if (Common.CheckString(originalFile))
                throw new Exception("Pfx password null");

            AsymmetricKeyParameter privateKey = null;
            X509Certificate bouncycastle_cert = null;

            using (FileStream signedStream = new FileStream(signedFile, mode: FileMode.Create, access: FileAccess.Write))
            using (FileStream originDataStream = new FileStream(originalFile, FileMode.Open, access: FileAccess.Read))
            {
                var pkcs12Store = Helper.GetPkcs12Store(pfxPath, pfxPassword);
                var keyAlias = Helper.GetAliasFromPkcs12Store(pkcs12Store);
                privateKey = pkcs12Store.GetKey(keyAlias).Key;
                bouncycastle_cert = pkcs12Store.GetCertificate(keyAlias).Certificate;

                CmsSignedDataStreamGenerator gen = new CmsSignedDataStreamGenerator();
                // add one signer
                gen.AddSigner(privateKey: privateKey, cert: bouncycastle_cert, CmsSignedDataGenerator.DigestSha256);

                using (Stream signingStream = gen.Open(signedStream, true))
                {
                    // sign
                    originDataStream.CopyTo(signingStream);
                }
            }
        }

        public static bool BouncyCastle_VerifyCMS(string signedFile, X509Certificate bouncycastleCert)
        {
            if (Common.CheckString(signedFile))
                throw new Exception("Signed file to output verify null");
            if (bouncycastleCert == null)
                throw new Exception("Bouncy cert to verify null");

            bool result = false;
            byte[] digest = null;

            using (FileStream sigStream = new FileStream(signedFile, mode: FileMode.Open, access: FileAccess.Read))
            {
                CmsTypedStream cmsDataTypedStream = null;
                CmsSignedDataParser cmsSignedDataParser = null;

                cmsSignedDataParser = new CmsSignedDataParser(File.ReadAllBytes(signedFile));
                cmsDataTypedStream = cmsSignedDataParser.GetSignedContent();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    cmsDataTypedStream.ContentStream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    SHA256 mySHA256 = SHA256Managed.Create();
                    digest = mySHA256.ComputeHash(memoryStream);
                    memoryStream.Close();
                }

                cmsSignedDataParser.GetSignedContent().Drain();

                SignerInformationStore signerInfos = cmsSignedDataParser.GetSignerInfos();
                if (signerInfos != null && signerInfos.Count > 0)
                {
                    // get signer infos ok

                    List<SignerInformation> signers = signerInfos.GetSigners()?.Cast<SignerInformation>()?.ToList();
                    if (signers != null && signers.Count > 0)
                    {
                        // get signers ok

                        // verify one signer
                        SignerInformation signer = signers.FirstOrDefault();
                        if (signer.Verify(bouncycastleCert))
                        {
                            // signature ok

                            byte[] expectedDigest = signer.GetContentDigest();
                            if (Org.BouncyCastle.Utilities.Arrays.AreEqual(digest, expectedDigest))
                            {
                                // data ok
                                result = true;
                            }
                            else
                            {
                                // fake data
                                throw new Exception("Verify data fail");
                            }
                        }
                        else
                        {
                            // decrypt signature fail
                            throw new Exception("Verify signature fail");
                        }
                    }
                    else
                    {
                        // not found any signers
                        throw new Exception("Not found any signer");
                    }
                }
                else
                {
                    // not found any signer infos
                    throw new Exception("Not found any signer");
                }
            }

            return result;
        }

        public static void BouncyCastle_EncryptCMS_Asym(string rawFilePath, string cipherFilePath)
        {
            CmsEnvelopedDataStreamGenerator cmsEnvelopedDataStreamGenerator = new CmsEnvelopedDataStreamGenerator();
            System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert = Helper.GetMicrosoftCert();
            X509Certificate bouncycastle_cert = DotNetUtilities.FromX509Certificate(microsoftCert);
            MemoryStream encryptedStream = new MemoryStream();
            Stream encryptingStream = null;

            cmsEnvelopedDataStreamGenerator.AddKeyTransRecipient(bouncycastle_cert);
            encryptingStream = cmsEnvelopedDataStreamGenerator.Open(encryptedStream, CmsEnvelopedDataGenerator.Aes128Cbc);
            using (FileStream originDataStream = new FileStream(path: rawFilePath, mode: FileMode.OpenOrCreate))
            {
                originDataStream.CopyTo(encryptingStream);
            }
            encryptingStream.Close();
            File.WriteAllBytes(path: cipherFilePath, encryptedStream.ToArray());
        }

        public static void BouncyCastle_DecryptCMS_Asym(string cipherFilePath, string decryptedFilePath)
        {
            CmsEnvelopedData cmsCipherData = null;
            AsymmetricKeyParameter privateKey = null;

            using (var pfxStream = new FileStream(Common.PfxFile, FileMode.Open, FileAccess.Read))
            {
                Pkcs12Store pkcs12Store = Helper.GetPkcs12Store(Common.PfxFile, Common.PfxPwd);
                string keyAlias = Helper.GetAliasFromPkcs12Store(pkcs12Store);
                privateKey = pkcs12Store.GetKey(keyAlias).Key;

                using (FileStream cipherFileStream = new FileStream(cipherFilePath, mode: FileMode.Open))
                {
                    cmsCipherData = new CmsEnvelopedData(cipherFileStream);
                    RecipientInformationStore recipientInformationStore = cmsCipherData.GetRecipientInfos();
                    RecipientID recipientID = new RecipientID()
                    {
                        SerialNumber = pkcs12Store.GetCertificate(keyAlias).Certificate.SerialNumber,
                        Issuer = pkcs12Store.GetCertificate(keyAlias).Certificate.IssuerDN
                    };

                    RecipientInformation recipientInformation = recipientInformationStore.GetFirstRecipient(recipientID);
                    CmsTypedStream decryptingStream = recipientInformation.GetContentStream(privateKey);

                    using (FileStream decryptedStream = new FileStream(decryptedFilePath, mode: FileMode.OpenOrCreate))
                    {
                        decryptingStream.ContentStream.CopyTo(decryptedStream);
                        decryptingStream.ContentStream.Close();
                    }
                }
            }
        }

        public static void BouncyCastle_EncryptCMS_Sym(string rawFilePath, string cipherFilePath, byte[] aesKeyRaw)
        {
            if (Common.CheckString(rawFilePath))
                throw new Exception("Data file to encrypt null");
            if (Common.CheckString(cipherFilePath))
                throw new Exception("Cipher file to output encrypt null");
            if (aesKeyRaw == null)
                throw new Exception("Aes key to encrypt null");

            KeyParameter aesKey = ParameterUtilities.CreateKeyParameter("AES", aesKeyRaw);
            byte[] kekId = new byte[] { 1, 2, 3, 4, 5 };
            int aesKeySize = aesKeyRaw.Length * 8;
            CmsEnvelopedDataStreamGenerator cmsEnvelopedDataStreamGenerator = new CmsEnvelopedDataStreamGenerator();
            cmsEnvelopedDataStreamGenerator.AddKekRecipient($"AES{aesKeySize}", aesKey, kekId);

            using (FileStream originalDataStream = new FileStream(rawFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream encryptedStream = new FileStream(cipherFilePath, FileMode.Create, FileAccess.Write))
            {
                // get aes mode
                string aesModeString = null;
                if (aesKeySize == 128) aesModeString = CmsEnvelopedDataGenerator.Aes128Cbc;
                else if (aesKeySize == 192) aesModeString = CmsEnvelopedDataGenerator.Aes192Cbc;
                else if (aesKeySize == 256) aesModeString = CmsEnvelopedDataGenerator.Aes256Cbc;
                else throw new Exception("Not support this algo encrypt yet");

                // encrypt
                Stream encryptingStream = cmsEnvelopedDataStreamGenerator.Open(encryptedStream, aesModeString);
                originalDataStream.CopyTo(encryptingStream);
                encryptingStream.Close();
            }
        }

        public static void BouncyCastle_DecryptCMS_Sym(string cipherFilePath, string decryptedFilePath, byte[] aesKeyRaw)
        {
            if (Common.CheckString(cipherFilePath))
                throw new Exception("Cipher file to decrypt null");
            if (Common.CheckString(decryptedFilePath))
                throw new Exception("Decrypt file to output decrypt null");
            if (aesKeyRaw == null)
                throw new Exception("Aes key to decrypt null");

            KeyParameter aesKey = ParameterUtilities.CreateKeyParameter("AES", aesKeyRaw);

            using (FileStream cipherStream = new FileStream(cipherFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream decryptedStream = new FileStream(decryptedFilePath, FileMode.Create, FileAccess.Write))
            {
                // import cipher
                CmsEnvelopedDataParser cmsEnvelopedDataParser = new CmsEnvelopedDataParser(cipherStream);
                RecipientInformationStore recipientInformationStore = cmsEnvelopedDataParser.GetRecipientInfos();

                ICollection recipients = recipientInformationStore.GetRecipients();
                foreach (RecipientInformation recipient in recipients)
                {
                    // decrypt
                    CmsTypedStream decryptingStream = recipient.GetContentStream(aesKey);

                    decryptingStream.ContentStream.CopyTo(decryptedStream);
                    decryptingStream.ContentStream.Close();
                }
            }
        }
    }
}
