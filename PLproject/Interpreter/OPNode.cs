using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class OPNode : Node
    {
        private char op;
        private Node left, right;

        public OPNode(char p, Node l, Node r)
        {
            op = p;
            left = l;
            right = r;
        }

        public override int Eval()
        {
            int n1, n2;
            n1 = left.Eval();
            n2 = right.Eval();
            if (op == '+')
                return n1 + n2;
            else
                if (op == '*')
                    return n1 * n2;
                else
                    if (op == '-')
                        return n1 - n2;
                    else
                        return n1 / n2;
        }
    }
}
