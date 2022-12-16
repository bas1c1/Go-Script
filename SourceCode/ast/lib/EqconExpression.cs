using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class EqconExpression : Expression
    {
        private string var;
        private Expression expr;

        public EqconExpression(string var, Expression expr)
        {
            this.var = var;
            this.expr = expr;
        }

        public Value eval()
        {
            Value value = expr.eval();
            Variables.set(var, value);
            return value;
        }
    }
}
