using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ClassDefine : Statement
    {
        private string name;
        private Statement body;

        public ClassDefine(string name, Statement body)
        {
            this.name = name;
            this.body = body;
        }

        public void execute()
        {
            Classes.set(name, new UserDefineClass(body));
        }
    }
}
