using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.CodeDom.Compiler;

namespace OwnLang.ast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Onion";
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
