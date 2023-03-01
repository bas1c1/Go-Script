using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ArrayAssignmentStatement : Statement
    {
        private string variable;
        private Expression index;
        private Expression expression;

        public ArrayAssignmentStatement(string variable, Expression index, Expression expression)
        {
            this.variable = variable;
            this.index = index;
            this.expression = expression;
        }

        public void execute()
        {
            Value var = Variables.get(variable);
            //if (var is ArrayValue)
            if (var is DictionaryValue)
            {
                DictionaryValue array = (DictionaryValue)var;
                string dindex = index.eval().asString();
                array.append(dindex, expression.eval());
                return;
            }
            try
            {
                ArrayValue array = (ArrayValue)var;
                array.set((int)index.eval().asNumber(), expression.eval());
                return;
            }
            catch
            {
                StackValue array = (StackValue)var;
                array.set((int)index.eval().asNumber(), expression.eval());
                return;
            }
            throw new Exception("Array expected");
        }

        public override string ToString()
        {
            return String.Format((variable + '[' + index + ']' + '=' + expression).ToString(), variable, index, expression);
        }
    }
}
