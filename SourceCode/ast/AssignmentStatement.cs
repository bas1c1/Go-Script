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
        private bool isConst;
        public Value value;

        public AssignmentStatement(string variable, Expression expression, bool isTypedef = false, bool isConst=false)
        {
            this.variable = variable;
            this.expression = expression;
            this.isTypedef = isTypedef;
            this.isConst = isConst;
        }

        public void execute()
        {
            if (Constants.isExists(variable))
            {
                throw new Exception("This is constant");
            }
            Value result;
            if (isTypedef)
            {
                if (value is NumberValue)
                {
                    result = (NumberValue)expression.eval();
                    if (isConst)
                    {
                        Constants.set(variable, result);
                        return;
                    }
                    Variables.set(variable, result);
                    return;
                }
                if (value is BoolValue)
                {
                    result = (BoolValue)expression.eval();
                    if (isConst)
                    {
                        Constants.set(variable, result);
                        return;
                    }
                    Variables.set(variable, result);
                    return;
                }
                if (value is StringValue)
                {
                    result = (StringValue)expression.eval();
                    if (isConst)
                    {
                        Constants.set(variable, result);
                        return;
                    }
                    Variables.set(variable, result);
                    return;
                }
                if (value is EnumValue)
                {
                    result = (EnumValue)expression.eval();
                    if (isConst)
                    {
                        Constants.set(variable, result);
                        return;
                    }
                    Variables.set(variable, result);
                    return;
                }
                if (value is ObjectValue)
                {
                    result = (ObjectValue)expression.eval();
                    if (isConst)
                    {
                        Constants.set(variable, result);
                        return;
                    }
                    Variables.set(variable, result);
                    return;
                }
                if (value is ArrayValue)
                {
                    result = (ArrayValue)expression.eval();
                    if (isConst)
                    {
                        Constants.set(variable, result);
                        return;
                    }
                    Variables.set(variable, result);
                    return;
                }
                if (value is StackValue)
                {
                    result = (StackValue)expression.eval();
                    if (isConst)
                    {
                        Constants.set(variable, result);
                        return;
                    }
                    Variables.set(variable, result);
                    return;
                }
                if (value is DictionaryValue)
                {
                    result = (DictionaryValue)expression.eval();
                    if (isConst)
                    {
                        Constants.set(variable, result);
                        return;
                    }
                    Variables.set(variable, result);
                    return;
                }

            }
            result = expression.eval();
            if (isConst)
            {
                Constants.set(variable, result);
                return;
            }
            Variables.set(variable, result);
        }

        public override string ToString()
        {
            return string.Format((variable.ToString() + " = " + expression.ToString()), variable, expression);
        }
    }
}
