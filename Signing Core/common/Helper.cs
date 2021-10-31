using Microsoft.XmlDiffPatch;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core
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

        public static EncryptedData EncryptXmlElement(EncryptedXml xmlEncryptor, XmlElement elementToEncrypt, SymmetricAlgorithm symAlgo)
        {
            EncryptedData encryptedDataElem = null;

            if (elementToEncrypt != null && !string.IsNullOrWhiteSpace(elementToEncrypt.InnerText))
            {
                // target element ok

                // encrypt
                byte[] encryptedElement = xmlEncryptor.EncryptData(elementToEncrypt, symAlgo, false);

                if (symAlgo is Aes)
                {
                    // aes algo ok

                    string algo = GetXmlAlgoEncrypt(symAlgo);

                    encryptedDataElem = new EncryptedData();
                    encryptedDataElem.Type = EncryptedXml.XmlEncElementUrl;
                    encryptedDataElem.EncryptionMethod = new EncryptionMethod(algo);
                    encryptedDataElem.CipherData.CipherValue = Encoding.UTF8.GetBytes(Convert.ToBase64String(encryptedElement));
                }
                else
                {
                    // incorrect aes algo
                }
            }
            else
            {
                // incorrect type xml elem
            }

            return encryptedDataElem;
        }

        public static byte[] DecryptXmlElement(EncryptedXml xmlEncryptor, XmlElement elementToDecrypt, SymmetricAlgorithm symAlgo)
        {
            byte[] decryptedData = null;

            if (elementToDecrypt != null && !string.IsNullOrWhiteSpace(elementToDecrypt.InnerText))
            {
                // correct type xml element

                EncryptedData encryptedDataElem = new EncryptedData();
                encryptedDataElem.LoadXml(elementToDecrypt);
                encryptedDataElem.CipherData.CipherValue = Convert.FromBase64String(Encoding.UTF8.GetString(encryptedDataElem.CipherData.CipherValue));

                // decrypt
                decryptedData = xmlEncryptor.DecryptData(encryptedDataElem, symAlgo);
            }
            else
            {
                // incorrect type xml elem
            }

            return decryptedData;
        }

        public static Pkcs12Store GetPkcs12Store(string pfxPath, string pwd)
        {
            Pkcs12Store pkcs12Store = null;

            using (FileStream keyStream = new FileStream(pfxPath, FileMode.Open, FileAccess.Read))
            {
                pkcs12Store = new Pkcs12Store();
                pkcs12Store.Load(keyStream, pwd.ToCharArray());
            }

            return pkcs12Store;
        }

        public static string GetAliasFromPkcs12Store(Pkcs12Store pkcs12Store)
        {
            string alias = pkcs12Store.Aliases.Cast<string>().FirstOrDefault(p => pkcs12Store.IsKeyEntry(p));

            return alias;
        }

        public static bool CompareFiles(string file1, string file2)
        {
            bool result = false;
            byte[] expectedMd5 = null;
            byte[] digestMd5 = null;

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var rawDataStream = File.OpenRead(file1))
                {
                    expectedMd5 = md5.ComputeHash(rawDataStream);
                }
            }

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var decryptedStream = File.OpenRead(file2))
                {
                    digestMd5 = md5.ComputeHash(decryptedStream);
                }
            }

            result = Arrays.AreEqual(expectedMd5, digestMd5);

            return result;
        }

        public static bool GenerateDiffGram(string originalFile, string finalFile)
        {
            bool result = false;

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter diff = XmlWriter.Create(Common.DiffXmlFile, settings))
            {
                XmlDiff xmldiff = new XmlDiff(XmlDiffOptions.IgnoreComments | XmlDiffOptions.IgnoreWhitespace);
                result = xmldiff.Compare(originalFile, finalFile, false, diff);
            }

            return result;
        }
    }
}
