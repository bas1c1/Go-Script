using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public class ImportStatement : Statement
    {
        private Expression expression;

        public ImportStatement(Expression expression)
        {
            this.expression = expression;
        }

        public void execute()
        {
            string input = File.ReadAllText(expression.ToString());
            List<Token> tokens = new Lexer(input).tokenize();
            Statement program = new Parser(tokens).parse();
            program.execute();
        }
    }
}
