using Core.test;
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
            tester.Add(typeof(CmsTesterCase));

            tester.Run();
        }
    }
}
