XMLSharp
========

A  parser for a programming language called XML# written in C#

-----------------------

the CFG for this parser:

PROGRAM -> <SS>

SS      -> <S> <SS>|epsilon

S          -> <Print>|<ASSIGNMENT>|<IF>|<FOR>

//

E          -> <T> <NT>

NT         -> + <T> <NT>|- <T> <NT>|epsilon

T          -> <F> <NF>

NF         -> * <F> <NF>|/ <F> <NF>|epsilon

F          -> <U> <N> 

N        -> <ID>|<NUM>|( <E> )

U        -> -|+|epsilon

//

IF         -> IF <BOOL_EXP> THEN <SS> ENDIF|IF<BOOL_EXP> THEN <SS> ELSE <SS> ENDIF

//

FOR         -> FOR ASSIGNMENT TO <E> DO <SS> ENDFOR

//

Print        -> Print <E>

BOOL_EXP-> <E> > <E>|<E> < <E>|<E> = <E>|<E> <> <E>|<E> >= <E>
            |<E> <= <E>


ASSIGNMENT-> <ID> = <E>
