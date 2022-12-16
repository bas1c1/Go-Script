using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class WhileStatement : Statement
    {
        private Expression condition;
        private Statement statement;

        public WhileStatement(Expression condition, Statement statement)
        {
            this.condition = condition;
            this.statement = statement;
        }

        public void execute()
        {
            while (condition.eval().asNumber() != 0)
            {
                try
                {
                    statement.execute();
                }
                catch (BreakStatement)
                {
                    break;
                }
                catch (ContinueStatement)
                {
                    //continue;
                }
            }
        }

        public override string ToString()
        {
            return "while " + condition + ' ' + statement;
        }
    }
}
