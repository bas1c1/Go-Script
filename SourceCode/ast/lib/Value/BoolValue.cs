using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class BoolValue : Value
    {
        private bool value;
        public static NumberValue ZERO = new NumberValue(0);

        public BoolValue(bool value)
        {
            this.value = value;
        }

        public double asDouble()
        {
            if (value == true)
            {
                return 1f;
            }
            else
            {
                return 0f;
            }
        }

        public int asNumber()
        {
            if (value == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public char asChar()
        {
            throw new Exception("can't do it");
        }

        public bool asBool()
        {
            return value;
        }

        public string asString()
        {
            return value.ToString();
        }

        public override string ToString()
        {
            return asString();
        }

        public object asObject()
        {
            return value;
        }

        public TokenType type()
        {
            if (value == true)
                return TokenType.TRUE;
            else
                return TokenType.FALSE;
        }
    }
}
