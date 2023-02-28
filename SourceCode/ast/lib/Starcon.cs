using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class Starcon : Expression, Statement
    {
        private int iterator;
        private Expression iter;
        private Expression expr;

        public Starcon(Expression iter, Expression expr)
        {
            this.iter = iter;
            this.expr = expr;
        }

        public Value eval()
        {
            iterator = ((NumberValue)iter.eval()).asNumber();
            Value fret = new NumberValue(0);
            for (int i = 0; i < iterator; i++)
            {
                fret = expr.eval();
            }
            return fret;
        }

        public void execute()
        {
            iterator = ((NumberValue)iter.eval()).asNumber();
            for (int i = 0; i < iterator; i++)
            {
                expr.eval();
            }
        }
    }
}
