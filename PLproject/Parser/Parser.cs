using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    class Parser
    {
        private LexicalAnalyser lex;

        public Parser(string Program)
        {
            lex = new LexicalAnalyser(Program);
        }
        public bool Expect(params TokenKind[] t)
        {
            Token tmp = lex.GetNextToken();
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == tmp.Tok)
                    return true;
            }
            return false;
        }
        public bool program()
        {
            return ss();
        }
        public bool ss()
        {
            if (s())
            {
                if (Expect(TokenKind.EOF))
                {
                    return true;
                }
                else
                {
                    lex.UngetToken();//Looking forward to determine if the Sequence of statements is finished
                    if (Expect(TokenKind.ENDFOR, TokenKind.ENDIF, TokenKind.ELSE))
                    {
                        lex.UngetToken();
                        return true;
                    }
                    lex.UngetToken();
                    return ss();
                }
            }
            else
                return false;

        }
        public bool s()
        {
            Token tok = lex.GetNextToken();
            switch (tok.Tok)
            {
                case TokenKind.PRINT:
                    return Print();
                case TokenKind.ID:
                    return ASSIGNMENT();
                case TokenKind.IF:
                    return IF();
                case TokenKind.FOR:
                    return FOR();
                default:
                    lex.UngetToken();
                    return false;
            }
        }
        public bool Print()
        {
            return E();
        }
        public bool E()
        {
            if (T())
            {
                return NT();
            }
            return false;
        }
        public bool T()
        {
            if (F())
                return NF();
            return false;
        }
        public bool NT()
        {
            if (Expect(TokenKind.MINUS, TokenKind.PLUS))
            {
                if (T())
                    return NT();
                return false;
            }
            else
            {
                lex.UngetToken();
                return true;
            }
        }
        public bool F()
        {
            if (U())
                return N();
            return false;
        }
        public bool NF()
        {
            if (Expect(TokenKind.MULT, TokenKind.DIVID))
            {
                if (F())
                    return NF();
                return false;
            }
            else
            {
                lex.UngetToken();
                return true;
            }
        }
        public bool U()
        {
            if (Expect(TokenKind.MINUS, TokenKind.PLUS))
                return true;
            else
            {
                lex.UngetToken();
                return true;
            }
        }
        public bool N()
        {
            Token t = lex.GetNextToken();
            switch (t.Tok)
            {
                case TokenKind.ID:
                    return true;
                case TokenKind.NUM:
                    return true;
                case TokenKind.LPAR:
                    if (E())
                    {
                        if (Expect(TokenKind.RPAR))
                            return true;
                        else
                        {
                            lex.UngetToken();
                            return false;
                        }
                    }
                    else
                        return false;
                default:
                    lex.UngetToken();
                    return false;
            }
        }
        public bool FOR()
        {
            if (Expect(TokenKind.ID))
            {
                if (ASSIGNMENT())
                {
                    if (Expect(TokenKind.TO))
                    {
                        if (E())
                        {
                            if (Expect(TokenKind.DO))
                            {
                                if (ss())
                                {
                                    if (Expect(TokenKind.ENDFOR))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        lex.UngetToken();
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (Expect(TokenKind.ENDFOR))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        lex.UngetToken();
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                lex.UngetToken();
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        lex.UngetToken();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                lex.UngetToken();
                return false;
            }
        }
        public bool IF()
        {
            if (Bool_Exp())
            {
                if (Expect(TokenKind.THEN))
                {
                    if (ss())
                    {
                        if (Expect(TokenKind.ELSE))
                        {
                            if (ss())
                            {
                                if (Expect(TokenKind.ENDIF))
                                {
                                    return true;
                                }
                                else
                                {
                                    lex.UngetToken();
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            lex.UngetToken();
                            if (Expect(TokenKind.ENDIF))
                            {
                                return true;
                            }
                            else
                            {
                                lex.UngetToken();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (Expect(TokenKind.ENDIF))
                        {
                            return true;
                        }
                        else
                        {
                            lex.UngetToken();
                            return false;
                        }
                    }
                }
                else
                {
                    lex.UngetToken();
                    return false;
                }
            }
            else
                return false;
        }
        public bool Bool_Exp()
        {
            if (E())
            {
                if (Expect(TokenKind.BIGGER, TokenKind.SMALLER, TokenKind.ASSIGNMENT, TokenKind.NOTEQUAL, TokenKind.BIGGEROREQUAL, TokenKind.SMALLEROREQUAL))
                {
                    return E();
                }
                else
                {
                    lex.UngetToken();
                    return false;
                }
            }
            else
                return false;
        }
        public bool ASSIGNMENT()
        {

            if (Expect(TokenKind.ASSIGNMENT))
            {
                return E();
            }
            else
            {
                lex.UngetToken();
                return false;
            }
        }
    }
}
