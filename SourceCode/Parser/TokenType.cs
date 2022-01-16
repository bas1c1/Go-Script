using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang
{
    public enum TokenType
    {
        NUMBER,
        WORD,
        TEXT,
        OBJ,
        TRUE,
        FALSE,
        ARRAY,
        DICT,
        STACK,

        PRINT,
        IF,
        TO,
        ELSE,
        WHILE,
        TRY,
        FOR,
        FOREACH,
        DO,
        BREAK,
        CONTINUE,
        DEF,
        CLASS,
        RUN_CLASS,
        RETURN,
        USE,

        STAREQ,
        SLASHEQ,
        PLUSEQ,
        MINUSEQ,

        STAR,
        SLASH,
        PLUS,
        MINUS,
        INC,
        DEC,
        EXCL,
        EXCLEQ,
        EQ,
        EQEQ,
        LT,
        LTEQ,
        GTEQ,
        GT,

        BAR,
        BARBAR,
        AMP,
        AMPAMP,

        LPAREN,
        RPAREN,
        LBRAСKET,
        RBRACKET,
        LBRACE,
        RBRACE,
        COMMA,

        EOF,

    }
}
