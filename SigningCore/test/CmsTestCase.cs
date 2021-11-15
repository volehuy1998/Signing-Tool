using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SigningCore.test
{
    public class CmsTestCase : AbstractTestCase
    {
        public override void Test()
        {
            this.TestSign();
            this.TestSymCrypt();
        }

        protected void TestSign()
        {
            bool result = false;
            try
            {
                // sign
                SigningCore.Cms.BouncyCastle_SignCMS(Common.InputFile, Common.SignedCmsFile, Common.PfxFile, Common.PfxPwd);

                // verify
                System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert = Helper.GetMicrosoftCert();
                X509Certificate bouncycastleCert = DotNetUtilities.FromX509Certificate(microsoftCert);
                result = SigningCore.Cms.BouncyCastle_VerifyCMS(Common.SignedCmsFile, bouncycastleCert);
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

            try
            {
                byte[] aesKey = Helper.GenerateAesKey(192);

                SigningCore.Cms.BouncyCastle_EncryptCMS_Sym(Common.InputFile, Common.EncryptedFile, aesKey);
                SigningCore.Cms.BouncyCastle_DecryptCMS_Sym(Common.EncryptedFile, Common.DecryptedFile, aesKey);

                result = Helper.CompareFiles(Common.InputFile, Common.DecryptedFile);
            }
            catch (Exception ex)
            {
                Common.Show(ex.ToString(), ConsoleColor.Yellow);
            }

            Common.ShowResult(result, MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
        }
    }
}
