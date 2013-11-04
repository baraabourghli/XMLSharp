using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class IDNode : Node
    {
        string name;
        Node Val;
        public IDNode(string n, Node val)
        {
            name = n;
            Val = val;
        }
        public override int Eval()
        {
            return Val.Eval();
        }
    }
}
