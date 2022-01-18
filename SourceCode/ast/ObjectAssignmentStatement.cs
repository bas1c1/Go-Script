using OwnLang.ast.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast
{
    class ObjectAssignmentStatement : Statement
    {
        private string variable;
        private Expression expression;

        public ObjectAssignmentStatement(string variable, Expression expression)
        {
            this.variable = variable;
            this.expression = expression;
        }

        public void execute()
        {
            Value result = expression.eval();
            Variables.set(variable, result);
        }

        public override string ToString()
        {
            return string.Format(("object" + variable.ToString() + " = " + expression.ToString()), variable, expression);
        }
    }
}
