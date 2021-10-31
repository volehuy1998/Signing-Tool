using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Signing_Core
{
    public class Helper
    {
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


        public static byte[] GenerateAesKey(int size)
        {
            byte[] aesKey = null;
            CipherKeyGenerator keyGen = null;

            // generate aes key
            keyGen = GeneratorUtilities.GetKeyGenerator("AES");
            keyGen.Init(new KeyGenerationParameters(new SecureRandom(), size));
            aesKey = keyGen.GenerateKey();

            return aesKey;
        }

        public static string GetXmlAlgoEncrypt(SymmetricAlgorithm symAlgo)
        {
            string res = string.Empty;

            if (symAlgo is Aes)
            {
                if      (symAlgo.KeySize == 128) res = EncryptedXml.XmlEncAES128Url;
                else if (symAlgo.KeySize == 192) res = EncryptedXml.XmlEncAES192Url;
                else if (symAlgo.KeySize == 256) res = EncryptedXml.XmlEncAES256Url;
            }

            return res;
        }
    }
}
