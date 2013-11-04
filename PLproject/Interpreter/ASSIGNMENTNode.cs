using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class ASSIGNMENTNode : Statment
    {
        public string IDName;
        public Node E;
        public int val;
        public ASSIGNMENTNode(string IDN, Node exp)
        {
            IDName = IDN;
            E = exp;
        }
        public override void Exc()
        {
            val = E.Eval();
        }
    }
}
