using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_a_basic_cert
{
    class Program
    {
        public enum HashType
        {
            SHA1withDSA, //-- DSA
            SHA1withECDSA, //
            SHA224withECDSA, // ECDSA with SHA1 and SHA2 support
            SHA256withECDSA, //
            SHA384withECDSA, //
            SHA512withECDSA, //
            MD2withRSA, // --
            MD5withRSA, // --
            SHA1withRSA, // --
            SHA224withRSA, // -- RSA with MD2, MD5, SHA1, SHA2 and RIPEMD
            SHA256withRSA, // --
            SHA384withRSA, // --
            SHA512withRSA, // --
            RIPEMD160withRSA, // -- RIPEMD hash
            RIPEMD128withRSA, // --
            RIPEMD256withRSA, // --
        }

        static void Main(string[] args)
        {
            // Keypair Generator
            RsaKeyPairGenerator kpGenerator = new RsaKeyPairGenerator();
            kpGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));

            // Create a keypair
            AsymmetricCipherKeyPair kp = kpGenerator.GenerateKeyPair();

            // Certificate Generator
            X509V3CertificateGenerator cGenerator = new X509V3CertificateGenerator();
            cGenerator.SetSerialNumber(BigInteger.ProbablePrime(120, new Random()));
            cGenerator.SetSubjectDN(new X509Name("CN=" + "some.machine.domain.tld"));
            cGenerator.SetIssuerDN(new X509Name("CN=" + "issuer's name"));
            cGenerator.SetNotBefore(DateTime.UtcNow);
            cGenerator.SetNotAfter(DateTime.UtcNow.Add(new TimeSpan(365, 0, 0, 0))); // Expire in 1 year
            cGenerator.SetSignatureAlgorithm(HashType.SHA256withRSA.ToString()); // See the Appendix Below for info on the hash types supported by Bouncy Castle C#
            cGenerator.SetPublicKey(kp.Public); // Only the public key should be used here!

            X509Certificate cert = cGenerator.Generate(kp.Private); // Create a self-signed cert


            // Create the PKCS12 store
            Pkcs12Store store = new Pkcs12StoreBuilder().Build();

            // Add a Certificate entry
            X509CertificateEntry certEntry = new X509CertificateEntry(cert);
            store.SetCertificateEntry(cert.SubjectDN.ToString(), certEntry); // use DN as the Alias.

            // Add a key entry
            AsymmetricKeyEntry keyEntry = new AsymmetricKeyEntry(kp.Private);
            store.SetKeyEntry(cert.SubjectDN.ToString() + "_key", keyEntry, new X509CertificateEntry[] { certEntry }); // Note that we only have 1 cert in the 'chain'

            // Save to the file system
            using (var filestream = new FileStream("certificatename.pfx", FileMode.Create, FileAccess.ReadWrite))
            {
                store.Save(filestream, "passwordProtected".ToCharArray(), new SecureRandom());
            }
        }
    }
}
