using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class TryCatchStatement : Statement
    {
        private Statement tryStatement;
        private Statement catchStatement;

        public TryCatchStatement(Statement tryStatement, Statement catchStatement)
        {
            this.tryStatement = tryStatement;
            this.catchStatement = catchStatement;
        }

        public void execute()
        {
            try
            {
                tryStatement.execute();
            }
            catch(Exception ex)
            {
                Variables.set("ex", new StringValue(ex.ToString()));
                catchStatement.execute();
            }
        }

        public override string ToString()
        {
            return "try_catch";
        }
    }
}
