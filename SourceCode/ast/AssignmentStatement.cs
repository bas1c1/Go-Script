using OwnLang.ast.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast
{
    class AssignmentStatement : Statement
    {
        private string variable;
        private Expression expression;
        private bool isTypedef;
        public Value value;

        public AssignmentStatement(string variable, Expression expression, bool isTypedef=false)
        {
            this.variable = variable;
            this.expression = expression;
            this.isTypedef = isTypedef;
        }

        public void execute()
        {
            if (isTypedef) {
                Value result = (value.GetType())expression.eval();
                Variables.set(variable, result);
                return;
            }
            Value result = expression.eval();
            Variables.set(variable, result);
        }

        public override string ToString()
        {
            return string.Format((variable.ToString() + " = " + expression.ToString()), variable, expression);
        }
    }
}
