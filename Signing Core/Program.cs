using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.IO;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Security;
using System.Collections;
using Org.BouncyCastle.Crypto.Parameters;

namespace Signing_Core
{
    class Program
    {
        private static string pfxFile = @".pfx";
        private static string pwd = "";
        private static string inputFile = @"Xem phim Hồn Ma và Cá Voi Tập 1-End server R.PRO.mp4";
        private static string inputXmlFile = "data/books.xml";
        private static string encryptedXmlFile = "data/books_enc.xml";
        private static string decryptedXmlFile = "data/books_dec.xml";
        private static string signedFile = @"signed-stream.cms";
        private static string encryptedFile = @"encrypted-stream.cms";
        private static string decryptedFile = @"decrypted-stream.cms";

        static void Main(string[] args)
        {
            BouncyCastle_SignCMS(inputFile, signedFile);
            bool res = BouncyCastle_VerifyCMS(inputFile, signedFile);

            BouncyCastle_EncryptCMS_Asym(inputFile, encryptedFile);
            BouncyCastle_DecryptCMS_Asym(encryptedFile, decryptedFile);

            byte[] aesKey = Helper.GenerateAesKey(192);
            BouncyCastle_EncryptCMS_Key(inputFile, encryptedFile, aesKey);
            BouncyCastle_DecryptCMS_Key(encryptedFile, decryptedFile, aesKey);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = aesKey;
                aesAlg.Mode = CipherMode.CBC;
                XmlDocument inputXmlDoc = new XmlDocument();
                inputXmlDoc.Load(inputXmlFile);
                Microsoft_EncryptXML_Sym(inputXmlDoc, new List<string>() { "author" }, aesAlg);

                XmlDocument encryptedXmlDoc = new XmlDocument();
                encryptedXmlDoc.Load(encryptedXmlFile);
                Microsoft_DecryptXML_Sym(encryptedXmlDoc, aesAlg);

            }
        }

        public static void Microsoft_SignXml(XmlDocument xmlDoc, RSA rsaKey)
        {
            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException(nameof(xmlDoc));
            if (rsaKey == null)
                throw new ArgumentException(nameof(rsaKey));

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(xmlDoc);

            // Add the key to the SignedXml document.
            signedXml.SigningKey = rsaKey;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
        }

        public static Boolean Microsoft_VerifyXml(XmlDocument xmlDoc, RSA key)
        {
            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException("xmlDoc");
            if (key == null)
                throw new ArgumentException("key");

            // Create a new SignedXml object and pass it
            // the XML document class.
            SignedXml signedXml = new SignedXml(xmlDoc);

            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Signature");

            // Throw an exception if no signature was found.
            if (nodeList.Count <= 0)
            {
                throw new CryptographicException("Verification failed: No Signature was found in the document.");
            }

            // This example only supports one signature for
            // the entire XML document.  Throw an exception
            // if more than one signature was found.
            if (nodeList.Count >= 2)
            {
                throw new CryptographicException("Verification failed: More that one signature was found for the document.");
            }

            // Load the first <signature> node.
            signedXml.LoadXml((XmlElement)nodeList[0]);

            // Check the signature and return the result.
            return signedXml.CheckSignature(key);
        }

        public static void BouncyCastle_SignCMS(string originalFile, string signedFile)
        {
            AsymmetricKeyParameter privateKey = null;
            X509Certificate bouncycastle_cert = null;
            var pkcs12Store = new Pkcs12Store();

            using (FileStream keyStream = new FileStream(pfxFile, FileMode.Open, FileAccess.Read))
            using (FileStream signedStream = new FileStream(signedFile, mode: FileMode.Create, access: FileAccess.Write))
            using (FileStream originDataStream = new FileStream(originalFile, FileMode.Open, access: FileAccess.Read))
            {
                var inputKeyStore = new Pkcs12Store();
                inputKeyStore.Load(keyStream, pwd.ToCharArray());
                var keyAlias = inputKeyStore.Aliases.Cast<string>().FirstOrDefault(n => inputKeyStore.IsKeyEntry(n));
                privateKey = inputKeyStore.GetKey(keyAlias).Key;
                bouncycastle_cert = inputKeyStore.GetCertificate(keyAlias).Certificate;

                CmsSignedDataStreamGenerator gen = new CmsSignedDataStreamGenerator();
                // add one signer
                gen.AddSigner(privateKey: privateKey, cert: bouncycastle_cert, CmsSignedDataGenerator.DigestSha256);

                using (Stream signingStream = gen.Open(signedStream))
                {
                    // sign
                    originDataStream.CopyTo(signingStream);
                }
            }
        }

