using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class LexicalAnalyser
    {
        private string text; //get the text from rich box
        private int pos; //the current location
        private string v;
        private int lastpos;
        public LexicalAnalyser(string t)
        {
            text = t;
            pos = 0;
            lastpos = 0;
        }
        private Token q0()
        {
            switch (text[pos])
            {
                case '<':
                    pos++;
                    return q34();
                case '>':
                    pos++;
                    return q38();
                case '(':
                    pos++;
                    return q41();
                case ')':
                    pos++;
                    return q42();
                case '=':
                    pos++;
                    return q43();
                case '+':
                    pos++;
                    return q44();
                case '*':
                    pos++;
                    return q45();
                case '/':
                    pos++;
                    return q46();
                case '-':
                    pos++;
                    return q47();
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    v = Convert.ToString(text[pos]);
                    pos++;
                    return q2();
                case 'a':
                case 'b':
                case 'c':
                case 'g':
                case 'h':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'q':
                case 'r':
                case 's':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                case 'A':
                case 'B':
                case 'C':
                case 'G':
                case 'H':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'Q':
                case 'R':
                case 'S':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    v = Convert.ToString(text[pos]);
                    pos++;
                    return q48();
                case 'f':
                case 'F':
                    v = Convert.ToString(text[pos]);
                    pos++;
                    return q4();
                case 'i':
                case 'I':
                    v = Convert.ToString(text[pos]);
                    pos++;
                    return q7();
                case 'e':
                case 'E':
                    v = Convert.ToString(text[pos]);
                    pos++;
                    return q9();
                case 'p':
                case 'P':
                    v = Convert.ToString(text[pos]);
                    pos++;
                    return q20();
                case 't':
                case 'T':
                    v = Convert.ToString(text[pos]);
                    pos++;
                    return q25();
                case 'd':
                case 'D':
                    v = Convert.ToString(text[pos]);
                    pos++;
                    return q30();
                case '\n':
                    pos++;
                    return GetNextToken();
                case '\r':
                    pos++;
                    return GetNextToken();
                case '\t':
                    pos++;
                    return GetNextToken();
                case '{':
                    pos++;
                    return GetNextToken();
                case '}':
                    pos++;
                    return GetNextToken();
                default:
                    pos++;
                    return new Token(TokenKind.ERROR, lastpos);
            }
        }
        private Token q1()
        {
            return new Token(TokenKind.LPAR, lastpos);
        }
        private Token q2()
        {
            if (pos >= text.Length)
                return q3();

            if (text[pos] >= '0' && text[pos] <= '9')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q2();
            }
            else
                return q3();
        }
        private Token q3()
        {
            return new Token(TokenKind.NUM, v, lastpos);
        }
        private Token q4()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'o' || text[pos] == 'O')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q5();
            }
            return q48();
        }
        private Token q5()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'r' || text[pos] == 'R')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q6();
            }
            else
                return q48();
        }
        private Token q6()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.FOR, v, lastpos);
            if (!(text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z'))
            {
                return new Token(TokenKind.FOR, v, lastpos);
            }
            else
                return q48();
        }
        private Token q7()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'f' || text[pos] == 'F')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q8();
            }
            else
                return q48();
        }
        private Token q8()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.IF, v, lastpos);
            if (!(text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z'))
            {
                return new Token(TokenKind.IF, v, lastpos);
            }
            else
                return q48();

        }
        private Token q9()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'l' || text[pos] == 'L')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q10();
            }
            else if (text[pos] == 'n' || text[pos] == 'N')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q13();
            }
            else
                return q48();
        }
        private Token q10()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'S' || text[pos] == 's')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q11();
            }
            else
                return q48();
        }
        private Token q11()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'e' || text[pos] == 'E')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q12();
            }
            else
                return q48();
        }
        private Token q12()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.ELSE, v, lastpos);
            if (!(text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z'))
            {
                return new Token(TokenKind.ELSE, v, lastpos);
            }
            else
                return q48();
        }
        private Token q13()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'D' || text[pos] == 'd')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q14();
            }
            else
                return q48();
        }
        private Token q14()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'i' || text[pos] == 'I')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q15();
            }
            else if (text[pos] == 'f' || text[pos] == 'F')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q17();
            }
            else
                return q48();
        }
        private Token q15()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'f' || text[pos] == 'F')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q16();
            }
            else
                return q48();
        }
        private Token q16()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.ENDIF, v, lastpos);
            if (!(text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z'))
            {
                return new Token(TokenKind.ENDIF, v, lastpos);
            }
            else
                return q48();
        }
        private Token q17()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'o' || text[pos] == 'O')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q18();
            }
            else
                return q48();
        }
        private Token q18()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'r' || text[pos] == 'R')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q19();
            }
            else
                return q48();
        }
        private Token q19()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.ENDFOR, v, lastpos);
            if (!(text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z'))
            {
                return new Token(TokenKind.ENDFOR, v, lastpos);
            }
            else
                return q48();
        }
        private Token q20()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'R' || text[pos] == 'r')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q21();
            }
            else
                return q48();
        }
        private Token q21()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'i' || text[pos] == 'I')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q22();
            }
            else
                return q48();
        }
        private Token q22()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'n' || text[pos] == 'N')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q23();
            }
            else
                return q48();
        }
        private Token q23()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 't' || text[pos] == 'T')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q24();
            }
            else
                return q48();
        }
        private Token q24()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.PRINT, v, lastpos);
            if (!(text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z'))
            {
                return new Token(TokenKind.PRINT, v, lastpos);
            }
            else
                return q48();
        }
        private Token q25()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'H' || text[pos] == 'h')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q26();
            }
            else if (text[pos] == 'o' || text[pos] == 'O')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q29();
            }
            else
                return q48();
        }
        private Token q26()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'e' || text[pos] == 'E')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q27();
            }
            else
                return q48();
        }
        private Token q27()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'N' || text[pos] == 'n')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q28();
            }
            else
                return q48();
        }
        private Token q28()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.THEN, v, lastpos);
            if (!(text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z'))
            {
                return new Token(TokenKind.THEN, v, lastpos);
            }
            else
                return q48();
        }
        private Token q29()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.TO, v, lastpos);
            if (!(text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z'))
            {
                return new Token(TokenKind.TO, v, lastpos);
            }
            else
                return q48();
        }
        private Token q30()
        {
            if (pos >= text.Length)
                return q48();
            if (text[pos] == 'o' || text[pos] == 'O')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q31();
            }
            else
                return q48();
        }
        private Token q31()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.DO, v, lastpos);
            if (!(text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z'))
            {
                return new Token(TokenKind.DO, v, lastpos);
            }
            else
                return q48();
        }
        private Token q34()
        {
            if (pos >= text.Length)
                return q37();
            if (text[pos] == '>')
            {
                pos++;
                return q36();
            }
            else if (text[pos] == '=')
            {
                pos++;
                return q35();
            }
            return q37();
        }
        private Token q35()
        {
            return new Token(TokenKind.SMALLEROREQUAL, lastpos);
        }
        private Token q36()
        {
            return new Token(TokenKind.NOTEQUAL, lastpos);
        }
        private Token q37()
        {
            return new Token(TokenKind.SMALLER, lastpos);
        }
        private Token q38()
        {
            if (pos >= text.Length)
                return q40();
            if (text[pos] == '=')
            {
                pos++;
                return q39();
            }
            return q40();
        }
        private Token q39()
        {
            return new Token(TokenKind.BIGGEROREQUAL, lastpos);
        }
        private Token q40()
        {
            return new Token(TokenKind.BIGGER, lastpos);
        }
        private Token q41()
        {
            return new Token(TokenKind.LPAR, lastpos);
        }
        private Token q42()
        {
            return new Token(TokenKind.RPAR, lastpos);
        }
        private Token q43()
        {
            return new Token(TokenKind.ASSIGNMENT, lastpos);
        }
        private Token q44()
        {
            return new Token(TokenKind.PLUS, lastpos);
        }
        private Token q45()
        {
            return new Token(TokenKind.MULT, lastpos);
        }
        private Token q46()
        {
            if (pos >= text.Length)
                return new Token(TokenKind.DIVID, lastpos);
            else if (text[pos] == '/')
            {
                return q50();
            }
            else
                return new Token(TokenKind.DIVID, lastpos);
        }
        private Token q47()
        {
            return new Token(TokenKind.MINUS, lastpos);
        }
        private Token q48()
        {
            if (pos >= text.Length)
                return q49();

            if (text[pos] >= '0' && text[pos] <= '9' || text[pos] >= 'a' && text[pos] <= 'z' || text[pos] >= 'A' && text[pos] <= 'Z')
            {
                v = v + Convert.ToString(text[pos]);
                pos++;
                return q48();
            }
            else
                return q49();
        }
        private Token q49()
        {
            return new Token(TokenKind.ID, v, lastpos);
        }
        private Token q50()
        {
            if (!(pos >= text.Length))
            {
                if (text[pos] != '\r')
                {
                    pos++;
                    return q50();
                }
            }
            if (pos >= text.Length)
                return new Token(TokenKind.EOF, lastpos);
            else
                return
                    q0();
        }
        public Token GetNextToken()
        {
            lastpos = pos;
            while (pos < text.Length && text[pos] == ' ')
                pos++;
            if (pos >= text.Length)
                return new Token(TokenKind.EOF, lastpos);
            else
                return q0();
        }
        public void UngetToken()
        {
            pos = lastpos;
        }
    }
}