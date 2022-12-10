using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class DdotEqAssignmentStatement : Statement
    {
        private string valuet;
        private EnumValue value;
        private StringValue var;
        private Expression value_e;

        public DdotEqAssignmentStatement(string value, StringValue var, Expression value_e)
        {
            valuet = value;
            this.var = var;
            this.value_e = value_e;
        }

        public void execute()
        {
            value = new EnumValue(((EnumValue)Variables.get(valuet)).getAll());
            value.set(var.asString(), value_e.eval());
        }

        override public string ToString()
        {
            return value.asString();
        }
    }
}
