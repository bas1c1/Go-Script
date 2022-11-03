using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class LambdaExpression : Expression
    {
        public Statement statement;

        public LambdaExpression(Statement statement)
        {
            this.statement = statement;
        }

        public Value eval()
        {
            return new StatementValue(statement);
        }
    }
}
