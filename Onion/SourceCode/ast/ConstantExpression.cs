using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    class ConstantExpression : Expression
    {
        private string name;
        
        public ConstantExpression(string name)
        {
            this.name = name;
        }

        public Value eval()
        {
            if (!Variables.isExists(name)) throw new Exception("Constant doesnt exists");
            return Variables.get(name);
        }

        public override string ToString()
        {
            return string.Format((name).ToString(), name);
        }
    }
}
