using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ForStatement : Statement
    {
        private Expression termination;
        private Statement block;
        private Statement initalization;
        private Statement increment;

        public ForStatement(Expression termination, Statement block, Statement initalization, Statement increment)
        {
            this.termination = termination;
            this.block = block;
            this.initalization = initalization;
            this.increment = increment;
        }

        public void execute()
        {
            for (initalization.execute(); termination.eval().asNumber() != 0; increment.execute())
            {
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
                    //continue;
                }
            }
        }

        public override string ToString()
        {
            return "for " + initalization + ',' +  ' ' + termination + ',' + ' ' + increment + ' ' + block;
        }
    }
}
