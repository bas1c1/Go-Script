using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ArrayValue : Value, IEnumerable<Value>
    {
        private Value[] elements;

        public ArrayValue(int size)
        {
            this.elements = new Value[size];
        }

        public ArrayValue(Value[] elements)
        {
            this.elements = new Value[elements.Length];
            elements.CopyTo(this.elements, 0);
        }

        public ArrayValue(ArrayValue array)
        {
            new ArrayValue(array.elements);
        }

        public Value[] get() //int index
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < elements.Length; i++)
            {
                str.Append(" " + new StringValue(elements[i].asString()) + ";");
            }
            //new StringValue(str.ToString())
            return elements;
        }

        public Value[] append(Value expression) //int index
        {
            Stack<Value> strings = new Stack<Value>(elements);
            //for (int i = 0; i < elements.Length; i++)
            //{
            //    strings.Push(elements[i]);
            //}
            strings.Push(expression);
            return strings.ToArray();
        }

        public Value get_by_index(int index)
        {
            return elements[index];
        }

        public void set(int index, Value value)
        {
            elements[index] = value;
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

        public IEnumerator<Value> GetEnumerator()
        {
            foreach (Value value in elements)
                yield return value;
        }

        public override string ToString()
        {
            return asString();
        }

        public TokenType type()
        {
            return TokenType.ARRAY;
        }

        IEnumerator<Value> IEnumerable<Value>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
