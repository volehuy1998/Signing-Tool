using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.test
{
    public class Tester
    {
        private List<Type> objectTesterTypes;

        public Tester()
        {
            this.objectTesterTypes = new List<Type>();
        }

        public void Add(Type testerType)
        {
            objectTesterTypes.Add(testerType);
        }

        public void Run()
        {
            foreach (Type objectType in this.objectTesterTypes)
            {
                AbstractTestCase instance = Activator.CreateInstance(objectType) as AbstractTestCase;
                if (instance != null)
                {
                    instance.Test();
                }
            }
        }
    }
}
