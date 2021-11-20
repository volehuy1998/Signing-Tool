using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using SigningCore.test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SigningCore.test
{
    public class UserInfo
    {
        public string UserName { get; set; }

        [JsonEncrypt]
        public string UserPassword { get; set; }

        public string FavoriteColor { get; set; }

        [JsonEncrypt]
        public string CreditCardNumber { get; set; }
    }

    public class JsonTestCase : AbstractTestCase
    {
        public override void Test()
        {
            this.TestSign();
            this.TestCrypt_Sym();
        }

        protected static JObject FakePayload()
        {
            JObject payloadJObj = new JObject();

            DateTime issued = DateTime.Now;
            DateTime expire = DateTime.Now.AddHours(10);
            payloadJObj.Add("issued", issued.ToString());
            payloadJObj.Add("expire", issued.ToString());

            return payloadJObj;
        }

        protected void TestSign()
        {
            bool result = false;
            try
            {
                JObject payloadJObj = FakePayload();

                // generate JWT
                string jwtToken = SigningCore.Json.Sign(payloadJObj.ToString(), Common.PfxFile, Common.PfxPwd);

                // get payload, verify from JWT
                string payload = SigningCore.Json.Decode(jwtToken);
                result = true;
            }
            catch (Exception ex)
            {
                Common.Show(ex.ToString(), ConsoleColor.Yellow);
            }

            Common.ShowResult(result, MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
        }

        protected void TestCrypt_Sym()
        {
            bool result = false;
            try
            {
                UserInfo user = new UserInfo
                {
                    UserName = "jschmoe",
                    UserPassword = "Hunter2",
                    FavoriteColor = "atomic tangerine",
                    CreditCardNumber = "1234567898765432",
                };
                UserInfo decryptedUser = null;
                RsaKeyParameters publicKey = null;
                RsaKeyParameters privateKey = null;
                Pkcs12Store pkcs12Store = null;

                // encrypt
                pkcs12Store = Helper.GetPkcs12Store(Common.PfxFile, Common.PfxPwd);
                string keyAlias = Helper.GetAliasFromPkcs12Store(pkcs12Store);
                publicKey = pkcs12Store.GetCertificate(keyAlias).Certificate.GetPublicKey() as RsaKeyParameters;
                string jwe = Json.Encrypt(user, publicKey);

                // decrypt
                privateKey = pkcs12Store.GetKey(keyAlias).Key as RsaKeyParameters;
                decryptedUser = Json.Decrypt<UserInfo>(jwe, privateKey);
                if (!user.UserName.Equals(decryptedUser.UserName))
                {
                    throw new Exception($"Json decrypt fail with expected username is {user.UserName} but actual is {decryptedUser.UserName}");
                }
                else if (!user.UserPassword.Equals(decryptedUser.UserPassword))
                {
                    throw new Exception($"Json decrypt fail with expected pwd is {user.UserPassword} but actual is {decryptedUser.UserPassword}");
                }
                else if (!user.FavoriteColor.Equals(decryptedUser.FavoriteColor))
                {
                    throw new Exception($"Json decrypt fail with expected color is {user.FavoriteColor} but actual is {decryptedUser.FavoriteColor}");
                }
                else if (!user.CreditCardNumber.Equals(decryptedUser.CreditCardNumber))
                {
                    throw new Exception($"Json decrypt fail with expected credit-card is {user.CreditCardNumber} but actual is {decryptedUser.CreditCardNumber}");
                }
                result = true;
            }
            catch (Exception ex)
            {
                Common.Show(ex.ToString(), ConsoleColor.Yellow);
            }

            Common.ShowResult(result, MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
        }
    }
}
