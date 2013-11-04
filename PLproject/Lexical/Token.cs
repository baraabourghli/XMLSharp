using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class Token
    {
        public int pos;

        private TokenKind tok;

        public TokenKind Tok
        {
            get { return tok; }
            set { tok = value; }
        }


        private string val;

        public string Val
        {
            get { return val; }
            set { val = value; }
        }


        public Token()
        {
            Tok = TokenKind.ERROR;
            Val = "";
        }

        public Token(TokenKind t)
        {
            Tok = t;
            Val = "";
        }

        public Token(TokenKind t, int p)
        {
            Tok = t;
            Val = "";
            pos = p;
        }

        public Token(TokenKind t, string v)
        {
            Tok = t;
            Val = v;
        }

        public Token(TokenKind t, string v, int p)
        {
            Tok = t;
            Val = v;
            pos = p;
        }
    }
}
