using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang
{
    enum TokenType
    {
        NUMBER,
        WORD,
        TEXT,
        OBJ,

        PRINT,
        IF,
        ELSE,
        WHILE,
        FOR,
        DO,
        BREAK,
        CONTINUE,
        DEF,
        CLASS,
        RUN_CLASS,
        RETURN,
        USE,

        STAR,
        SLASH,
        PLUS,
        MINUS,
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
