using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class UsingStatement : Statement
    {
        private Statement block;
        private string variable;
        private Expression value;

        public UsingStatement(Statement block, string variable, Expression value)
        {
            this.block = block;
            this.variable = variable;
            this.value = value;
        }

        public void execute()
        {
            Variables.push();
            Variables.set(variable, value.eval());
            block.execute();
            Variables.pop();
        }
    }
}
