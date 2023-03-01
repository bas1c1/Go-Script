using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class DdotExpression : Expression
    {
        //private string valuet;
        private string value;
        private string var;
        private EnumValue evalue;

        public DdotExpression(string value, string var)
        {
            this.value = value;
            this.var = var;
        }

        public Value eval()
        {
            evalue = (EnumValue)Variables.get(value);// new EnumValue(((EnumValue)Variables.get(value)).getAll());
            return evalue.get(var);
        }

        override public string ToString()
        {
            return value;
        }
    }
}
