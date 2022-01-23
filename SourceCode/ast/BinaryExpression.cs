using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class BinaryExpression : Expression
    {
        private Expression expr1, expr2;
        private char operation;

        public BinaryExpression(char operation, Expression expr1, Expression expr2)
        {
            this.operation = operation;
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public Value eval()
        {
            Value value1 = expr1.eval();
            Value value2 = expr2.eval();
            if ((value1 is StringValue) || (value1 is ArrayValue))
            {
                string string1 = value1.asString();
                string string2 = value2.asString();
                switch (operation)
                {
                    case '+':
                        {
                            return new StringValue(string1 + string2);
                        }
                    case '*':
                        {
                            int iterations = (int)value2.asDouble();
                            StringBuilder buffer = new StringBuilder();
                            for (int i = 0; i < iterations; i++)
                            {
                                buffer.Append(string1);
                            }
                            return new StringValue(buffer.ToString());
                        }
                    default:
                        {
                            return new StringValue(string1 + string2);
                        }
                }
            }

            double number1 = value1.asDouble();
            double number2 = value2.asDouble();
            switch (operation)
            {
                case '+':
                    {
                        return new NumberValue(number1 + number2);
                    }
                case '-':
                    {
                        return new NumberValue(number1 - number2);
                    }
                case '*':
                    {
                        return new NumberValue(number1 * number2);
                    }
                case '/':
                    {
                        return new NumberValue(number1 / number2);
                    }
                default:
                    {
                        return new NumberValue(number1 + number2);
                    }
            }
        }

        override public string ToString()
        {
            string for_formatirovanie = (expr1).ToString() + " " + (operation).ToString() + " " + (expr2).ToString();
            return string.Format(for_formatirovanie, expr1, operation, expr2);
        }
    }
}
