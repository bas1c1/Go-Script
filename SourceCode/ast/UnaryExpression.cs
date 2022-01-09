using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    class UnaryExpression : Expression
    {
        private Expression expr1;
        private char operation;

        public UnaryExpression(char operation, Expression expr1)
        {
            this.operation = operation;
            this.expr1 = expr1;
        }

        public Value eval()
        {
            switch (operation)
            {
                case '-':
                    {
                        return new NumberValue(-expr1.eval().asDouble());
                    }
                case '+':
                    {
                        return expr1.eval();
                    }
                default:
                    {
                        return expr1.eval();
                    }
            }
        }

        override public string ToString()
        {
            return string.Format((operation.ToString() + expr1.ToString()).ToString(), operation, expr1);
        }
    }
}
