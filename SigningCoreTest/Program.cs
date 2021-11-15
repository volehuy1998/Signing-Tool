using SigningCore.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigningCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester tester = new Tester();
            tester.Add(typeof(XmlTestCase));
            tester.Add(typeof(CmsTestCase));
            tester.Add(typeof(JsonTestCase));

            tester.Run();
        }
    }
}
