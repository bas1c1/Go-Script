using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class BreakStatement : Exception, Statement
    {
        public BreakStatement()
        {

        }

        public void execute()
        {
            throw this;
        }

        public override string ToString()
        {
            return "break";
        }
    }
}
