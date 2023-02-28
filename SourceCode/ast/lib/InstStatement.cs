using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class InstStatement : Statement
    {
        private string enums;
        private string enumf;
        private List<string> fdelete;

        public InstStatement(string enums, string enumf, List<string> fdelete)
        {
            this.enums = enums;
            this.enumf = enumf;
            this.fdelete = fdelete;
        }

        public void execute()
        {
            Dictionary<string, Value> enumss = ((EnumValue)Variables.get(enums)).getAll();
            foreach (string fd in fdelete)
            {
                enumss[fd] = new StringValue(fd);
            }
            Variables.set(enumf, new EnumValue(enumss));
        }
    }
}
