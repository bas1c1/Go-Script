using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class Constants
    {
        private static Dictionary<string, Value> constants;
        private static NumberValue ZERO = new NumberValue(0);

        static Constants()
        {
            constants = new Dictionary<string, Value>();
            constants.Add("PI", new NumberValue(Math.PI));
            constants.Add("E", new NumberValue(Math.E));
            constants.Add("GOLDEN_RATIO", new NumberValue(1.618));
            constants.Add("NULL", new ObjectValue(null));
            constants.Add("SOCKSTREAM", new ObjectValue(SocketType.Stream));
            constants.Add("TCP_PROTOCOL", new ObjectValue(ProtocolType.Tcp));
            constants.Add("SOCKDGRAM", new ObjectValue(SocketType.Dgram));
            constants.Add("UDP_PROTOCOL", new ObjectValue(ProtocolType.Udp));
            constants.Add("ADDR_FAMILY_INTNET", new ObjectValue(AddressFamily.InterNetwork));
        }

        public static bool isExists(string key)
        {
            return constants.ContainsKey(key);
        }

        public static Value get(string key)
        {
            if (!isExists(key)) throw new Exception("Constant doesnt exits");
            return constants[key];
        }

        public static void set(string key, Value value)
        {
            constants.Add(key, value);
        }
    }
}
