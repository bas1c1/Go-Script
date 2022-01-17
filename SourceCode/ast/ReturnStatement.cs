using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ReturnStatement : Exception, Statement
    {
        private Expression expression;
        private Value result;

        public ReturnStatement(Expression expression)
        {
            this.expression = expression;
        }

        public Value getResult()
        {
            return result;
        }

        public void execute()
        {
            result = expression.eval();
            throw this;
        }

        public override string ToString()
        {
            return "return";
        }
    }
}
