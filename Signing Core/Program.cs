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
using Org.BouncyCastle.Crypto.Engines;

namespace Signing_Core
{
    class Program
    {
        private static string pfxFile = @"C:\Users\voleh\OneDrive\Chữ ký số\Võ Lê Huy.pfx";
        private static string pwd = "Xiangyu98@";
        private static string inputFile = @"D:\Phim\Người anh họ độc ác.mp4";
        private static string outputFile = @"signed-stream.cms";
        private static string inputFile_fake = "data.txt";
        private static string inputFile_fake_wrong = "wrong_data.txt";

        static void Main(string[] args)
        {
            //try
            //{
            //    // Create a new CspParameters object to specify
            //    // a key container.
            //    CspParameters cspParams = new CspParameters();
            //    cspParams.KeyContainerName = "XML_DSIG_RSA_KEY";

            //    // Create a new RSA signing key and save it in the container.
            //    //RSACryptoServiceProvider.UseMachineKeyStore = true;
            //    RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);
            //     // Create a new XML document.
            //     XmlDocument xmlDoc = new XmlDocument();

            //    // Load an XML file into the XmlDocument object.
            //    xmlDoc.PreserveWhitespace = true;
            //    xmlDoc.Load("test.xml");

            //    // Sign the XML document.
            //    PureSignXml(xmlDoc, rsaKey);
            //    //bool res = PureVerifyXml(xmlDoc, rsaKey);

            //    //Console.WriteLine("XML file signed.");

            //    // Save the document.
            //    xmlDoc.Save("test_signed.xml");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            File.Delete(outputFile);
            signCMS(originalFile: inputFile_fake, outputSignatureFile: outputFile);
            if (verifyCMS(dataFile: inputFile_fake, signedDataFile: outputFile))
            {
                // verify ok
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Fail");
            }

            Console.ReadKey();
        }

        // Sign an XML file.
        // This document cannot be verified unless the verifying
        // code has the key with which it was signed.
        public static void PureSignXml(XmlDocument xmlDoc, RSA rsaKey)
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

        // Verify the signature of an XML file against an asymmetric
        // algorithm and return the result.
        public static Boolean PureVerifyXml(XmlDocument xmlDoc, RSA key)
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

        /*
         public byte[] sign(byte[] data) throws Exception {
            Security.addProvider(new org.bouncycastle.jce.provider.BouncyCastleProvider());
            KeyStore inStore = KeyStore.getInstance("PKCS12");
            inStore.load(new FileInputStream(packageZipConfiguration.pushPackageSignerCertPath), packageZipConfiguration.pushPackageSignerCertPassword.toCharArray());
            Key key = inStore.getKey(packageZipConfiguration.pushPackageSignerCertName, packageZipConfiguration.pushPackageSignerCertPassword.toCharArray());
            PrivateKey privateKey = RSAPrivateKeyImpl.parseKey(new DerValue(key.getEncoded()));
            Certificate certificate = inStore.getCertificate(packageZipConfiguration.pushPackageSignerCertName);
            X509CertificateHolder certificateHolder = new X509CertificateHolder(certificate.getEncoded());
            List certList = new ArrayList();
            //Data to sign
            CMSTypedData msg = new CMSProcessableByteArray(data);
            //Adding the X509 Certificate
            certList.add(certificateHolder);
            Store certs = new JcaCertStore(certList);
            CMSSignedDataGenerator gen = new CMSSignedDataGenerator();
            //Initializing the the BC's Signer
            ContentSigner sha1Signer = new JcaContentSignerBuilder("SHA1withRSA").setProvider("BC").build(privateKey);
            gen.addSignerInfoGenerator(new JcaSignerInfoGeneratorBuilder(new JcaDigestCalculatorProviderBuilder().setProvider("BC").build()).build(sha1Signer, certificateHolder));
            //adding the certificate
            gen.addCertificates(certs);
            //Getting the signed data
            CMSSignedData sigData = gen.generate(msg, false);
            return sigData.getEncoded();
        }
         */

        public static void signCMS(string originalFile, string outputSignatureFile)
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
                File.WriteAllBytes(outputSignatureFile, bOut.ToArray());
            }
        }

        public static bool verifyCMS(string dataFile, string signedDataFile)
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
    }
}
