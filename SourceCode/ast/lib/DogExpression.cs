using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class DogExpression : Expression
    {
        private LdefExpression ldef;
        public DogExpression(LdefExpression ldef)
        {
            this.ldef = ldef;
        }

        public Value eval()
        {
            Value[] zero_args = new Value[0];
            return ((Ldef)((ObjectValue)ldef.eval()).asObject()).execute(zero_args);
        }
    }
}
