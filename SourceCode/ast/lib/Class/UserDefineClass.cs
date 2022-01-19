using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class UserDefineClass : Class
    {
        private Statement body;

        public UserDefineClass(Statement body)
        {
            this.body = body;
        }

        public Value execute()
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
