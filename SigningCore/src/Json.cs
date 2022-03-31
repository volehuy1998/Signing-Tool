using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SigningCore
{
    public class Json
    {
        public static SecureRandom seed = new SecureRandom();
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

        public static string Sign(string payload, string signedFile, Pkcs12Store pkcs12Store)
        {
            if (Common.CheckString(payload))
                throw new Exception("Payload to sign null");
            if (pkcs12Store == null)
                throw new Exception("PKCS#12 file null to sign");

            string jwt = string.Empty;
            string headerJwt = string.Empty;
            string payloadJwt = string.Empty;
            string signatureJwt = string.Empty;
            string keyAlias = string.Empty;
            object header = null;
            RsaKeyParameters privateKey = null;
            RsaKeyParameters publicKey = null;

            keyAlias = Helper.GetAliasFromPkcs12Store(pkcs12Store);
            publicKey = pkcs12Store.GetCertificate(keyAlias).Certificate.GetPublicKey() as RsaKeyParameters;
            // generate header
            header = new
            {
                alg = "RS256",
                typ = "JWT",
                // RFC7517
                use = "sig",
                kty = "RSA",
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

        public static string Encrypt(object dataObject, RsaKeyParameters publicKey)
        {
            if (dataObject == null)
                throw new Exception("Payload to encrypt null");
            if (publicKey == null)
                throw new Exception("Public key to encrypt secret key null");

            string token = string.Empty;
            string headerToken = string.Empty;
            // aes key and iv
            byte[] encryptedAesKeyBytes = null;
            byte[] encryptedAesIvBytes = null;
            string encryptedAesKeyBase64 = string.Empty;
            string encryptedAesIvBase64 = string.Empty;
            // cipher
            string encryptedPayloadToken = string.Empty;
            object headerObject = null;
            string encryptedPayloadJson = string.Empty;
            IAsymmetricBlockCipher rsaOaep = null;
            
            // create header contain key and iv
            AesManaged aes = new AesManaged();
            aes.GenerateKey();
            aes.GenerateIV();
            rsaOaep = new OaepEncoding(new RsaEngine());
            rsaOaep.Init(true, new ParametersWithRandom(publicKey, seed));
            encryptedAesKeyBytes = rsaOaep.ProcessBlock(aes.Key, 0, aes.Key.Length);
            encryptedAesIvBytes = rsaOaep.ProcessBlock(aes.IV, 0, aes.IV.Length);
            encryptedAesKeyBase64 = Base64UrlEncode(encryptedAesKeyBytes);
            encryptedAesIvBase64 = Base64UrlEncode(encryptedAesIvBytes);
            headerObject = new
            {
                alg="RSA-OAEP",
                enc="AES256",
                key= encryptedAesKeyBase64,
                iv= encryptedAesIvBase64
            };
            headerToken = Base64UrlEncode(Encoding.UTF8.GetBytes(JObject.FromObject(headerObject).ToString()));
            // create cipher payload
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new EncryptedStringPropertyResolver(aes.Key, aes.IV)
            };
            encryptedPayloadJson = JsonConvert.SerializeObject(dataObject, settings);
            encryptedPayloadToken = Base64UrlEncode(Encoding.UTF8.GetBytes(encryptedPayloadJson));
            token = headerToken + "." + encryptedPayloadToken;

            return token;
        }

        public static object Decrypt(string encryptedJson, RsaKeyParameters privateKey, Type runtimeJsonClass)
        {
            if (Common.CheckString(encryptedJson))
                throw new Exception("Jwe to decrypt null");
            if (privateKey == null)
                throw new Exception("Private key to decrypt secret key null");
            if (runtimeJsonClass == null)
                throw new Exception("Runtime type null");

            IAsymmetricBlockCipher rsaOaep = null;
            //JsonSerializerSettings settings = null;
            JObject header       = null;
            // aes key and iv
            byte[] aesKeyBytes = null;
            byte[] aesIvBytes = null;
            byte[] encryptedKey = null;
            byte[] encryptedIv           = null;
            string encryptedPayload       = null;

            string[] segments = encryptedJson.Split('.');
            if (segments.Length != 2)
                throw new Exception("Can't map with system has 2 segment: header and payload");
            // extract info: header (key, iv) and payload
            header = JObject.Parse(Encoding.UTF8.GetString(Base64UrlDecode(segments[0])));
            encryptedKey = Base64UrlDecode(header["key"].ToString());
            encryptedIv = Base64UrlDecode(header["iv"].ToString());
            encryptedPayload = Encoding.UTF8.GetString(Base64UrlDecode(segments[1]));
            // check header alg
            if (!header["alg"].ToString().Equals("RSA-OAEP", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Not found head algo: RSA-OAEP");
            }
            // check header encrypt mode
            if (!header["enc"].ToString().Equals("AES256", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Not found head encypt: AES256");
            }
            // decrypt to get symmetric key
            rsaOaep = new OaepEncoding(new RsaEngine());
            rsaOaep.Init(false, new ParametersWithRandom(privateKey, seed));
            //rsaOaep.Init(false, privateKey);
            aesKeyBytes = rsaOaep.ProcessBlock(encryptedKey, 0, encryptedKey.Length);
            aesIvBytes = rsaOaep.ProcessBlock(encryptedIv, 0, encryptedIv.Length);
            // decrypt json
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new EncryptedStringPropertyResolver(aesKeyBytes, aesIvBytes)
            };

            return JsonConvert.DeserializeObject(encryptedPayload, runtimeJsonClass, settings);
        }

    }

    // copy from https://stackoverflow.com/questions/29196809/how-can-i-encrypt-selected-properties-when-serializing-my-objects
    [AttributeUsage(AttributeTargets.Property)]
    public class JsonEncryptAttribute : Attribute
    {
    }

    public class EncryptedStringPropertyResolver : DefaultContractResolver
    {
        private byte[] encryptionKeyBytes;
        private byte[] ivBytes;

        public EncryptedStringPropertyResolver(byte[] secretKeyBytes, byte[] ivBytes)
        {
            if (secretKeyBytes == null)
                throw new ArgumentNullException("encryptionKey");

            //this.encryptionKeyBytes = secretKeyBytes;
            this.ivBytes = ivBytes;
            // Hash the key to ensure it is exactly 256 bits long, as required by AES-256
            using (SHA256Managed sha = new SHA256Managed())
            {
                this.encryptionKeyBytes =
                    sha.ComputeHash(secretKeyBytes);
            }
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);

            // Find all string properties that have a [JsonEncrypt] attribute applied
            // and attach an EncryptedStringValueProvider instance to them
            foreach (JsonProperty prop in props.Where(p => p.PropertyType == typeof(string)))
            {
                PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
                if (pi != null && pi.GetCustomAttribute(typeof(JsonEncryptAttribute), true) != null)
                {
                    prop.ValueProvider =
                        new EncryptedStringValueProvider(pi, encryptionKeyBytes, ivBytes);
                }
            }

            return props;
        }

        class EncryptedStringValueProvider : IValueProvider
        {
            PropertyInfo targetProperty;
            private byte[] encryptionKey;
            private byte[] iv;

            public EncryptedStringValueProvider(PropertyInfo targetProperty, byte[] encryptionKey, byte[] iv)
            {
                this.targetProperty = targetProperty;
                this.encryptionKey = encryptionKey;
                this.iv = iv;
            }

            // GetValue is called by Json.Net during serialization.
            // The target parameter has the object from which to read the unencrypted string;
            // the return value is an encrypted string that gets written to the JSON
            public object GetValue(object target)
            {
                string value = (string)targetProperty.GetValue(target);
                byte[] buffer = Encoding.UTF8.GetBytes(value);
                using (MemoryStream inputStream = new MemoryStream(buffer, false))
                using (MemoryStream outputStream = new MemoryStream())
                using (AesManaged aes = new AesManaged { Key = encryptionKey, IV = iv })
                {
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                    {
                        inputStream.CopyTo(cryptoStream);
                    }

                    return Convert.ToBase64String(outputStream.ToArray());
                }
            }

            // SetValue gets called by Json.Net during deserialization.
            // The value parameter has the encrypted value read from the JSON;
            // target is the object on which to set the decrypted value.
            public void SetValue(object target, object value)
            {
                byte[] buffer = Convert.FromBase64String((string)value);

                using (MemoryStream inputStream = new MemoryStream(buffer, false))
                using (MemoryStream outputStream = new MemoryStream())
                using (AesManaged aes = new AesManaged { Key = encryptionKey, IV = iv })
                {
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
                    {
                        cryptoStream.CopyTo(outputStream);
                    }

                    string decryptedValue = Encoding.UTF8.GetString(outputStream.ToArray());
                    targetProperty.SetValue(target, decryptedValue);
                }
            }

        }
    }
}
