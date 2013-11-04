using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class FORStatment : Statment
    {
        ASSIGNMENTNode assign;
        Statments statments;
        Node E;
        public FORStatment(ASSIGNMENTNode a, Node n, Statments SS)
        {
            assign = a; E = n; statments = SS;
        }
        public override void Exc()
        {
            assign.Exc();
            int a = assign.val, n = E.Eval();
            int i = a;
            for (; i < n; i++)
            {
                statments.Exc();
            }
        }
    }
}
