using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class DdotExpression : Expression
    {
        private EnumValue value;
        private StringValue var;

        public DdotExpression(EnumValue value, StringValue var)
        {
            this.value = new EnumValue(value.getAll());
            this.var = var;
        }

        public Value eval()
        {
            return value.get(var.asString());
        }

        override public string ToString()
        {
            return value.asString();
        }
    }
}
