using System;

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
            catch (Exception ex)
            {
                Variables.set("exception", new StringValue(ex.ToString()));
                catchStatement.execute();
            }
        }

        public override string ToString()
        {
            return "try_catch";
        }
    }
}