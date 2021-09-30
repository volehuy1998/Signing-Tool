using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.X509;

namespace List_personal_cert
{
    class Program
    {
        static void console()
        {
            //X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            //store.Open(OpenFlags.ReadOnly);

            //foreach (X509Certificate2 certificate in store.Certificates)
            //{
            //    Console.WriteLine(certificate.Issuer);
            //}
        }

        static void dialog()
        {
            Console.WriteLine("------- Console call windows dialog -------");
            var store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var collection = store.Certificates;
            var cert = X509Certificate2UI.SelectFromCollection(collection, "Select", "Select a certificate to sign", X509SelectionFlag.MultiSelection);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{            //========chọn cert tu usb token
        //    X509Store store = new X509Store(StoreLocation.CurrentUser);
        //    store.Open(OpenFlags.ReadOnly);
        //    X509Certificate2Collection sel = X509Certificate2UI.SelectFromCollection(store.Certificates, null, null, X509SelectionFlag.SingleSelection);
        //    X509Certificate2 cert = sel[0];
        //    Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
        //    Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] {cp.ReadCertificate(cert.RawData)};
        //    IExternalSignature es = new X509Certificate2Signature(cert, "SHA-1");
        //    X509Certificate2Signature es1 = new X509Certificate2Signature(cert, "SHA-1");
        //    PdfReader reader = new PdfReader("test.pdf");
        //    using (FileStream fout = new FileStream("test_signed.pdf", FileMode.Create, FileAccess.ReadWrite))
        //    {
        //        using (PdfStamper stamper = PdfStamper.CreateSignature(reader, fout, '\0', null, true))
        //        {
        //            PdfSignatureAppearance appearance = stamper.SignatureAppearance;
        //            appearance.Reason = "abc";
        //            appearance.Location = "cab";
        //            appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(10, 10, 170, 60), reader.NumberOfPages, "Signed");
        //            MakeSignature.SignDetached(appearance, es1, chain, null, null, null, 0, CryptoStandard.CMS);
        //            stamper.Close();
        //        }
        //    }
        //}


            static void Main(string[] args)
            {
                // step 1. generate personal certificate from https://stackoverflow.com/a/201277
                // step 2. install with Current user

                dialog();


            }
        }
    }
