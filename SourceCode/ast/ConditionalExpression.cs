using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ConditionalExpression : Expression
    {
        public enum Operator {
            PLUS,
            MINUS,
            MULTIPLY,
            DIVIDE,

            EQUALS,
            NOT_EQUALS,

            LT,
            LTEQ,
            GT,
            GTEQ,

            AND,
            OR,
            LOGAND,
            LOGOR,
            XOR
        };
        private Expression expr1, expr2;
        private Operator operation;

        public ConditionalExpression(Operator operation, Expression expr1, Expression expr2)
        {
            this.operation = operation;
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public Value eval()
        {
            Value value1 = expr1.eval();
            Value value2 = expr2.eval();

            double number1, number2;
            if (value1 is StringValue)
            {
                number1 = value1.asString().CompareTo(value2.asString());
                number2 = 0;
                string string1 = value1.asString();
                string string2 = value2.asString();
            }
            else
            {
                number1 = value1.asDouble();
                number2 = value2.asDouble();
            }
            bool result;
            switch (operation)
            {
                case Operator.LT:
                    {
                        result = number1 < number2; break;
                    }
                case Operator.LTEQ:
                    {
                        result = number1 <= number2; break;
                    }
                case Operator.GT:
                    {
                        result = number1 > number2; break;
                    }
                case Operator.GTEQ:
                    {
                        result = number1 >= number2; break;
                    }
                case Operator.EQUALS:
                    {
                        result = number1 == number2; break;
                    }
                case Operator.NOT_EQUALS:
                    {
                        result = number1 != number2; break;
                    }

                case Operator.AND:
                    {
                        result = (number1 != 0) && (number2 != 0); break;
                    }
                case Operator.OR:
                    {
                        result = (number1 != 0) || (number2 != 0); break;
                    }
                case Operator.LOGOR:
                    {
                        result = (number1 != 0) | (number2 != 0); break;
                    }
                case Operator.LOGAND:
                    {
                        result = (number1 != 0) & (number2 != 0); break;
                    }
                case Operator.XOR:
                    {
                        result = (number1 != 0) ^ (number2 != 0); break;
                    }

                default:
                    {
                        result = number1 == number2; break;
                    }
            }

            return new NumberValue(result);
        }

        override public string ToString()
        {
            string for_formatirovanie = (expr1).ToString() + " " + (operation).ToString() + " " + (expr2).ToString();
            return string.Format(for_formatirovanie, expr1, operation, expr2);
        }
    }
}
