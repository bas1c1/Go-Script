using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ClassStatement : Statement
    {
        private ClassExpression classes;
        public ClassStatement(ClassExpression classes)
        {
            this.classes = classes;
        }

        public void execute()
        {
            classes.eval();
        }

        public override string ToString()
        {
            return classes.ToString();
        }
    }
}
