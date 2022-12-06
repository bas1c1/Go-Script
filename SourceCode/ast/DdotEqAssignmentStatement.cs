using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class DdotEqAssignmentStatement : Statement
    {
        private EnumValue value;
        private StringValue var;
        private Value value1;

        public DdotEqAssignmentStatement(EnumValue value, StringValue var, Value value1)
        {
            this.value = new EnumValue(value.getAll());
            this.var = var;
            this.value1 = value1;
        }

        public void execute()
        {
            value.set(var.asString(), value1);
        }

        override public string ToString()
        {
            return value.asString();
        }
    }
}
