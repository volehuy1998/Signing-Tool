using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SigningCore.test
{
    public class XmlTestCase : AbstractTestCase
    {
        public override void Test()
        {
            this.TestSign();
            this.TestSymCrypt();
        }

        protected void TestSign()
        {
            bool result = false;
            XmlDocument signedXml = null;
            XmlDocument inputXmlDoc = null;

            try
            {
                inputXmlDoc = new XmlDocument();
                inputXmlDoc.Load(Common.InputXmlFile);

                // sign
                signedXml = SigningCore.Xml.Microsoft_SignXml(inputXmlDoc, Common.PfxFile, Common.PfxPwd);
                signedXml.Save(Common.SignedXmlFile);

                // verify
                signedXml = new XmlDocument();
                signedXml.Load(Common.SignedXmlFile);
                result = SigningCore.Xml.Microsoft_VerifyXml(signedXml);
            }
            catch (Exception ex)
            {
                Common.Show(ex.ToString(), ConsoleColor.Yellow);
            }

            Common.ShowResult(result, MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
        }

        protected void TestSymCrypt()
        {
            bool result = false;
            XmlDocument inputXmlDoc = null;
            XmlDocument encryptedXmlDoc = null;
            XmlDocument decryptedXmlDoc = null;

            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Helper.GenerateAesKey(128);
                    aesAlg.Mode = CipherMode.CBC;

                    // encrypt
                    inputXmlDoc = new XmlDocument();
                    inputXmlDoc.Load(Common.InputXmlFile);
                    encryptedXmlDoc = SigningCore.Xml.Microsoft_EncryptXML_Sym(inputXmlDoc, new List<string>() { "author" }, aesAlg);
                    encryptedXmlDoc.Save(Common.EncryptedXmlFile);

                    // decrypt
                    encryptedXmlDoc = new XmlDocument();
                    encryptedXmlDoc.Load(Common.EncryptedXmlFile);
                    decryptedXmlDoc = SigningCore.Xml.Microsoft_DecryptXML_Sym(encryptedXmlDoc, aesAlg);
                    encryptedXmlDoc.Save(Common.DecryptedXmlFile);

                    result = Helper.GenerateDiffGram(Common.InputXmlFile, Common.DecryptedXmlFile);
                }
            }
            catch (Exception ex)
            {
                Common.Show(ex.ToString(), ConsoleColor.Yellow);
            }

            Common.ShowResult(result, MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
        }
    }
}
