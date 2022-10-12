using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class UserDefineFunction : Function
    {
        private List<string> argNames;
        private Statement body;

        public UserDefineFunction(List<string> argNames, Statement body)
        {
            this.argNames = argNames;
            this.body = body;
        }

        public int getArgsCount()
        {
            return argNames.Count;
        }

        public string getArgsName(int index)
        {
            if (index < 0 || index >= getArgsCount()) return "";
            return argNames[index];
        }

        public Value execute(Value[] args)
        {
            try
            {
                body.execute();
                return NumberValue.ZERO;
            }
            catch (ReturnStatement rt)
            {
                return rt.getResult();
            }
        }
    }
}
