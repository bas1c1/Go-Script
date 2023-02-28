using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class NumberValue : Value
    {
        private double value;
        public static NumberValue ZERO = new NumberValue(0);

        public NumberValue(bool value)
        {
            this.value = value ? 1 : 0;
        }

        public NumberValue(double value)
        {
            this.value = value;
        }

        public double asDouble()
        {
            return value;
        }

        public char asChar()
        {
            try
            {
                return char.Parse(value.ToString());
            }

            catch
            {
                return ' ';
            }
        }

        public int asNumber()
        {
            return (int) value;
        }

        public string asString()
        {
            return value.ToString();
        }

        public object asObject()
        {
            return value;
        }

        public override string ToString()
        {
            return asString();
        }

        public TokenType type()
        {
            return TokenType.NUMBER;
        }
    }
}
