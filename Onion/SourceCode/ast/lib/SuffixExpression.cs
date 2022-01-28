using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class SuffixExpression : Expression
    {
        private Expression expr1;
        private char operation;

        public SuffixExpression(char operation, Expression expr1)
        {
            this.operation = operation;
            this.expr1 = expr1;
        }

        public Value eval()
        {
            Value value1 = expr1.eval();

            double number1 = value1.asDouble();
            switch (operation)
            {
                case '+':
                    {
                        number1 += 1;
                        Variables.set(expr1.ToString(), new NumberValue(number1));
                        return new NumberValue(number1);
                    }
                case '-':
                    {
                        number1 -= 1;
                        Variables.set(expr1.ToString(), new NumberValue(number1));
                        return new NumberValue(number1);
                    }
                default:
                    {
                        return new NumberValue(number1++);
                    }
            }
        }

        override public string ToString()
        {
            string for_formatirovanie = (expr1).ToString() + " " + (operation).ToString() + " ";
            return string.Format(for_formatirovanie, expr1, operation);
        }
    }

    public class ForEqExpression : Expression
    {
        private Expression expr1;
        private Expression expr2;
        private char operation;

        public ForEqExpression(char operation, Expression expr1, Expression expr2)
        {
            this.operation = operation;
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public Value eval()
        {
            Value value1 = expr1.eval();
            Value value2 = expr2.eval();

            double number1 = value1.asDouble();
            double number2 = value2.asDouble();
            switch (operation)
            {
                case '+':
                    {
                        double result;
                        result = number1 + number2;
                        Variables.set(expr1.ToString(), new NumberValue(result));
                        return new NumberValue(result);
                    }
                case '-':
                    {
                        double result;
                        result = number1 - number2;
                        Variables.set(expr1.ToString(), new NumberValue(result));
                        return new NumberValue(result);
                    }
                case '*':
                    {
                        double result;
                        result = number1 * number2;
                        Variables.set(expr1.ToString(), new NumberValue(result));
                        return new NumberValue(result);
                    }
                case '/':
                    {
                        double result;
                        result = number1 / number2;
                        Variables.set(expr1.ToString(), new NumberValue(result));
                        return new NumberValue(result);
                    }
                default:
                    {
                        return new NumberValue(number1++);
                    }
            }
        }

        override public string ToString()
        {
            string for_formatirovanie = (expr1).ToString() + " " + (operation).ToString() + " ";
            return string.Format(for_formatirovanie, expr1, operation);
        }
    }
}
