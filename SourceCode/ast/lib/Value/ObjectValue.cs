using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ObjectValue : Value
    {
        private object value;

        public ObjectValue(object value)
        {
            this.value = value;
        }

        public object asObject()
        {
            return value;
        }

        public char asChar()
        {
            return char.Parse(value.ToString());
        }

        public double asDouble()
        {
            return double.Parse(value.ToString());
        }

        public int asNumber()
        {
            return int.Parse(value.ToString());
        }

        public string asString()
        {
            return value.ToString();
        }

        public TokenType type()
        {
            return TokenType.OBJECT;
        }
    }
}
