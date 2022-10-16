using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class EnumValue : Value
    {
        private Dictionary<string, StringValue> enums = new Dictionary<string, StringValue>();

        public EnumValue(Dictionary<string, StringValue> enums)
        {
            this.enums = enums;
        }

        public Dictionary<string, StringValue> getAll()
        {
            return enums;
        }

        public StringValue get(string enm)
        {
            return enums[enm];
        }

        public char asChar()
        {
            return enums.ToString()[0];
        }

        public double asDouble()
        {
            return enums.Count;
        }

        public int asNumber()
        {
            return enums.Count;
        }

        public string asString()
        {
            return enums.ToString();
        }

        public TokenType type()
        {
            return TokenType.ENUM;
        }
    }
}
