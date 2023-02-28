using System;
using System.Collections.Generic;
using System.IO;

namespace OwnLang.ast.lib
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Go-Script";
            CommandLineArgs.args = args;
            execute(args[0].ToString());
        }

        public static void execute(string file)
        {
            string input = File.ReadAllText(file);
            List<Token> tokens = new Lexer(input).tokenize();
            Statement program = new Parser(tokens).parse();
            program.execute();
            Console.WriteLine();
        }
    }
}
