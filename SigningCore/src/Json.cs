using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SigningCore
{
    class Json
    {
        public static string Sign(string payload, string pfxPath, string pfxPwd)
        {
            if (Common.CheckString(payload))
                throw new Exception("Payload to sign null");
            if (Common.CheckString(pfxPath))
                throw new Exception("Pfx file to sign null");
            if (Common.CheckString(pfxPwd))
                throw new Exception("Pfx pwd to sign null");

            string jwt = string.Empty;
            string headerJwt = string.Empty;
            string payloadJwt = string.Empty;
            string signatureJwt = string.Empty;
            string keyAlias = string.Empty;
            object header = null;
            RsaKeyParameters privateKey = null;
            RsaKeyParameters publicKey = null;
            Pkcs12Store pkcs12Store = null;

            pkcs12Store = Helper.GetPkcs12Store(pfxPath, pfxPwd);
            keyAlias = Helper.GetAliasFromPkcs12Store(pkcs12Store);
            publicKey = pkcs12Store.GetCertificate(keyAlias).Certificate.GetPublicKey() as RsaKeyParameters;
            // generate header
            header = new { 
                alg = "RS256",
                typ = "JWT",
                // RFC7517
                use = "sig",
                kty ="RSA",
                e = publicKey.Exponent.ToString(),
                n = publicKey.Modulus.ToString()
            };

            byte[] headerBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header, Formatting.None));
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);
            // base64 header and payload
            headerJwt = Base64UrlEncode(headerBytes);
            payloadJwt = Base64UrlEncode(payloadBytes);
            // data to sign
            byte[] bytesToSign = Encoding.UTF8.GetBytes(headerJwt + "." + payloadJwt);
            // extract private key
            privateKey = pkcs12Store.GetKey(keyAlias).Key as RsaKeyParameters;
            // hash and encrypt
            ISigner sig = SignerUtilities.GetSigner("SHA256withRSA");
            sig.Init(true, privateKey);
            sig.BlockUpdate(bytesToSign, 0, bytesToSign.Length);
            // base64 signature
            signatureJwt = Base64UrlEncode(sig.GenerateSignature());
            // generate jwt
            jwt = headerJwt + "." + payloadJwt + "." + signatureJwt;

            return jwt;
        }

        public static string Decode(string token, bool verifySignature = true)
        {
            if (Common.CheckString(token))
                throw new Exception("JWT to verify null");

            int dotCounter = token.Count(f => f == '.');
            if (dotCounter < 2)
                throw new Exception($"JWT format incorrect, {dotCounter+1}/3 components found");

            string[] segments = token.Split('.');
            string headerJwt = segments[0];
            string payloadJwt = segments[1];
            string signatureJwt = segments[2];
            byte[] signature = Base64UrlDecode(signatureJwt);
            byte[] bytesToHash = Encoding.UTF8.GetBytes(headerJwt + '.' + payloadJwt);
            RsaKeyParameters publicKey = null;

            string headerJson = Encoding.UTF8.GetString(Base64UrlDecode(headerJwt));
            string payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payloadJwt));
            JObject headerData = JObject.Parse(headerJson);
            JObject payloadData = JObject.Parse(payloadJson);

            if (verifySignature)
            {
                if (headerData["use"].ToString().Equals("sig", StringComparison.OrdinalIgnoreCase))
                {
                    publicKey = new RsaKeyParameters(false,
                        new Org.BouncyCastle.Math.BigInteger(headerData["n"].ToString()),
                        new Org.BouncyCastle.Math.BigInteger(headerData["e"].ToString()));
                    // decrypt signature and compare with hash
                    ISigner verifier = SignerUtilities.GetSigner("SHA256withRSA");
                    verifier.Init(false, publicKey);
                    verifier.BlockUpdate(bytesToHash, 0, bytesToHash.Length);
                    if (verifier.VerifySignature(signature))
                    {
                        // verify ok
                    }
                    else
                    {
                        // faked data or signature
                        throw new Exception("Verify JWT failed with incorrect data or signature");
                    }
                }
                else
                {
                    throw new Exception("RSA key not for signature verification");
                }
            }

            return payloadData.ToString();
        }

        private static string Base64UrlEncode(byte[] input)
        {
            var output = Convert.ToBase64String(input);
            output = output.Split('=')[0]; // Remove any trailing '='s
            output = output.Replace('+', '-'); // 62nd char of encoding
            output = output.Replace('/', '_'); // 63rd char of encoding

            return output;
        }

        private static byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 1: output += "==="; break; // Three pad chars
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break; // One pad char
                default: throw new Exception("Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder

            return converted;
        }

    }
}
