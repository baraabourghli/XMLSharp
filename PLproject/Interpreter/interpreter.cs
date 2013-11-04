using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PLproject
{
    class interpreter
    {
        private LexicalAnalyser lex;
        private SymbolTable SymbolT;////
        private Parser parser;
        private Statments statments;
        public interpreter(string code)
        {
            lex = new LexicalAnalyser(code);
            SymbolT = new SymbolTable();
            parser = new Parser(code);
            statments = new Statments();
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
        public void Fire()
        {
            if (Phase1())
            {
                MessageBox.Show("The Program is syntactically correct");
                SS(ref statments);
                statments.Exc();
            }
            else
                MessageBox.Show("The Program is not syntactically correct");
        }
        public bool Phase1()
        {
            return parser.program();
        }
        public Statment SS(ref Statments ss)
        {
            Statment s1 = S();
            if (s1 != null)
            {
                ss.ADD(s1);
                if (Expect(TokenKind.EOF))
                {
                    return null;
                }
                else
                    lex.UngetToken();
                if (Expect(TokenKind.ENDFOR, TokenKind.ENDIF, TokenKind.ELSE))
                {
                    lex.UngetToken();
                    return s1;
                }
                else
                {
                    lex.UngetToken();
                    return SS(ref ss);
                }
            }
            return null;
        }
        public Statment S()
        {
            Token t = lex.GetNextToken();
            switch (t.Tok)
            {
                case TokenKind.PRINT:
                    lex.UngetToken();
                    return Print();
                case TokenKind.ID:
                    lex.UngetToken();
                    return ASSIGNMENT();
                case TokenKind.IF:
                    lex.UngetToken();
                    return IF();
                case TokenKind.FOR:
                    lex.UngetToken();
                    return FOR();
                default:
                    lex.UngetToken();
                    return null;
            }
        }/**/
        public Statment IF()
        {
            Statments ifstatments = new Statments(), elsestatments = new Statments();
            if (Expect(TokenKind.IF))
            {
                Node bol = BOOL_EXP();
                if (bol != null)
                {
                    if (Expect(TokenKind.THEN))
                    {

                        Statment ifss = SS(ref ifstatments);
                        if (Expect(TokenKind.ELSE))
                        {
                            Statment elsess = SS(ref elsestatments);
                            if (Expect(TokenKind.ENDIF))
                            {
                                return new IFstatment(bol, ifstatments, true, elsestatments);
                            }
                            else
                                lex.UngetToken();
                        }
                        else
                        {
                            lex.UngetToken();
                            if (Expect(TokenKind.ENDIF))
                                return new IFstatment(bol, ifstatments, false);
                            else
                                lex.UngetToken();
                        }
                    }
                    else
                        lex.UngetToken();
                }
            }
            else
                lex.UngetToken();
            return null;
        }
        public Statment Print()
        {
            if (Expect(TokenKind.PRINT))
            {
                Node e = E();
                if (e != null)
                {
                    return new Print(e);
                }
            }
            else
                lex.UngetToken();
            return null;
        }
        public Statment FOR()
        {
            Statments ForStatments = new Statments();
            if (Expect(TokenKind.FOR))
            {
                ASSIGNMENTNode assi = (ASSIGNMENTNode)ASSIGNMENT();
                if (assi != null)
                {
                    if (Expect(TokenKind.TO))
                    {
                        Node e = E();
                        if (e != null)
                        {
                            if (Expect(TokenKind.DO))
                            {
                                Statment ss = SS(ref ForStatments);
                                if (ss != null)
                                    if (Expect(TokenKind.ENDFOR))
                                    {
                                        return new FORStatment(assi, e, ForStatments);
                                    }
                                    else
                                        lex.UngetToken();
                            }
                            else
                                lex.UngetToken();
                        }
                    }
                    else
                        lex.UngetToken();
                }
            }
            else
                lex.UngetToken();
            return null;
        }
        public Node BOOL_EXP()
        {
            Node e1 = E();
            if (e1 != null)
            {
                string operation;
                Token t = lex.GetNextToken();
                switch (t.Tok)
                {
                    case TokenKind.ASSIGNMENT:
                        operation = "=";
                        break;
                    case TokenKind.BIGGER:
                        operation = ">";
                        break;
                    case TokenKind.BIGGEROREQUAL:
                        operation = ">=";
                        break;
                    case TokenKind.NOTEQUAL:
                        operation = "<>";
                        break;
                    case TokenKind.SMALLER:
                        operation = "<";
                        break;
                    case TokenKind.SMALLEROREQUAL:
                        operation = "<=";
                        break;
                    default:
                        lex.UngetToken();
                        return null;
                }
                Node e2 = E();
                if (e2 != null)
                    return new BoolNode(operation, e1, e2);
            }
            return null;
        }
        public Statment ASSIGNMENT()
        {
            Token T = lex.GetNextToken();
            if (T.Tok == TokenKind.ID)
            {
                string name = T.Val;
                T = lex.GetNextToken();
                if (T.Tok == TokenKind.ASSIGNMENT)
                {
                    Node Ex = E();
                    if (Ex != null)
                    {
                        if (SymbolT.insert(name, Ex))
                            return new ASSIGNMENTNode(name, Ex);
                        else
                        {
                            if (SymbolT.Modify(name, Ex))
                                return new ASSIGNMENTNode(name, Ex);
                        }
                    }
                }
            }
            return null;
        }
        public Node N()
        {
            int val;
            Token T = lex.GetNextToken();
            switch (T.Tok)
            {
                case TokenKind.ID:
                    TNode TN = SymbolT.Get(T.Val);
                    if (TN != null && (TN.valu != null))
                    {
                        return TN.valu;
                    }
                    return null;
                case TokenKind.NUM:
                    if (int.TryParse(T.Val, out  val))
                        return new NumNode(val);
                    return null;
                case TokenKind.LPAR:
                    Node E1 = E();
                    if (Expect(TokenKind.RPAR))
                        return E1;
                    lex.UngetToken();
                    return null;
                default:
                    lex.UngetToken();
                    return null;
            }
        }
        public Node U()
        {
            if (Expect(TokenKind.MINUS))
                return new NumNode(-1);
            else
            {
                lex.UngetToken();
                if (Expect(TokenKind.PLUS))
                    return new NumNode(+1);
                else
                    lex.UngetToken();
            }
            return null;
        }
        public Node F()
        {
            Node u1 = U();
            if (u1 != null)
            {
                Node n1 = N();
                if (n1 != null)
                    return new OPNode('*', u1, n1);
            }
            else
            {
                return N();
            }
            return null;
        }
        public Node NF(Node f1)
        {
            if (Expect(TokenKind.DIVID))
            {
                Node f2 = F();
                if (f2 != null)
                {
                    OPNode op = new OPNode('/', f1, f2);
                    Node nf = NF(op);
                    if (nf != null)
                        return nf;
                    else
                        return op;
                }
            }
            else
            {
                lex.UngetToken();
                if (Expect(TokenKind.MULT))
                {
                    Node f2 = F();
                    if (f2 != null)
                    {
                        OPNode op = new OPNode('*', f1, f2);
                        Node nf = NF(op);
                        if (nf != null)
                            return nf;
                        else
                            return op;
                    }
                }
                else
                    lex.UngetToken();
            }
            return null;
        }
        public Node T()
        {
            Node f1 = F();
            if (f1 != null)
            {
                if (Expect(TokenKind.MULT, TokenKind.DIVID))
                {
                    lex.UngetToken();
                    return NF(f1);
                }
                else
                {
                    lex.UngetToken();
                    return f1;
                }
            }
            return null;
        }
        public Node NT(Node t1)
        {
            if (Expect(TokenKind.MINUS))
            {
                Node t2 = T();
                if (t2 != null)
                {
                    OPNode op = new OPNode('-', t1, t2);
                    Node nt = NT(op);
                    if (nt != null)
                        return nt;
                    else
                        return op;
                }
                else
                    return null;
            }
            else
            {
                lex.UngetToken();
                if (Expect(TokenKind.PLUS))
                {
                    Node t2 = T();
                    if (t2 != null)
                    {
                        OPNode op = new OPNode('+', t1, t2);
                        Node nt = NT(op);
                        if (nt != null)
                            return nt;
                        else
                            return op;
                    }
                    else
                        return null;
                }
                else
                {
                    lex.UngetToken();
                    return null;
                }
            }
        }
        public Node E()
        {
            Node t1 = T();
            if (t1 != null)
            {
                if (Expect(TokenKind.PLUS, TokenKind.MINUS))
                {
                    lex.UngetToken();
                    return NT(t1);
                }
                else
                {
                    lex.UngetToken();
                    return t1;
                }
            }
            return null;
        }
        /*  
         * 
         */
    }
}
