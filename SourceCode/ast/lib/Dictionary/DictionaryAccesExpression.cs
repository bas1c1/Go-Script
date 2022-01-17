using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class DictionaryAccesExpression : Expression
    {
        private string variable;
        private Expression index;

        public DictionaryAccesExpression(string variable, Expression index)
        {
            this.variable = variable;
            this.index = index;
        }

        public Value eval()
        {
            Value var = Variables.get(variable);
            try
            {
                DictionaryValue array = (DictionaryValue)var;
                return array.get_by_index(index.eval().ToString());
            }
            catch
            {
                throw new Exception("Array expected");
            }
        }

        public override string ToString()
        {
            return String.Format((variable + '{' + index + '}').ToString(), variable, index);
        }
    }
}
