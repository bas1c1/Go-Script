using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public static class Marks
    {
        public static Dictionary<string, Expression> marks = new Dictionary<string, Expression>();
    }

    public class EndIfException : System.Exception, Statement
    {
        public void execute()
        {
            
        }
    }
}
