using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class FunctionDefine : Statement
    {
        private string name;
        private List<string> argNames;
        private Statement body;

        public FunctionDefine(string name, List<string> argNames, Statement body)
        {
            this.name = name;
            this.argNames = argNames;
            this.body = body;
        }

        public void execute()
        {
            Functions.set(name, new UserDefineFunction(argNames, body));
        }

        public override string ToString()
        {
            return "def (" + argNames.ToString() + ") " + body.ToString();
        }
    }
}
