using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class CaseStatement : Statement
    {
        public Statement body;
        public Expression main;
        public Expression expr;

        public CaseStatement(Expression expr, Expression main, Statement body)
        {
            this.body = body;
            this.main = main;
            this.expr = expr;
        }

        public void execute()
        {
            Value main1 = main.eval();
            Value expr1 = expr.eval();
            if (main1.type() == expr1.type()) {
                if (main1.asString() == expr1.asString())
                {
                    body.execute();
                }
            }
        }
    }
}
