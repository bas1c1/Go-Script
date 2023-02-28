using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class IfThenElseExpression : Expression
    {
        private Expression boolexpr;
        private Expression then;
        private Expression elsexpr = null;

        public IfThenElseExpression(Expression boolexpr, Expression then, Expression elsexpr)
        {
            this.boolexpr = boolexpr;
            this.then = then;
            this.elsexpr = elsexpr;
        }

        public Value eval()
        {
            double result = boolexpr.eval().asNumber();
            if (result != 0)
            {
                return then.eval();
            }
            else if (elsexpr != null)
            {
                return elsexpr.eval();
            }
            else
            {
                return new NumberValue(0);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("if ").Append(boolexpr).Append(' ').Append(then);
            if (elsexpr != null)
            {
                result.Append("\nelse ").Append(elsexpr);
            }
            return result.ToString();
        }
    }
}
