using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class StackValue : Value
    {
        private Stack<Value> elements;
        private Value[] elements2;

        public StackValue(int size)
        {
            this.elements = new Stack<Value>(size);
        }

        public StackValue(Stack<Value> elements)
        {
            this.elements = new Stack<Value>(elements);
            //elements.CopyTo(this.elements2, 0);
        }

        public StackValue(StackValue array)
        {
            new StackValue(array.elements);
        }

        public Stack<Value> get() //int index
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            for (int i = 0; i < elements.Count; i++)
            {
                str.Append(" " + new StringValue(elements.ToArray()[i].asString()) + ";");
            }
            str.Append("}");
            //new StringValue(str.ToString())
            return elements;
        }

        public Stack<Value> append(Value expression) //int index
        {
            Stack<Value> strings = new Stack<Value>(elements);
            strings.Push(expression);
            return strings;
        }

        public Value get_by_index(int index)
        {
            return elements.ToArray()[index];
        }

        public void set(int index, Value value)
        {
            elements.ToArray()[index] = value;
        }

        public double asDouble()
        {
            throw new Exception("can't do it");
        }

        public string asString()
        {
            return elements.ToString();
        }

        public int asNumber()
        {
            throw new Exception("can't do it");
        }

        public char asChar()
        {
            throw new Exception("can't do it");
        }

        public override string ToString()
        {
            return asString();
        }
    }
}
