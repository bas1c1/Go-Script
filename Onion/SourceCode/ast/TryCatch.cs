
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class TryStatement : Statement
    {
        private Statement statement_try;

        public TryStatement(Statement statement_try)
        {
            this.statement_try = statement_try;
        }

        public void execute()
        {
            try
            {
                statement_try.execute();
            }
            catch
            {
                
            }
        }

        public override string ToString()
        {
            return "try";
        }
    }
}
