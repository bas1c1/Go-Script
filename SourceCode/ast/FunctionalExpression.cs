using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class FunctionalExpression : Expression
    {
        private string name;
        private List<Expression> arguments;

        public FunctionalExpression(string name)
        {
            this.name = name;
            arguments = new List<Expression>();
        }

        public FunctionalExpression(string name, List<Expression> arguments)
        {
            this.name = name;
            this.arguments = arguments;
        }

        public void addArgument(Expression arg)
        {
            arguments.Add(arg);
        }

        public Value eval()
        {
            int size = arguments.Count();
            Value[] values = new Value[size];
            for (int i = 0; i < size; i++)
            {
                values[i] = arguments[i].eval();
            }

            Function function = Functions.get(name);
            if (function is UserDefineFunction)
            {
                UserDefineFunction userFunction = (UserDefineFunction)function;
                if (size != userFunction.getArgsCount()) throw new Exception("Args count missmatch");

                Variables.push();

                for (int i = 0; i < size; i++)
                {
                    Variables.set(userFunction.getArgsName(i), values[i]);
                }

                Value result = userFunction.execute(values);
                Variables.pop();
                return result;
            }
            return function.execute(values);
        }

        public override string ToString()
        {
            return name + '(' + arguments.ToString() + ')';
        }
    }
}
