using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class Starcon : Expression, Statement
    {
        private int iter;
        private Expression expr;

        public Starcon(int iter, Expression expr)
        {
            this.iter = iter;
            this.expr = expr;
        }

        public Value eval()
        {
            Value fret = new NumberValue(0);
            for (int i = 0; i < iter; i++)
            {
                fret = expr.eval();
            }
            return fret;
        }

        public void execute()
        {
            for (int i = 0; i < iter; i++)
            {
                expr.eval();
            }
        }
    }
}
