using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class DoWhileStatement : Statement
    {
        private Statement statement;
        private Expression condition;

        public DoWhileStatement(Statement statement, Expression condition)
        {
            this.statement = statement;
            this.condition = condition;
        }

        public void execute()
        {
            do
            {
                try
                {
                    statement.execute();
                }
                catch (BreakStatement bs)
                {
                    break;
                }
                catch (ContinueStatement cs)
                {
                    //continue;
                }
            }
            while (condition.eval().asNumber() != 0);
        }

        public override string ToString()
        {
            return "do " + statement + " while " + condition;
        }
    }
}