        public static bool BouncyCastle_VerifyCMS(string dataFile, string signedFile)
        {
            bool result = false;

            try
            {
                byte[] digest = null;
                System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert = null;// GetMicrosoftCert();
                X509Certificate bouncycastle_cert = null;// DotNetUtilities.FromX509Certificate(microsoftCert);
                AsymmetricKeyParameter publicKey = null;// bouncycastle_cert.GetPublicKey();

                using (FileStream dataStream = new FileStream(dataFile, FileMode.Open))
                {
                    SHA256 mySHA256 = SHA256Managed.Create();
                    digest = mySHA256.ComputeHash(dataStream);
                    dataStream.Close();
                }

                using (FileStream sigStream = new FileStream(signedFile, mode: FileMode.Open, access: FileAccess.Read))
                using (FileStream dataStream = new FileStream(dataFile, mode: FileMode.Open, access: FileAccess.Read))
                {
                    CmsTypedStream cmsDataTypedStream = null;
                    CmsSignedDataParser cmsSignedDataParser = null;

                    cmsDataTypedStream = new CmsTypedStream(dataStream);
                    cmsSignedDataParser = new CmsSignedDataParser(cmsDataTypedStream, sigStream);
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
                            microsoftCert = Helper.GetMicrosoftCert();
                            bouncycastle_cert = DotNetUtilities.FromX509Certificate(microsoftCert);
                            publicKey = bouncycastle_cert.GetPublicKey();

                            if (signer.Verify(publicKey))
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
                                }
                            }
                            else
                            {
                                // decrypt signature fail
                            }
                        }
                        else
                        {
                            // not found any signers
                        }
                    }
                    else
                    {
                        // not found any signer infos
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

            using (var pfxStream = new FileStream(pfxFile, FileMode.Open, FileAccess.Read))
            {
                Pkcs12Store inputKeyStore = new Pkcs12Store();
                inputKeyStore.Load(pfxStream, pwd.ToCharArray());
                string keyAlias = inputKeyStore.Aliases.Cast<string>().FirstOrDefault(n => inputKeyStore.IsKeyEntry(n));
                privateKey = inputKeyStore.GetKey(keyAlias).Key;

                using (FileStream cipherFileStream = new FileStream(cipherFilePath, mode: FileMode.Open))
                {
                    cmsCipherData = new CmsEnvelopedData(cipherFileStream);
                    RecipientInformationStore recipientInformationStore = cmsCipherData.GetRecipientInfos();
                    RecipientID recipientID = new RecipientID()
                    {
                        SerialNumber = inputKeyStore.GetCertificate(keyAlias).Certificate.SerialNumber,
                        Issuer = inputKeyStore.GetCertificate(keyAlias).Certificate.IssuerDN
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

        public static void BouncyCastle_EncryptCMS_Key(string rawFilePath, string cipherFilePath, byte[] aesKeyRaw)
        {
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
                if      (aesKeySize == 128) aesModeString = CmsEnvelopedDataGenerator.Aes128Cbc;
                else if (aesKeySize == 192) aesModeString = CmsEnvelopedDataGenerator.Aes192Cbc;
                else if (aesKeySize == 256) aesModeString = CmsEnvelopedDataGenerator.Aes256Cbc;

                // encrypt
                Stream encryptingStream = cmsEnvelopedDataStreamGenerator.Open(encryptedStream, aesModeString);
                originalDataStream.CopyTo(encryptingStream);
                encryptingStream.Close();
            }
        }

        public static void BouncyCastle_DecryptCMS_Key(string cipherFilePath, string decryptedFilePath, byte[] aesKeyRaw)
        {
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

        public static void Microsoft_EncryptXML_Sym(XmlDocument Doc, List<string> ElementNames, SymmetricAlgorithm symAlgo)
        {
            EncryptedXml xmlEncryptor = new EncryptedXml();
            List<Tuple<XmlElement, EncryptedData>> targetReplace = new List<Tuple<XmlElement, EncryptedData>>();

            foreach (string ElementName in ElementNames)
            {
                XmlNodeList xmlNodeList = Doc.GetElementsByTagName(ElementName);
                if (xmlNodeList != null && xmlNodeList.Count > 0)
                {
                    // found target elem list

                    foreach (XmlNode xmlNode in xmlNodeList)
                    {
                        XmlElement elementToEncrypt = xmlNode as XmlElement;
                        EncryptedData encryptDataElem = Helper.EncryptXmlElement(xmlEncryptor, elementToEncrypt, symAlgo);
                        if (encryptDataElem != null)
                        {
                            targetReplace.Add(Tuple.Create(elementToEncrypt, encryptDataElem));
                        }
                    }

                    foreach(var t in targetReplace)
                    {
                        // replace elem
                        EncryptedXml.ReplaceElement(t.Item1, t.Item2, false);
                    }
                }
                else
                {
                    // not found any node from element name
                }
            }
            Doc.Save(encryptedXmlFile);
        }

        public static void Microsoft_DecryptXML_Sym(XmlDocument Doc, SymmetricAlgorithm Alg)
        {
            EncryptedXml xmlEncryptor = new EncryptedXml();
            List<Tuple<XmlElement, byte[]>> targetReplace = new List<Tuple<XmlElement, byte[]>>();
            XmlNodeList xmlNodeList = Doc.GetElementsByTagName("EncryptedData");

            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // found elems

                foreach (XmlElement xmlElement in xmlNodeList)
                {
                    XmlElement encryptedElement = xmlElement as XmlElement;
                    byte[] decryptedData = Helper.DecryptXmlElement(xmlEncryptor, encryptedElement, Alg);
                    if (decryptedData != null && decryptedData.Length > 0)
                    {
                        targetReplace.Add(Tuple.Create(encryptedElement, decryptedData));
                    }
                }

                foreach(var t in targetReplace)
                {
                    // replace elem
                    xmlEncryptor.ReplaceData(t.Item1, t.Item2);
                }
            }
            else
            {
                // not found any elem names
            }

            Doc.Save(decryptedXmlFile);
        }
    }
}
