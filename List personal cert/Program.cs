using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace List_personal_cert
{
    class Program
    {
        static void Main(string[] args)
        {
            // step 1. generate personal certificate from https://stackoverflow.com/a/201277
            // step 2. install with Current user

            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 certificate in store.Certificates)
            {
                Console.WriteLine(certificate.Issuer);
            }
        }
    }
}
