using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PLproject
{
    sealed class TNode
    {
        public string Name
        { get; set; }
        public Node valu
        { get; set; }
        public TNode(string na)
        {
            Name = na;
        }
        public TNode(string na, Node val)
        {
            Name = na;
            valu = val;
        }
    }

    class SymbolTable
    {
        LinkedList<TNode> Table;
        public bool insert(string VarName, Node Val)
        {
            TNode tmpNode = new TNode(VarName, Val);
            if (!Table.Contains(tmpNode))
            {
                Table.AddLast(tmpNode);
                return true;
            }
            else
            {
                MessageBox.Show("Error the variable name " + VarName + " is taken");
                return false;
            }
        }
        public bool Modify(string VarName, Node Val)
        {
            TNode tmp = new TNode(VarName);
            for (int i = 0; i < Table.Count; i++)
            {
                if (Table.ElementAt<TNode>(i).Name == VarName)
                {
                    Table.ElementAt<TNode>(i).valu = Val;
                    return true;
                }
            }
            return false;
        }
        public TNode Get(string varName)
        {
            TNode tmp = new TNode(varName);
            for (int i = 0; i < Table.Count; i++)
            {
                if (Table.ElementAt<TNode>(i).Name == varName)
                {
                    return Table.ElementAt<TNode>(i);
                }
            }
            return null;
        }
        public SymbolTable()
        {
            Table = new LinkedList<TNode>();
        }
    }
}
