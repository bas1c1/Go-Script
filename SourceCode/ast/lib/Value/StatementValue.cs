using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class StatementValue : Value
    {
        private Statement value;

        public StatementValue(Statement value)
        {
            this.value = value;
        }

        public Statement asStatement()
        {
            return value;
        }

        public char asChar()
        {
            throw new NotImplementedException();
        }

        public double asDouble()
        {
            throw new NotImplementedException();
        }

        public int asNumber()
        {
            throw new NotImplementedException();
        }

        public string asString()
        {
            throw new NotImplementedException();
        }

        public object asObject()
        {
            return value;
        }

        public TokenType type()
        {
            return TokenType.LAMBDA;
        }
    }
}
