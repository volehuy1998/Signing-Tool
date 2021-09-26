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

namespace CMS
{
    class Program
    {
        private static string pfxFile = @"C:\Users\voleh\source\repos\Signing Tool\Create a basic cert\bin\Debug\certificatename.pfx";
        private static string pwd = "passwordProtected";
        protected static byte[] SignWithSystem(byte[] m, AsymmetricKeyParameter privateKey, X509Certificate cert, X509Certificate[] chain)
        {
            var generator = new CmsSignedDataGenerator();
            // Add signing key
            generator.AddSigner(
              privateKey,
              cert,
              "2.16.840.1.101.3.4.2.1"); // SHA256 digest ID
            var storeCerts = new List<X509Certificate>();
            storeCerts.Add(cert); // NOTE: Adding end certificate too
            //storeCerts.AddRange(chain); // I'm assuming the chain collection doesn't contain the end certificate already
                                        // Construct a store from the collection of certificates and add to generator
            var storeParams = new X509CollectionStoreParameters(storeCerts);
            var certStore = X509StoreFactory.Create("CERTIFICATE/COLLECTION", storeParams);
            generator.AddCertificates(certStore);

            // Generate the signature
            var signedData = generator.Generate(
              new CmsProcessableByteArray(m),
              true); // encapsulate = false for detached signature

            IX509Store certs = signedData.GetCertificates("Collection");
            SignerInformationStore signers = signedData.GetSignerInfos();
            ICollection c = signers.GetSigners();
            foreach (SignerInformation signer in c)
            {
                ICollection certCollection = certs.GetMatches(signer.SignerID);

                IEnumerator certEnum = certCollection.GetEnumerator();

                certEnum.MoveNext();
                X509Certificate cert2 = (X509Certificate)certEnum.Current;
                bool res = signer.Verify(cert);
                if (res)
                {
                    Org.BouncyCastle.Crypto.Digests.GeneralDigest sha256 = new Org.BouncyCastle.Crypto.Digests.Sha256Digest();
                    
                    sha256.BlockUpdate(m, 0, m.Length);
                    //IDigest hashFunc = DigestUtilities.GetDigest(CmsSignedDataGenerator.DigestSha256);
                    //hashFunc.BlockUpdate(m, 0, m.Length);
                    byte[] expectedDigest = DigestUtilities.DoFinal(sha256);
                    res = expectedDigest.SequenceEqual(signer.GetContentDigest());
                }
            }

            return signedData.GetEncoded();
        }

        static void Main(string[] args)
        {
            byte[] fakeData = Encoding.ASCII.GetBytes("huy");

            try
            {
                // Load end certificate and signing key
                AsymmetricKeyParameter key;
                var signerCert = ReadCertFromFile(pfxFile, pwd, out key);

                // Read CA cert
                //var caCert = ReadCertFromFile(@"C:\Temp\CA.cer");
                X509Certificate[] certChain = null;// new X509Certificate[] { caCert };

                var result = SignWithSystem(
                  //Guid.NewGuid().ToByteArray(), // Any old data for sake of example
                  fakeData,
                  key,
                  signerCert,
                  certChain);

                File.WriteAllBytes("Signature.data", result);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed : " + ex.ToString());
                Console.ReadKey();
            }
        }

        public static X509Certificate ReadCertFromFile(string strCertificatePath)
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
        public static X509Certificate ReadCertFromFile(string strCertificatePath, string strCertificatePassword, out AsymmetricKeyParameter key)
        {
            key = null;
            // Create file stream object to read certificate
            using (var keyStream = new FileStream(strCertificatePath, FileMode.Open, FileAccess.Read))
            {
                // Read certificate using BouncyCastle component
                var inputKeyStore = new Pkcs12Store();
                inputKeyStore.Load(keyStream, strCertificatePassword.ToCharArray());

                //var keyAlias = inputKeyStore.Aliases.Cast<string>().FirstOrDefault(n => inputKeyStore.IsKeyEntry(n));

                // Read Key from Aliases  
                //if (keyAlias == null)
                //    throw new NotImplementedException("Alias");
                //key = inputKeyStore.GetKey(keyAlias).Key;
                key = inputKeyStore.GetKey("CN=some.machine.domain.tld_key").Key;
                //Read certificate into 509 format
                return (X509Certificate)inputKeyStore.GetCertificate("CN=some.machine.domain.tld_key").Certificate;
            }
        }
    }
}
