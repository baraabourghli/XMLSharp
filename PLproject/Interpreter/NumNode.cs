using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class NumNode : Node
    {
        public int val;
        public NumNode(int a)
        {
            val = a;
        }
        public override int Eval()
        {
            return val;
        }
    }
}
