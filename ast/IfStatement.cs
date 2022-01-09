using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class IfStatement : Statement
    {
        private Expression expression;
        private Statement ifStatement, elseStatement;

        public IfStatement(Expression expression, Statement ifStatement, Statement elseStatement)
        {
            this.expression = expression;
            this.ifStatement = ifStatement;
            this.elseStatement = elseStatement;
        }

        public void execute()
        {
            double result = expression.eval().asNumber();
            if (result != 0)
            {
                ifStatement.execute();
            }
            else if (elseStatement != null)
            {
                elseStatement.execute();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("if ").Append(expression).Append(' ').Append(ifStatement);
            if (elseStatement != null)
            {
                result.Append("\nelse ").Append(elseStatement);
            }
            return result.ToString();
        }
    }
}
