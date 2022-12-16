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
        private Expression value1;

        public DdotEqAssignmentStatement(string value, StringValue var, Expression value1)
        {
            valuet = value;
            this.var = var;
            this.value1 = value1;
        }

        public void execute()
        {
            value = new EnumValue(((EnumValue)Variables.get(valuet)).getAll());
            value.set(var.asString(), value1.eval());
        }

        override public string ToString()
        {
            return value.asString();
        }
    }
}
