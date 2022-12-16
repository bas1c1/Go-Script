using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class Variables
    {
        private static Dictionary<string, Value> variables;
        private static ObjectValue ZERO = new ObjectValue(null);

        private static Stack<Dictionary<string, Value>> stack;

        static Variables()
        {
            stack = new Stack<Dictionary<string, Value>>();
            variables = new Dictionary<string, Value>();
        }

        public static void push()
        {
            stack.Push(new Dictionary<string, Value>(variables));
        }
        public static void pop()
        {
            variables = stack.Pop();
        }


        public static bool isExists(string key)
        {
            return variables.ContainsKey(key);
        }

        public static Value get(string key)
        {
            if (!isExists(key)) throw new Exception("Variable doesnt exits");
            return variables[key];
        }

        public static void set(string key, Value value)
        {
            try
            {
                variables.Add(key, value);
            }
            catch
            {
                variables.Remove(key);
                variables.Add(key, value);
            }
        }
    }
}
