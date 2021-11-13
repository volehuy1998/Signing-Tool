using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using SigningCore.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SigningCore.test
{
    public class JsonTestCase : AbstractTestCase
    {
        public override void Test()
        {
            this.TestSign();
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
    }
}
