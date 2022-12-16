using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ForeachStatement : Statement
    {
        public string variable;
        public Expression container;
        public Statement block;

        public ForeachStatement(string variable, Expression container, Statement block)
        {
            this.variable = variable;
            this.container = container;
            this.block = block;
        }

        public void execute()
        {
            Value containerValue = container.eval();

            switch (containerValue.type())
            {
                case TokenType.TEXT:
                    iterateString(containerValue.asString());
                    break;

                case TokenType.ARRAY:
                    iterateArray((ArrayValue)containerValue);
                    break;

                case TokenType.STACK:
                    iterateStack((StackValue)containerValue);
                    break;

                case TokenType.DICT:
                    iterateDict((DictionaryValue)containerValue);
                    break;

                default:
                    iterateArray((ArrayValue)containerValue);
                    break;
            }
        }

        private void iterateString(string str)
        {
            foreach (char ch in str.ToCharArray())
            {
                Variables.set(variable, new StringValue(ch.ToString()));
                try
                {
                    block.execute();
                }
                catch (BreakStatement)
                {
                    break;
                }
                catch (ContinueStatement)
                {
                    // continue;
                }
            }
        }

        private void iterateArray(ArrayValue containerValue)
        {
            foreach (Value value in containerValue)
            {
                Variables.set(variable, value);
                try
                {
                    block.execute();
                }
                catch (BreakStatement)
                {
                    break;
                }
                catch (ContinueStatement)
                {
                    // continue;
                }
            }
        }

        private void iterateDict(DictionaryValue containerValue)
        {
            foreach (KeyValuePair<string, Value> value in containerValue)
            {
                Variables.set(variable, new StringValue(value.ToString()));
                try
                {
                    block.execute();
                }
                catch (BreakStatement)
                {
                    break;
                }
                catch (ContinueStatement)
                {
                    // continue;
                }
            }
        }

        private void iterateStack(StackValue containerValue)
        {
            foreach (Value value in containerValue)
            {
                Variables.set(variable, value);
                try
                {
                    block.execute();
                }
                catch (BreakStatement)
                {
                    break;
                }
                catch (ContinueStatement)
                {
                    // continue;
                }
            }
        }

        public override string ToString()
        {
            return "foreach ";
        }
    }
}
