using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ConstStatement : Statement
    {
        private StringValue varname;
        private Expression value;

        public ConstStatement(StringValue varname, Expression value)
        {
            this.varname = varname;
            this.value = value;
        }

        public void execute()
        {
            Constants.set(varname.asString(), value.eval());
        }
    }
}
