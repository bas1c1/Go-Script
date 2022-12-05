using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class SwitchStatement : Statement
    {
        private List<CaseStatement> cases;

        public SwitchStatement(List<CaseStatement> cases)
        {
            this.cases = cases;
        }

        public void execute()
        {
            foreach (CaseStatement casest in cases) {
                casest.execute();
            }
        }
    }
}
