using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ArrayAccesExpression : Expression
    {
        private string variable;
        private Expression index;

        public ArrayAccesExpression(string variable, Expression index)
        {
            this.variable = variable;
            this.index = index;
        }

        public Value eval()
        {
            Value var = Variables.get(variable);
            //if (var is ArrayValue)
            if (var is DictionaryValue)
            {
                DictionaryValue array = (DictionaryValue)var;
                return array.get_by_index(index.eval().asString());
            }
            try
            {
                ArrayValue array = (ArrayValue)var;
                return array.get_by_index((int)index.eval().asNumber());
            }
            catch
            {
                StackValue array = (StackValue)var;
                return array.get_by_index((int)index.eval().asNumber());
            }
            throw new Exception("Array expected");
        }

        public override string ToString()
        {
            return String.Format((variable + '[' + index + ']').ToString(), variable, index);
        }
    }
}
