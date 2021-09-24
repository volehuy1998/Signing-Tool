using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Create_a_basic_cert
{
    class Program
    {
        private static string pwd = "passwordProtected";
        private static string pfx = "certificatename.pfx";
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
            using (var filestream = new FileStream(pfx, FileMode.Create, FileAccess.ReadWrite))
            {
                store.Save(filestream, pwd.ToCharArray(), new SecureRandom());
            }

            //ExtractCertFromPfx(pfx, pwd);
        }

        public static void ExtractCertFromPfx(string pfxFile, string password)
        {
            byte[] fakeData = Encoding.ASCII.GetBytes("huy");
            var pkcs = new Pkcs12Store(File.Open(pfx, FileMode.Open), password.ToCharArray());
            //var aliases = pkcs.Aliases; // is a list of certificate names that are in the pfx;
            AsymmetricKeyParameter privateKey = pkcs.GetKey("CN=some.machine.domain.tld_key").Key;

            X509CertificateEntry certEntry = pkcs.GetCertificate("CN=some.machine.domain.tld_key"); // gets a certificate from the pfx
            X509Certificate cert = certEntry.Certificate;
            AsymmetricKeyParameter publicKey = cert.GetPublicKey();

            Sign(pri: privateKey, pub: publicKey, msg: fakeData, cert.SigAlgName);
            Pkcs_Crypt(pri: privateKey, pub: publicKey, m: fakeData);
            Crypt(pri: privateKey, pub: publicKey, m: fakeData);
        }

        static void Sign(AsymmetricKeyParameter pri, AsymmetricKeyParameter pub, byte[] msg, string algo)
        {
            ISigner signer = SignerUtilities.GetSigner(algo);
            signer.Init(true, pri);
            signer.BlockUpdate(msg, 0, msg.Length);
            byte[] signdata = signer.GenerateSignature();

            ISigner verifier = SignerUtilities.GetSigner(HashType.SHA256withRSA.ToString());
            verifier.Init(false, pub);
            verifier.BlockUpdate(msg, 0, msg.Length);

            bool result = verifier.VerifySignature(signdata);
            if (result)
            {
                Console.WriteLine("Verify success!");
            }
            else
            {
                Console.WriteLine("Verify fail!");
            }
        }

        static void Pkcs_Crypt(AsymmetricKeyParameter pri, AsymmetricKeyParameter pub, byte[] m)
        {
            Pkcs1Encoding encryptEngine = new Pkcs1Encoding(new RsaEngine());
            encryptEngine.Init(true, pub);
            byte[] em = encryptEngine.ProcessBlock(m, 0, m.Length);

            Pkcs1Encoding encryptEngine2 = new Pkcs1Encoding(new RsaEngine());
            encryptEngine2.Init(false, pri);
            byte[] dm = encryptEngine2.ProcessBlock(em, 0, em.Length);

            if (m.SequenceEqual(dm))
            {
                Console.WriteLine("Pkcs decrypt success!");
            }
            else
            {
                Console.WriteLine("Pkcs decrypt fail!");
            }
        }

        static void Crypt(AsymmetricKeyParameter pri, AsymmetricKeyParameter pub, byte[] m)
        {
            var engine = new RsaEngine();
            engine.Init(true, pub);
            var blockSize = engine.GetInputBlockSize();
            byte[] em = engine.ProcessBlock(m, 0, m.Length);

            var engine2 = new RsaEngine();
            engine2.Init(false, pri);
            blockSize = engine2.GetInputBlockSize();
            byte[] dm = engine2.ProcessBlock(em, 0, blockSize);

            if (m.SequenceEqual(dm))
            {
                Console.WriteLine("Decrypt success!");
            }
            else
            {
                Console.WriteLine("Decrypt fail!");
            }
        }
    }
}
