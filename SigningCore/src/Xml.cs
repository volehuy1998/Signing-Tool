using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core
{
    class Xml
    {
        public static XmlDocument Microsoft_SignXml(XmlDocument xmlDoc, RSA privateKey)
        {
            if (xmlDoc == null)
                throw new Exception("File xml to sign null");
            if (privateKey == null)
                throw new Exception("Private key to sign xml null");

            Reference reference = new Reference();
            reference.Uri = "";
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());

            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = privateKey;
            signedXml.AddReference(reference);
            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();

            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));

            return xmlDoc;
        }

        public static bool Microsoft_VerifyXml(XmlDocument signedXmlDoc, RSA publicKey)
        {
            if (signedXmlDoc == null)
                throw new Exception("File xml to verify null");

            if (publicKey == null)
                throw new Exception("Public key to verify xml null");

            bool result = false;
            SignedXml signedXml = new SignedXml(signedXmlDoc);

            XmlNodeList signatureNode = signedXmlDoc.GetElementsByTagName("Signature");
            if (signatureNode == null || signatureNode.Count > 1)
                throw new Exception("No or more than one signature tag");

            // found one signature

            XmlElement signatureElem = signatureNode[0] as XmlElement;
            if (signatureElem == null)
                throw new Exception("Signature node can not cast to element");

            signedXml.LoadXml(signatureElem);
            result = signedXml.CheckSignature(publicKey);

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
