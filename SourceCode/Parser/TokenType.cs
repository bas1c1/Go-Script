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
        LDEF,
        CLASS,
        RUN_CLASS,
        INST_ENUM,
        RETURN,
        USE,
        ENUM,
        ASYNC,
        AWAIT,
        CATCH,
        LAMBDA,
        STATEMENT,
        SWITCH,
        CASE,
        TYPEDEF,

        STAREQ,
        SLASHEQ,
        PLUSEQ,
        MINUSEQ,

        DOT,
        DDOT,
        DDOTEQ,
        STAR,
        SLASH,
        BIN,
        XOR,
        LOGNOT,
        PERCENT,
        STARSTAR,
        PLUS,
        MINUS,
        INC,
        DEC,
        EXCL,
        EXCLEQ,
        EQ,
        EQCON,
        STARCON,
        EQEQ,
        LT,
        LTEQ,
        GTEQ,
        GT,
        DOG,

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
