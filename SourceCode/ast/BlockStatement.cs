using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class BlockStatement : Statement
    {
        private List<Statement> statements;

        public BlockStatement()
        {
            statements = new List<Statement>();
        }

        public void add(Statement statement)
        {
            statements.Add(statement);
        }

        public void execute()
        {
            foreach (Statement statement in statements)
            {
                if (statement is AsyncFunctionStatement)
                {
                    AsyncFunctionStatement fstatement = ((AsyncFunctionStatement)statement);


                    var mytask = fstatement.async_execute();
                    mytask.Wait();
                }
                else
                {
                    statement.execute();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Statement statement in statements)
            {
                result.Append(statement.ToString()).Append("\n");
            }
            return result.ToString();
        }
    }
}
