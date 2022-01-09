using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class PrintStatement : Statement
    {
        private Expression expression;

        public PrintStatement(Expression expression)
        {
            this.expression = expression;
        }

        public void execute()
        {
            Console.Write(expression.eval().asString());
        }

        public override string ToString()
        {
            return "print " + expression;
        }
    }
}