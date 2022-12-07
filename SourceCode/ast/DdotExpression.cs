using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class DdotExpression : Expression
    {
        private string valuet;
        private EnumValue value;
        private StringValue var;

        public DdotExpression(string value, StringValue var)
        {
            valuet = value;
            this.var = var;
        }

        public Value eval()
        {
            value = new EnumValue(((EnumValue)Variables.get(valuet)).getAll());
            return value.get(var.asString());
        }

        override public string ToString()
        {
            return value.asString();
        }
    }
}
