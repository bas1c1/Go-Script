using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class StringValue : Value
    {
        private string value;

        public StringValue(string value)
        {
            this.value = value;
        }

        public double asDouble()
        {
            try
            {
                return double.Parse(value);
            }

            catch
            {
                return 0;
            }
        }

        public string asString()
        {
            return value;
        }

        public int asNumber()
        {
            try
            {
                return int.Parse(value);
            }

            catch
            {
                return 0;
            }
        }

        public char asChar()
        {
            try
            {
                return char.Parse(value);
            }

            catch
            {
                return ' ';
            }
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
            return TokenType.TEXT;
        }
    }
}
