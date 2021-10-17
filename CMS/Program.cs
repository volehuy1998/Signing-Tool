using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509.Store;
using System.Text;
using System.Collections;
using Org.BouncyCastle.Security;
using System.Security.Cryptography.X509Certificates;

namespace CMS
{
    class Program
    {
        private static string pfxFile = @"C:\Users\voleh\OneDrive\Chữ ký số\Võ Lê Huy.pfx";
        private static string pwd = "Xiangyu98@";
        private static string inputFile = @"D:\Phim\Người anh họ độc ác.mp4";
        private static string outputFile = @"signed-non-stream.cms";
        protected static void SignWithSystem(string inFile, AsymmetricKeyParameter privateKey, Org.BouncyCastle.X509.X509Certificate cert)
        {
            byte[] originalData = File.ReadAllBytes(inFile);

            var generator = new CmsSignedDataGenerator();
            // Add signing key
            generator.AddSigner(
              privateKey,
              cert,
              "2.16.840.1.101.3.4.2.1"); // SHA256 digest ID
            var storeCerts = new List<Org.BouncyCastle.X509.X509Certificate>();
            storeCerts.Add(cert); // NOTE: Adding end certificate too
            //storeCerts.AddRange(chain); // I'm assuming the chain collection doesn't contain the end certificate already
                                        // Construct a store from the collection of certificates and add to generator
            var storeParams = new X509CollectionStoreParameters(storeCerts);
            var certStore = X509StoreFactory.Create("CERTIFICATE/COLLECTION", storeParams);
            generator.AddCertificates(certStore);

            var signedData = generator.Generate(
              new CmsProcessableByteArray(originalData),
              true); // encapsulate = false for detached signature

            // save
            File.WriteAllBytes(outputFile, signedData.GetEncoded());
        }

        public static bool Verify(string originalFile, string signedFile, X509Certificate2 microsoftCert)
        {
            bool result = false;

            try
            {
                byte[] signedData = File.ReadAllBytes(signedFile);
                byte[] originalData = File.ReadAllBytes(originalFile);
                CmsSignedData cmsSignedData = null;
                Org.BouncyCastle.Crypto.Digests.GeneralDigest sha256 = new Org.BouncyCastle.Crypto.Digests.Sha256Digest();  

                if (signedFile != null && signedFile.Length > 0)
                {
                    cmsSignedData = new CmsSignedData(signedData);
                }

                sha256.BlockUpdate(originalData, 0, originalData.Length);
                //IDigest hashFunc = DigestUtilities.GetDigest(CmsSignedDataGenerator.DigestSha256);
                //hashFunc.BlockUpdate(m, 0, m.Length);
                byte[] expectedDigest = DigestUtilities.DoFinal(sha256);

                SignerInformationStore signers = cmsSignedData.GetSignerInfos();
                ICollection c = signers.GetSigners();
                foreach (SignerInformation signer in c)
                {
                    if (signer.Verify(DotNetUtilities.FromX509Certificate(microsoftCert)))
                    {
                        result = expectedDigest.SequenceEqual(signer.GetContentDigest());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        public static X509Certificate2 GetCertFromMicrosoftStore()
        {
            X509Certificate2 microsoftCert = null;

            X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            X509Certificate2Collection collection = store.Certificates;
            X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(collection, "Select", "Select a certificate to sign", X509SelectionFlag.MultiSelection);
            if (certs != null && certs.Count >= 1)
            {
                microsoftCert = certs[0];
            }

            return microsoftCert;
        }


        static void Main(string[] args)
        {
            byte[] originalData = File.ReadAllBytes(inputFile);
            try
            {
                // Load end certificate and signing key
                AsymmetricKeyParameter privateKey;
                var signerCert = ReadCertFromFile(pfxFile, pwd, out privateKey);

                // signed and save to file
                SignWithSystem(inputFile, privateKey, signerCert);
                // get MS cert from store
                X509Certificate2 microsoftCert = GetCertFromMicrosoftStore();
                // verify 
                bool result = Verify(originalFile: inputFile, signedFile: outputFile, microsoftCert);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed : " + ex.ToString());
            }
            Console.ReadKey();
        }

        public static Org.BouncyCastle.X509.X509Certificate ReadCertFromFile(string strCertificatePath)
        {
            // Create file stream object to read certificate
            using (var keyStream = new FileStream(strCertificatePath, FileMode.Open, FileAccess.Read))
            {
                var parser = new X509CertificateParser();
                return parser.ReadCertificate(keyStream);
            }
        }

        // This reads a certificate from a file.
        // Thanks to: http://blog.softwarecodehelp.com/2009/06/23/CodeForRetrievePublicKeyFromCertificateAndEncryptUsingCertificatePublicKeyForBothJavaC.aspx
        public static Org.BouncyCastle.X509.X509Certificate ReadCertFromFile(string strCertificatePath, string strCertificatePassword, out AsymmetricKeyParameter key)
        {
            key = null;
            // Create file stream object to read certificate
            using (var keyStream = new FileStream(strCertificatePath, FileMode.Open, FileAccess.Read))
            {
                // Read certificate using BouncyCastle component
                var inputKeyStore = new Pkcs12Store();
                inputKeyStore.Load(keyStream, strCertificatePassword.ToCharArray());

                var keyAlias = inputKeyStore.Aliases.Cast<string>().FirstOrDefault(n => inputKeyStore.IsKeyEntry(n));

                // Read Key from Aliases  
                //if (keyAlias == null)
                //    throw new NotImplementedException("Alias");
                //key = inputKeyStore.GetKey(keyAlias).Key;
                key = inputKeyStore.GetKey(keyAlias).Key;
                //Read certificate into 509 format
                return (Org.BouncyCastle.X509.X509Certificate)inputKeyStore.GetCertificate(keyAlias).Certificate;
            }
        }
    }
}
