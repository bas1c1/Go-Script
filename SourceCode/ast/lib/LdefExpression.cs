using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class LdefExpression : Expression
    {
        private List<string> arguments;
        private Statement body;

        public LdefExpression()
        {
            arguments = new List<string>();
        }

        public LdefExpression(Statement body, List<string> arguments)
        {
            this.body = body;
            this.arguments = arguments;
        }

        public void addArgument(string arg)
        {
            arguments.Add(arg);
        }

        public Value eval()
        {
            return new ObjectValue(new Ldef(arguments, body));
        }

        public override string ToString()
        {
            return "lfunc" + '(' + arguments.ToString() + ')';
        }
    }
}
