using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class StatementStatement : Statement
    {
        private Statement body;

        public StatementStatement(Statement body)
        {
            this.body = body;
        }

        void Statement.execute()
        {
            body.execute();
        }
    }
}
