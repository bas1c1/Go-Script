using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class AsyncFunctionStatement : Statement
    {
        private FunctionalExpression function;
        public AsyncFunctionStatement(FunctionalExpression function)
        {
            this.function = function;
        }

        public void execute()
        {
            function.eval();
        }

        public async Task async_execute()
        {
            var mytask = function.async_eval();
            mytask.Wait();
        }

        public override string ToString()
        {
            return function.ToString();
        }
    }
}
