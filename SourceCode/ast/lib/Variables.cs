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
        private static NumberValue ZERO = new NumberValue(0);

        private static Stack<Dictionary<string, Value>> stack;
        //constants1 = new
        static Variables()
        {
            stack = new Stack<Dictionary<string, Value>>();
            variables = new Dictionary<string, Value>();
            variables.Add("PI", new NumberValue(Math.PI));
            variables.Add("E", new NumberValue(Math.E));
            variables.Add("GOLDEN_RATIO", new NumberValue(1.618));
            variables.Add("NULL", new NumberValue(0));
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
            if (!isExists(key)) return ZERO;
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
