using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.test
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
