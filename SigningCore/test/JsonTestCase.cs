using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
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

        protected void TestSign()
        {
            bool result = false;
            try
            {
                // sign
                JObject payloadJObj = new JObject();
                DateTime issued = DateTime.Now;
                DateTime expire = DateTime.Now.AddHours(10);
                payloadJObj.Add("issued", issued.ToString());
                payloadJObj.Add("expire", issued.ToString());

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
            try
            {
                UserInfo user = new UserInfo
                {
                    UserName = "jschmoe",
                    UserPassword = "Hunter2",
                    FavoriteColor = "atomic tangerine",
                    CreditCardNumber = "1234567898765432",
                };

                // Note: in production code you should not hardcode the encryption
                // key into the application-- instead, consider using the Data Protection 
                // API (DPAPI) to store the key.  .Net provides access to this API via
                // the ProtectedData class.

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Formatting = Formatting.Indented;
                settings.ContractResolver = new EncryptedStringPropertyResolver("My-Sup3r-Secr3t-Key");

                Console.WriteLine("----- Serialize -----");
                string json = JsonConvert.SerializeObject(user, settings);
                Console.WriteLine(json);
                Console.WriteLine();

                Console.WriteLine("----- Deserialize -----");
                UserInfo user2 = JsonConvert.DeserializeObject<UserInfo>(json, settings);

                Console.WriteLine("UserName: " + user2.UserName);
                Console.WriteLine("UserPassword: " + user2.UserPassword);
                Console.WriteLine("FavoriteColor: " + user2.FavoriteColor);
                Console.WriteLine("CreditCardNumber: " + user2.CreditCardNumber);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
