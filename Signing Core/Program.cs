﻿using System;
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
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Asn1.X509;

namespace Signing_Core
{
    class Program
    {
        private static string pfxFile = @".pfx";
        private static string pwd = "";
        private static string inputFile = @"Xem phim Hồn Ma và Cá Voi Tập 1-End server R.PRO.mp4";
        private static string signedFile = @"signed-stream.cms";
        private static string encryptedFile = @"encrypted-stream.cms";
        private static string decryptedFile = @"decrypted-stream.cms";

        static void Main(string[] args)
        {
            BouncyCastle_signCMS(inputFile, signedFile);
            bool res = BouncyCastle_VerifyCMS(inputFile, signedFile);

            BouncyCastle_EncryptCMS(inputFile, encryptedFile);
            BouncyCastle_DecryptCMS(encryptedFile, decryptedFile);
        }

        public static void MicrosoftSignXml(XmlDocument xmlDoc, RSA rsaKey)
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

        public static Boolean MicrosoftVerifyXml(XmlDocument xmlDoc, RSA key)
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

        public static void BouncyCastle_signCMS(string originalFile, string signedFile)
        {
            var pkcs12Store = new Pkcs12Store();
            using (var keyStream = new FileStream(pfxFile, FileMode.Open, FileAccess.Read))
            {
                var inputKeyStore = new Pkcs12Store();
                inputKeyStore.Load(keyStream, pwd.ToCharArray());
                var keyAlias = inputKeyStore.Aliases.Cast<string>().FirstOrDefault(n => inputKeyStore.IsKeyEntry(n));
                AsymmetricKeyParameter priKey = inputKeyStore.GetKey(keyAlias).Key;
                X509Certificate bcCert = inputKeyStore.GetCertificate(keyAlias).Certificate;

                CmsSignedDataStreamGenerator gen = new CmsSignedDataStreamGenerator();
                gen.AddSigner(privateKey: priKey, cert: bcCert, CmsSignedDataGenerator.DigestSha256);

                MemoryStream bOut = new MemoryStream();
                Stream signing = gen.Open(bOut, true);
                using (FileStream originDataStream = new FileStream(originalFile, FileMode.OpenOrCreate))
                {
                    originDataStream.CopyTo(signing);
                }
                signing.Close();
                File.WriteAllBytes(signedFile, bOut.ToArray());
            }
        }

        public static bool BouncyCastle_VerifyCMS(string dataFile, string signedDataFile)
        {
            bool result = false;

            try
            {
                byte[] digestFromReceivedData = new byte[32];
                byte[] signedData = null;
                System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert = null;// GetMicrosoftCert();
                X509Certificate bcCert = null;// DotNetUtilities.FromX509Certificate(microsoftCert);
                AsymmetricKeyParameter publicKey = null;// bcCert.GetPublicKey();

                signedData = File.ReadAllBytes(signedDataFile);
                CmsSignedData cmsSignedData = new CmsSignedData(signedData);
                SignerInformationStore signers = cmsSignedData.GetSignerInfos();
                ICollection c = signers.GetSigners();
                foreach (SignerInformation signer in c)
                {
                    microsoftCert = GetMicrosoftCert();
                    bcCert = DotNetUtilities.FromX509Certificate(microsoftCert);
                    publicKey = bcCert.GetPublicKey();
                    if (signer.Verify(bcCert))
                    //if (signer.Verify(publicKey))
                    {
                        // decrypt signature ok

                        // get digest from signature
                        byte[] digestFromSignature = signer.GetContentDigest();

                        // get digest from received data
                        byte[] receivedData = File.ReadAllBytes(dataFile);
                        Org.BouncyCastle.Crypto.Digests.GeneralDigest sha256 = new Org.BouncyCastle.Crypto.Digests.Sha256Digest();
                        sha256.BlockUpdate(receivedData, 0, receivedData.Length);
                        int w = sha256.DoFinal(digestFromReceivedData, 0);

                        result = digestFromSignature.SequenceEqual(digestFromReceivedData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        public static System.Security.Cryptography.X509Certificates.X509Certificate2 GetMicrosoftCert()
        {
            System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert = null;

            System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store("MY", System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);
            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly | System.Security.Cryptography.X509Certificates.OpenFlags.OpenExistingOnly);
            System.Security.Cryptography.X509Certificates.X509Certificate2Collection collection = store.Certificates;

            System.Security.Cryptography.X509Certificates.X509Certificate2Collection certs = System.Security.Cryptography.X509Certificates.X509Certificate2UI.SelectFromCollection(
                collection, "Select", "Select a certificate to sign",
                System.Security.Cryptography.X509Certificates.X509SelectionFlag.MultiSelection);

            if (certs != null && certs.Count >= 1)
            {
                microsoftCert = certs[0];
            }

            return microsoftCert;
        }

        public static void BouncyCastle_EncryptCMS(string rawFilePath, string cipherFilePath)
        {
            CmsEnvelopedDataStreamGenerator cmsEnvelopedDataStreamGenerator = new CmsEnvelopedDataStreamGenerator();
            System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert = GetMicrosoftCert();
            X509Certificate bcCert = DotNetUtilities.FromX509Certificate(microsoftCert);
            MemoryStream encryptedStream = new MemoryStream();
            Stream encryptingStream = null;

            cmsEnvelopedDataStreamGenerator.AddKeyTransRecipient(bcCert);
            encryptingStream = cmsEnvelopedDataStreamGenerator.Open(encryptedStream, CmsEnvelopedDataGenerator.Aes128Cbc);
            using (FileStream originDataStream = new FileStream(path: rawFilePath, mode: FileMode.OpenOrCreate))
            {
                originDataStream.CopyTo(encryptingStream);
            }
            encryptingStream.Close();
            File.WriteAllBytes(path: cipherFilePath, encryptedStream.ToArray());
        }

        public static void BouncyCastle_DecryptCMS(string cipherFilePath, string decryptedFilePath)
        {
            using (var pfxStream = new FileStream(pfxFile, FileMode.Open, FileAccess.Read))
            {
                var inputKeyStore = new Pkcs12Store();
                inputKeyStore.Load(pfxStream, pwd.ToCharArray());
                var keyAlias = inputKeyStore.Aliases.Cast<string>().FirstOrDefault(n => inputKeyStore.IsKeyEntry(n));
                AsymmetricKeyParameter priKey = inputKeyStore.GetKey(keyAlias).Key;

                CmsEnvelopedData cmsEnvelopedData = null;

                using (FileStream cipherFileStream = new FileStream(cipherFilePath, mode: FileMode.Open))
                {
                    cmsEnvelopedData = new CmsEnvelopedData(cipherFileStream);
                    RecipientInformationStore recipientInformationStore = cmsEnvelopedData.GetRecipientInfos();
                    RecipientID recipientID = new RecipientID()
                    {
                        SerialNumber = inputKeyStore.GetCertificate(keyAlias).Certificate.SerialNumber,
                        Issuer = inputKeyStore.GetCertificate(keyAlias).Certificate.IssuerDN
                    };

                    RecipientInformation recipientInformation = recipientInformationStore.GetFirstRecipient(recipientID);
                    CmsTypedStream cmsTypedStream = recipientInformation.GetContentStream(priKey);

                    using (FileStream decryptedStream = new FileStream(decryptedFilePath, mode: FileMode.OpenOrCreate))
                    {
                        cmsTypedStream.ContentStream.CopyTo(decryptedStream);
                        cmsTypedStream.ContentStream.Close();
                    }
                }
            }
        }
    }
}
