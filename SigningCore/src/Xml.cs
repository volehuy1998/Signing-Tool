using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using SigningCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SigningCore
{
    class Xml
    {
        public static XmlDocument Microsoft_SignXml(XmlDocument xmlDoc, string pfxPath, string pfxPwd)
        {
            if (xmlDoc == null)
                throw new Exception("File xml to sign null");
            if (Common.CheckString(pfxPath))
                throw new Exception("Pfx file to sign null");
            if (Common.CheckString(pfxPwd))
                throw new Exception("Pfx pwd to sign null");

            string keyAlias = string.Empty;
            string serialNumber = string.Empty;
            Pkcs12Store pkcs12Store = null;
            RSA privateKey = null;

            pkcs12Store = Helper.GetPkcs12Store(pfxPath, pfxPwd);
            keyAlias = Helper.GetAliasFromPkcs12Store(pkcs12Store);
            serialNumber = pkcs12Store.GetCertificate(keyAlias).Certificate.SerialNumber.ToString();
            AsymmetricKeyEntry keyEntry = pkcs12Store.GetKey(keyAlias);
            privateKey = DotNetUtilities.ToRSA(keyEntry.Key as RsaPrivateCrtKeyParameters);

            Reference reference = new Reference();
            reference.Uri = "";
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());

            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = privateKey;
            signedXml.AddReference(reference);
            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();
           
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
            XmlElement serialNumberElement = xmlDoc.CreateElement("SerialNumber");
            serialNumberElement.InnerText = serialNumber.ToString();
            xmlDoc.DocumentElement.AppendChild(serialNumberElement);

            return xmlDoc;
        }

        public static bool Microsoft_VerifyXml(XmlDocument signedXmlDoc)
        {
            if (signedXmlDoc == null)
                throw new Exception("File xml to verify null");

            bool result = false;
            RSA publickey = null;
            System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert = null;
            SignedXml signedXml = null;

            // find node by serial number certificate
            XmlNode serialNumberNode = signedXmlDoc.SelectSingleNode(@"//catalog/SerialNumber");
            Org.BouncyCastle.Math.BigInteger serialNumber = new Org.BouncyCastle.Math.BigInteger(serialNumberNode.InnerText, 10);
            // back to signed xml by remove
            serialNumberNode.ParentNode.RemoveChild(serialNumberNode);
            // get microsoft cert by serial number
            microsoftCert = Helper.GetMicrosoftCert(serialNumber);
            publickey = microsoftCert.PublicKey.Key as RSA;

            signedXml = new SignedXml(signedXmlDoc);

            XmlNodeList signatureNode = signedXmlDoc.GetElementsByTagName("Signature");
            if (signatureNode == null || signatureNode.Count > 1)
                throw new Exception("No or more than one signature tag");

            // found one signature

            XmlElement signatureElem = signatureNode[0] as XmlElement;
            if (signatureElem == null)
                throw new Exception("Signature node can not cast to element");

            signedXml.LoadXml(signatureElem);
            result = signedXml.CheckSignature(publickey);

            return result;
        }

        public static XmlDocument Microsoft_EncryptXML_Sym(XmlDocument Doc, List<string> ElementNames, SymmetricAlgorithm symAlgo)
        {
            if (Doc == null)
                throw new Exception("File xml to encrypt null");
            if (ElementNames == null && ElementNames.Count == 0)
                throw new Exception("Target tag to encrypt null");
            if (symAlgo == null)
                throw new Exception("Algorithm to encrypt null");

            EncryptedXml xmlEncryptor = new EncryptedXml();
            List<Tuple<XmlElement, EncryptedData>> targetReplace = new List<Tuple<XmlElement, EncryptedData>>();

            foreach (string ElementName in ElementNames)
            {
                XmlNodeList xmlNodeList = Doc.GetElementsByTagName(ElementName);
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    XmlElement elementToEncrypt = xmlNode as XmlElement;
                    if (elementToEncrypt != null)
                    {
                        EncryptedData encryptDataElem = Helper.EncryptXmlElement(xmlEncryptor, elementToEncrypt, symAlgo);
                        if (encryptDataElem != null)
                        {
                            targetReplace.Add(Tuple.Create(elementToEncrypt, encryptDataElem));
                        }
                        else
                        {
                            // tag content empty, do nothing
                        }
                    }
                }

                foreach (var t in targetReplace)
                {
                    // replace elem
                    EncryptedXml.ReplaceElement(t.Item1, t.Item2, false);
                }
            }

            return Doc;
        }

        public static XmlDocument Microsoft_DecryptXML_Sym(XmlDocument Doc, SymmetricAlgorithm Alg)
        {
            if (Doc == null)
                throw new Exception("File xml to decrypt null");
            if (Alg == null)
                throw new Exception("Algorithm to decrypt null");

            EncryptedXml xmlEncryptor = new EncryptedXml();
            List<Tuple<XmlElement, byte[]>> targetReplace = new List<Tuple<XmlElement, byte[]>>();
            XmlNodeList xmlNodeList = Doc.GetElementsByTagName("EncryptedData");

            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // found elems

                foreach (XmlElement xmlElement in xmlNodeList)
                {
                    XmlElement encryptedElement = xmlElement as XmlElement;
                    byte[] decryptedData = Helper.DecryptXmlElement(xmlEncryptor, encryptedElement, Alg);
                    if (decryptedData != null && decryptedData.Length > 0)
                    {
                        targetReplace.Add(Tuple.Create(encryptedElement, decryptedData));
                    }
                }

                foreach (var t in targetReplace)
                {
                    // replace elem
                    xmlEncryptor.ReplaceData(t.Item1, t.Item2);
                }
            }
            else
            {
                // not found any encrypt tags, do nothing
            }

            return Doc;
        }
    }
}
