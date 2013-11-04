using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class Statments
    {
        LinkedList<Statment> Program;
        public Statments()
        {
            Program = new LinkedList<Statment>();
        }
        public void ADD(Statment s)
        {
            if (s != null)
                Program.AddLast(s);
        }
        public void Exc()
        {
            for (int i = 0; i < Program.Count; i++)
            {
                Program.ElementAt<Statment>(i).Exc();
            }
        }
    }
}
