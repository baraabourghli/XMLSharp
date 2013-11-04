using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLproject
{
    enum TokenKind
    {
        EOF, NUM, ID, FOR, IF, ELSE, ENDIF, ENDFOR,
        PRINT, THEN, TO, DO, PLUS, MULT, BIGGER, BIGGEROREQUAL,
        SMALLER, NOTEQUAL, SMALLEROREQUAL,
        LPAR, RPAR, ASSIGNMENT, ERROR, MINUS, DIVID
    }
}
