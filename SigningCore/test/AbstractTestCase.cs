using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigningCore.test
{
    public abstract class AbstractTestCase
    {
        public AbstractTestCase()
        {
            Common.Prepare();
        }

        public abstract void Test();
    }
}
