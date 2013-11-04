using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PLproject
{
    class Print : Statment
    {
        Node e;
        public Print(Node Exp)
        {
            e = Exp;
        }
        public override void Exc()
        {
            int i = e.Eval();
            MessageBox.Show(i.ToString());
        }
    }
}
