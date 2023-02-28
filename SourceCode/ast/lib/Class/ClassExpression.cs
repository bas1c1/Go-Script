using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ClassExpression : Expression
    {
        private string name;

        public ClassExpression(string name)
        {
            this.name = name;
        }

        public Value eval()
        {
            Class classes = Classes.get(name);
            return classes.execute();
        }

        public override string ToString()
        {
            return "class" + name + '(' + ' ' + ')';
        }
    }
}
