using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class EnumValue : Value
    {
        private Dictionary<string, Value> enums = new Dictionary<string, Value>();

        public EnumValue(Dictionary<string, Value> enums)
        {
            this.enums = enums;
        }

        public Dictionary<string, Value> getAll()
        {
            return enums;
        }

        public Value get(string enm)
        {
            return enums[enm];
        }

        public void set(string enm, Value value)
        {
            enums[enm] = value;
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
