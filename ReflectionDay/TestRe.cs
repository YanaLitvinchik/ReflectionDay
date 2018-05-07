using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDay
{
    class TestRe
    {
        int a;
        public int Data { get; set; }
        public int Plus(int a, int b)
        {
            return a + b;
        }


        internal object GetMethods(BindingFlags bindingFlags)
        {
            throw new NotImplementedException();
        }
    }
}
