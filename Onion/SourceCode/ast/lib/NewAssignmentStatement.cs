using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    class NewAssignmentStatement : Statement
    {
        private string variable;
        private Expression expression;
        private string operate;

        public NewAssignmentStatement(string variable, Expression expression, string operate)
        {
            this.variable = variable;
            this.expression = expression;
            this.operate = operate;
        }

        public void execute()
        {
            // expression.eval()
            double var = Variables.get(variable).asDouble();
            Value result = new NumberValue(0);
            if (operate == "+")
            {
                result = new NumberValue(var += expression.eval().asDouble());
            }
            if (operate == "-")
            {
                result = new NumberValue(var -= expression.eval().asDouble());
            }
            if (operate == "*")
            {
                result = new NumberValue(var *= expression.eval().asDouble());
            }
            if (operate == "/")
            {
                result = new NumberValue(var /= expression.eval().asDouble());
            }
            Variables.set(variable, result);
        }

        public override string ToString()
        {
            return string.Format((variable.ToString() + " = " + expression.ToString()), variable, expression);
        }
    }
}
