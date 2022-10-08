using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class FunctionStatement : Statement
    {
        private FunctionalExpression function;
        public FunctionStatement(FunctionalExpression function)
        {
            this.function = function;
        }

        public void execute()
        {
            function.eval();
        }

        public override string ToString()
        {
            return function.ToString();
        }
    }
}
