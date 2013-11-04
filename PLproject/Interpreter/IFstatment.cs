using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class IFstatment : Statment
    {
        Statments ifSS, elseSS;
        Node boolean;
        bool ISelse;
        public IFstatment(Node bol, Statments statments, bool isElse)
        {
            ISelse = isElse;
            boolean = bol;
            ifSS = statments;
        }
        public IFstatment(Node bol, Statments statments, bool isElse, Statments ElseStat)
        {
            elseSS = ElseStat;
            ISelse = isElse;
            boolean = bol;
            ifSS = statments;
        }
        public override void Exc()
        {
            int cond = boolean.Eval();
            if (cond != 0)
            {
                if (ifSS != null)
                    ifSS.Exc();
            }
            else
                if (ISelse == true)
                {
                    if (elseSS != null)
                        elseSS.Exc();
                }
        }
    }
}
