using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ValueExpression : Expression
    {
        private Value value;

        public ValueExpression(double value)
        {
            this.value = new NumberValue(value);
        }

        public ValueExpression(bool value)
        {
            this.value = new BoolValue(value);
        }

        public ValueExpression(string value)
        {
            this.value = new StringValue(value);
        }

        public Value eval()
        {
            return value;
        }

        override public string ToString()
        {
            return value.asString();
        }
    }
}
