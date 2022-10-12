using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    class SuffixAssignmentStatement : Statement
    {
        private string variable;
        private string operate;

        public SuffixAssignmentStatement(string variable, string operate)
        {
            this.variable = variable;
            this.operate = operate;
        }

        public void execute()
        {
            // expression.eval()
            //double number1 = 0;
            double var = Variables.get(variable).asDouble();
            Value result = new NumberValue(0);
            if (operate == "+")
            {
                result = new NumberValue(var + 1);
                Variables.set(variable, result);
            }
            if (operate == "-")
            {
                result = new NumberValue(var - 1);
                Variables.set(variable, result);
            }
            Variables.set(variable, result);
        }

        public override string ToString()
        {
            return string.Format(variable.ToString() + " = ", variable);
        }
    }
}
