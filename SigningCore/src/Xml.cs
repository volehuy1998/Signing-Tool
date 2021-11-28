using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
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
    public class Xml
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
            X509Certificate bouncycastle_cert = null;
            RSA privateKey = null;
            RSAParameters rSAParameters;

            pkcs12Store = Helper.GetPkcs12Store(pfxPath, pfxPwd);
            keyAlias = Helper.GetAliasFromPkcs12Store(pkcs12Store);
            bouncycastle_cert = pkcs12Store.GetCertificate(keyAlias).Certificate;
            rSAParameters = Helper.ToRSAParameters(pkcs12Store.GetKey(keyAlias).Key as RsaPrivateCrtKeyParameters);
            privateKey = RSA.Create();
            privateKey.ImportParameters(rSAParameters);

            Reference reference = new Reference();
            reference.Uri = "";
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());

            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = privateKey;
            signedXml.AddReference(reference);
            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();
           
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));

            XmlElement keyInfoElement = xmlDoc.CreateElement("SignatureVerification");
            XmlElement useElement = xmlDoc.CreateElement("use");
            XmlElement ktyElement = xmlDoc.CreateElement("kty");
            XmlElement exponentElement = xmlDoc.CreateElement("e");
            XmlElement modulusElement = xmlDoc.CreateElement("n");
            useElement.InnerText = "sig";
            ktyElement.InnerText = "RSA";
            exponentElement.InnerText = Convert.ToBase64String((bouncycastle_cert.GetPublicKey() as RsaKeyParameters).Exponent.ToByteArrayUnsigned());
            modulusElement.InnerText = Convert.ToBase64String((bouncycastle_cert.GetPublicKey() as RsaKeyParameters).Modulus.ToByteArrayUnsigned());
            keyInfoElement.AppendChild(useElement);
            keyInfoElement.AppendChild(ktyElement);
            keyInfoElement.AppendChild(exponentElement);
            keyInfoElement.AppendChild(modulusElement);

            xmlDoc.DocumentElement.AppendChild(keyInfoElement);
            return xmlDoc;
        }

        public static bool Microsoft_VerifyXml(XmlDocument signedXmlDoc)
        {
            if (signedXmlDoc == null)
                throw new Exception("File xml to verify null");

            bool result = false;
            SignedXml signedXml = null;

            // find node by serial number certificate
            XmlNode serialNumberNode = signedXmlDoc.SelectSingleNode(@"//catalog/SerialNumber");
            XmlNode signatureVerificationNode = signedXmlDoc.SelectSingleNode(@"//catalog/SignatureVerification");
            XmlNode useNode = signatureVerificationNode.SelectSingleNode(@"//use");
            XmlNode ktyNode = signatureVerificationNode.SelectSingleNode(@"//kty");
            XmlNode exponentNode = signatureVerificationNode.SelectSingleNode(@"//e");
            XmlNode modulusNode = signatureVerificationNode.SelectSingleNode(@"//n");

            // back to signed xml by remove
            signatureVerificationNode.ParentNode.RemoveChild(signatureVerificationNode);
            if (useNode.InnerText.Equals("sig", StringComparison.OrdinalIgnoreCase))
            {
                RSAParameters RSAKeyInfo = new RSAParameters();
                RSAKeyInfo.Exponent =  Convert.FromBase64String(exponentNode.InnerText);
                RSAKeyInfo.Modulus = Convert.FromBase64String(modulusNode.InnerText);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(RSAKeyInfo);
                //publickey = RSA.Create(RSAKeyInfo);
                signedXml = new SignedXml(signedXmlDoc);

                XmlNodeList signatureNode = signedXmlDoc.GetElementsByTagName("Signature");
                if (signatureNode == null || signatureNode.Count > 1)
                    throw new Exception("No or more than one signature tag");

                // found one signature

                XmlElement signatureElem = signatureNode[0] as XmlElement;
                if (signatureElem == null)
                    throw new Exception("Signature node can not cast to element");

                signedXml.LoadXml(signatureElem);
                result = signedXml.CheckSignature(rsa);
            }
            else
            {
                throw new Exception("RSA key not for signature verification");
            }

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

                // Just encrypt parent for all
                // if I handle encrypt multiple sub-tagname well, I will remove this 'break' line.
                // Why we got exception? because encrypt parent and it's child will throw exception, i dont know how to handle
                break;
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
