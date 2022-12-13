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

        public AssignmentStatement(string variable, Expression expression, bool isTypedef = false)
        {
            this.variable = variable;
            this.expression = expression;
            this.isTypedef = isTypedef;
        }

        public void execute()
        {
            Value result;
            if (isTypedef)
            {
                if (value is NumberValue)
                {
                    result = (NumberValue)expression.eval();
                    Variables.set(variable, result);
                    return;
                }
                if (value is BoolValue)
                {
                    result = (BoolValue)expression.eval();
                    Variables.set(variable, result);
                    return;
                }
                if (value is StringValue)
                {
                    result = (StringValue)expression.eval();
                    Variables.set(variable, result);
                    return;
                }
                if (value is EnumValue)
                {
                    result = (EnumValue)expression.eval();
                    Variables.set(variable, result);
                    return;
                }
                if (value is ObjectValue)
                {
                    result = (ObjectValue)expression.eval();
                    Variables.set(variable, result);
                    return;
                }
                if (value is ArrayValue)
                {
                    result = (ArrayValue)expression.eval();
                    Variables.set(variable, result);
                    return;
                }
                if (value is StackValue)
                {
                    result = (StackValue)expression.eval();
                    Variables.set(variable, result);
                    return;
                }
                if (value is DictionaryValue)
                {
                    result = (DictionaryValue)expression.eval();
                    Variables.set(variable, result);
                    return;
                }

            }
            result = expression.eval();
            Variables.set(variable, result);
        }

        public override string ToString()
        {
            return string.Format((variable.ToString() + " = " + expression.ToString()), variable, expression);
        }
    }
}
