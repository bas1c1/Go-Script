using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class UseStatement : Statement
    {
        private string expression;

        public UseStatement(string expression)
        {
            this.expression = expression;
        }

        public void execute()
        {
            Functions for_use = new Functions();
            for_use.getModule(expression);
        }

        public override string ToString()
        {
            return "use " + expression;
        }
    }
}
