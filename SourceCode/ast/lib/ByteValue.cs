using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ByteValue : Value
    {
        private byte[] value;
        public static NumberValue ZERO = new NumberValue(0);

        public ByteValue(byte[] value)
        {
            this.value = value;
        }

        public static byte[] GetBytes(string value)
        {
            return Array.ConvertAll(value.Split('-'), s => byte.Parse(s, System.Globalization.NumberStyles.HexNumber));
        }

        public byte[] asByteArray()
        {
            return value;
        }

        public double asDouble()
        {
            return BitConverter.ToDouble(value, 0);
        }

        public string asString()
        {
            return BitConverter.ToString(value);
        }

        public int asNumber()
        {
            return BitConverter.ToInt32(value, 0);
        }

        public char asChar()
        {
            return BitConverter.ToChar(value, 0);
        }

        public TokenType type()
        {
            return TokenType.BYTE;
        }
    }
}
