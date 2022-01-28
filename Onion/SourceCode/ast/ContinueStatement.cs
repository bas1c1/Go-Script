using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ContinueStatement : Exception, Statement
    {
        public ContinueStatement()
        {

        }

        public void execute()
        {
            throw this;
        }

        public override string ToString()
        {
            return "continue";
        }
    }
}
