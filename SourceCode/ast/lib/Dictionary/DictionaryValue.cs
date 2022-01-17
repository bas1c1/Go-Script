using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class DictionaryValue : Value, IEnumerable<KeyValuePair<string, Value>>
    {
        private Dictionary<string, Value> elements;
        //private Value[] elements2;

        public DictionaryValue(int size)
        {
            this.elements = new Dictionary<string, Value>(size);
        }

        public DictionaryValue(Dictionary<string, Value> elements)
        {
            this.elements = new Dictionary<string, Value>(elements);
            //elements.CopyTo(this.elements2, 0);
        }

        public DictionaryValue(DictionaryValue array)
        {
            new DictionaryValue(array.elements);
        }

        public Dictionary<string, Value> get() //int index
        {
            //new StringValue(str.ToString())
            return elements;
        }

        public Dictionary<string, Value> append(string key, Value expression) //int index
        {
            Dictionary<string, Value> strings = new Dictionary<string, Value>(elements);
            strings.Add(key, expression);
            return strings;
        }

        public StringValue get_by_index(string index)
        {
            return new StringValue(elements[index].ToString());
        }

        //public void set(int index, string key, Value value)
        //{
        //    elements.ToArray()[index] = value;
        //}

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

        public IEnumerator<KeyValuePair<string, Value>> GetEnumerator()
        {
            foreach (KeyValuePair<string, Value> value in elements)
                yield return value;
        }

        public TokenType type()
        {
            return TokenType.DICT;
        }

        IEnumerator<KeyValuePair<string, Value>> IEnumerable<KeyValuePair<string, Value>>.GetEnumerator()
        {
            return (IEnumerator<KeyValuePair<string, Value>>)GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
