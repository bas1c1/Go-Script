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
        OBJECT,

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
        ENUM,
        ASYNC,
        AWAIT,
        CATCH,
        LAMBDA,
        STATEMENT,

        STAREQ,
        SLASHEQ,
        PLUSEQ,
        MINUSEQ,

        DOT,
        DDOT,
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
