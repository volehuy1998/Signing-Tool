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
using Org.BouncyCastle.Utilities.IO;

namespace CMS
{
    class Program
    {
        private static string pfxFile = @"C:\Users\voleh\OneDrive\Chữ ký số\Võ Lê Huy.pfx";
        private static string pwd = "Xiangyu98@";
		    private static string input = @"D:\Phim\Người anh họ độc ác.mp4";
        private static string output = @"signed.cms";
        private static int bufferSize = 1024 * 8; //8KB
        protected static void SignWithSystem(string inputFile, AsymmetricKeyParameter privateKey, Org.BouncyCastle.X509.X509Certificate cert, Org.BouncyCastle.X509.X509Certificate[] chain)
        //protected static byte[] SignWithSystem(string inputFile, AsymmetricKeyParameter privateKey, Org.BouncyCastle.X509.X509Certificate cert, Org.BouncyCastle.X509.X509Certificate[] chain)
        {
            var generator = new CmsSignedDataStreamGenerator();

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

            using (FileStream signed = new FileStream(output, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (FileStream unsigned = new FileStream(inputFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                Stream signing = generator.Open(signed, false);
                unsigned.CopyTo(signing);
            }
        }

        public static bool Verify(byte[] signedData)
        {
            bool result = false;

            CmsSignedData cmsSignedData = new CmsSignedData(signedData);
            Org.BouncyCastle.Crypto.Digests.GeneralDigest sha256 = new Org.BouncyCastle.Crypto.Digests.Sha256Digest();  

            sha256.BlockUpdate(m, 0, m.Length);
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
                X509Certificate2 microsoftCert = certs[0];

                Org.BouncyCastle.Crypto.Digests.GeneralDigest sha256 = new Org.BouncyCastle.Crypto.Digests.Sha256Digest();
                using (FileStream fs = new FileStream(input, FileMode.Open, FileAccess.Read))
                {
                    byte[] buf = new byte[bufferSize];
                    int n = 0;
                    while ((n = fs.Read(buf, 0, buf.Length)) > 0)
                    {
                        sha256.BlockUpdate(buf, 0, n);
                    }
                }

                byte[] expectedDigest = new byte[sha256.GetDigestSize()];
                sha256.DoFinal(expectedDigest, 0);

                //IDigest hashFunc = DigestUtilities.GetDigest(CmsSignedDataGenerator.DigestSha256);
                //hashFunc.BlockUpdate(m, 0, m.Length);
                //byte[] expectedDigest = DigestUtilities.DoFinal(sha256);

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

            return microsoftCert;
        }


        static void Main(string[] args)
        {
            byte[] originalData = File.ReadAllBytes(inputFile);
            try
            {
                // Load end certificate and signing key
                AsymmetricKeyParameter key;
                var signerCert = ReadCertFromFile(pfxFile, pwd, out key);

                // Read CA cert
                //var caCert = ReadCertFromFile(@"C:\Temp\CA.cer");
                Org.BouncyCastle.X509.X509Certificate[] certChain = null;// new X509Certificate[] { caCert };

                SignWithSystem(
                  //Guid.NewGuid().ToByteArray(), // Any old data for sake of example
                  input,
                  key,
                  signerCert,
                  certChain);
                                
                bool result = Verify(File.ReadAllBytes(output));
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
