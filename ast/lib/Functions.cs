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
using System.Net.Http;
using System.Windows.Forms;
using Microsoft.JScript;

namespace OwnLang.ast.lib
{
    public class Functions
    {
        private static Dictionary<string, Function> functions;

        static Functions()
        {
            functions = new Dictionary<string, Function>();
            functions.Add("stop", new ForStop());
            functions.Add("import", new ForImport());
            functions.Add("to_import", new ForToImport());
            functions.Add("throw_new_exception", new ForThrowException());
            functions.Add("true", new ForTrue());
            functions.Add("false", new ForFalse());
        }

        public void getModule(string name)
        {
            switch (name)
            {
                case "html":
                    {
                        try
                        {
                            functions.Add("html_create", new ForHTMLCreate());
                            functions.Add("html_add_text", new ForHTMLAddText());
                            functions.Add("html_add_head", new ForHTMLAddHead());
                            functions.Add("html_add_body", new ForHTMLAddBody());
                            functions.Add("html_add_mark", new ForHTMLAddMark());
                            functions.Add("html_add_p", new ForHTMLAddParagraph());
                            functions.Add("html_add_href", new ForHTMLAddHref());
                            functions.Add("html_add_custom", new ForHTMLAddCustom());
                            functions.Add("js_add_custom", new ForJSAddCustom());
                            functions.Add("css_add_custom", new ForCSSAddCustom());
                        }
                        catch
                        {
                            functions.Remove("html_create");
                            functions.Remove("html_add_text");
                            functions.Remove("html_add_head");
                            functions.Remove("html_add_body");
                            functions.Remove("html_add_mark");
                            functions.Remove("html_add_p");
                            functions.Remove("html_add_href");
                            functions.Remove("html_add_custom");
                            functions.Remove("js_add_custom");
                            functions.Remove("css_add_custom");

                            functions.Add("js_add_custom", new ForJSAddCustom());
                            functions.Add("css_add_custom", new ForCSSAddCustom());
                            functions.Add("html_create", new ForHTMLCreate());
                            functions.Add("html_add_text", new ForHTMLAddText());
                            functions.Add("html_add_head", new ForHTMLAddHead());
                            functions.Add("html_add_body", new ForHTMLAddBody());
                            functions.Add("html_add_mark", new ForHTMLAddMark());
                            functions.Add("html_add_p", new ForHTMLAddParagraph());
                            functions.Add("html_add_href", new ForHTMLAddHref());
                            functions.Add("html_add_custom", new ForHTMLAddCustom());
                        }
                        break;
                    }

                case "ui":
                    {
                        try
                        {
                        }
                        catch
                        {
                        }
                        break;
                    }
                case "math":
                    {
                        try
                        {
                            functions.Add("sin", new Sin());
                            functions.Add("cos", new Cos());
                        }
                        catch
                        {
                            functions.Remove("sin");
                            functions.Remove("cos");
                            functions.Add("sin", new Sin());
                            functions.Add("cos", new Cos());
                        }
                        break;
                    }
                case "cs":
                    {
                        try
                        {
                            functions.Add("console", new ForCSConsole());
                            functions.Add("title", new ForConsoleTitle());
                        }
                        catch
                        {
                            functions.Remove("console");
                            functions.Remove("title");
                            functions.Add("console", new ForCSConsole());
                            functions.Add("title", new ForConsoleTitle());
                        }
                        break;
                    }
                case "net":
                    {
                        try
                        {
                            functions.Add("parse", new ForNetParse());
                            functions.Add("get_request", new ForNetGetRequest());
                            functions.Add("start_tcp_server", new ForCreateTcpServer());
                        }
                        catch
                        {
                            functions.Remove("parse");
                            functions.Remove("get_request");
                            functions.Remove("start_tcp_server");
                            functions.Add("parse", new ForNetGetRequest());
                            functions.Add("get_request", new ForNetGetRequest());
                            functions.Add("start_tcp_server", new ForCreateTcpServer());
                        }
                        break;
                    }
                case "files":
                    {
                        try
                        {
                            functions.Add("read", new ForFileReadAll());
                            functions.Add("write", new ForFileWriteAll());
                            functions.Add("delete", new ForFileDelete());
                            functions.Add("append_text", new ForFileAppendAll());
                            functions.Add("open", new ForFilesOpenWithArg());
                        }
                        catch
                        {
                            functions.Remove("read");
                            functions.Remove("write");
                            functions.Remove("delete");
                            functions.Remove("append_text");
                            functions.Remove("open");
                            functions.Add("read", new ForFileReadAll());
                            functions.Add("write", new ForFileWriteAll());
                            functions.Add("delete", new ForFileDelete());
                            functions.Add("append_text", new ForFileAppendAll());
                            functions.Add("open", new ForFilesOpenWithArg());
                        }
                        break;
                    }
                case "random":
                    {
                        try
                        {
                            functions.Add("randint", new ForRandomInt());
                        }
                        catch
                        {
                            functions.Remove("randint");
                            functions.Add("randint", new ForRandomInt());
                        }
                        break;
                    }
                case "std":
                    {
                        try
                        {
                            functions.Add("print", new Print());
                            functions.Add("get_key", new ForKeyboardGetKey());
                            functions.Add("input", new Input());
                            functions.Add("to_int", new ForToInt());
                            functions.Add("to_string", new ForToString());
                            functions.Add("new_arr", new ForArray());
                            functions.Add("get_arr", new ForArrayGet());
                            functions.Add("exit", new ForExit());
                            functions.Add("sleep", new ForSleep());
                            functions.Add("key_press", new ForKeyPress());
                            functions.Add("sout_element", new ForWriteTableElement());
                            functions.Add("eval", new ForEval());
                            functions.Add("length", new ForArrayLength());
                            functions.Add("split", new ForSplit());
                        }
                        catch
                        {
                            functions.Remove("print");
                            functions.Remove("input");
                            functions.Remove("to_int");
                            functions.Remove("to_string");
                            functions.Remove("new_arr");
                            functions.Remove("get_arr");
                            functions.Remove("get_key");
                            functions.Remove("exit");
                            functions.Remove("sleep");
                            functions.Remove("eval");
                            functions.Remove("sout_element");
                            functions.Remove("key_press");
                            functions.Remove("split");
                            functions.Remove("length");
                            functions.Add("length", new ForArrayLength());
                            functions.Add("eval", new ForEval());
                            functions.Add("sout_element", new ForWriteTableElement());
                            functions.Add("key_press", new ForKeyPress());
                            functions.Add("sleep", new ForSleep());
                            functions.Add("exit", new ForExit());
                            functions.Add("print", new Print());
                            functions.Add("input", new Input());
                            functions.Add("get_key", new ForKeyboardGetKey());
                            functions.Add("to_int", new ForToInt());
                            functions.Add("to_string", new ForToString());
                            functions.Add("new_arr", new ForArray());
                            functions.Add("get_arr", new ForArrayGet());
                            functions.Add("split", new ForSplit());
                        }
                        break;
                    }
            }
        }

        public static bool isExists(string key)
        {
            return functions.ContainsKey(key);
        }

        public static Function get(string key)
        {
            if (!isExists(key)) throw new Exception("Unknown function " + key);
            return functions[key];
        }

        public static void set(string key, Function function)
        {
            try
            {
                functions.Add(key, function);
            }
            catch
            {
                functions.Remove(key);
                functions.Add(key, function);
            }
        }
    }

    public class Sin : Function
    {
        public Value execute(Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            return new NumberValue(Math.Sin(args[0].asNumber()));
        }
    }

    public class Cos : Function
    {
        public Value execute(Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            return new NumberValue(Math.Cos(args[0].asNumber()));
        }
    }

    public class Print : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            foreach (Value arg in args)
            {
                Console.WriteLine(arg.asString());
            }
            return ZERO;
        }
    }

    public class Input : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            foreach (Value arg in args)
            {
                Console.Write(arg.asString());
            }
            StringValue stringValue = new StringValue(Console.ReadLine().ToString());
            return stringValue;
        }
    }

    public class ForToInt : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            return new NumberValue(args[0].asDouble());
        }
    }

    public class ForToString : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            return new StringValue(args[0].asString());
        }
    }

    public class ForStop : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            if (args.Length != 0) throw new Exception("Zero args expected");
            char key = Console.ReadKey(true).KeyChar;
            //Console.ReadKey();
            return ZERO;
        }
    }

    public class ForRandomInt : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            //Console.WriteLine(args.ToString());
            if (args.Length != 2) throw new Exception("Two args expected");
            Random random = new Random();
            NumberValue rand = new NumberValue(random.Next(int.Parse(args[0].ToString()), int.Parse(args[1].ToString())));
            return rand;
        }
    }

    public class ForArray : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            ArrayValue array = new ArrayValue(args);
            return array;
        }
    }

    public class ForSplit : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            int i = 0;
            Stack<string> a = new Stack<string>(args[0].ToString().Split(Char.Parse(args[1].ToString())));
            Stack<StringValue> strings = new Stack<StringValue>();
            foreach (string lol in a) 
            {
                strings.Push(new StringValue(lol));
            }
            return new ArrayValue(strings.ToArray());
        }
    }

    public class ForArrayAppend : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            StringBuilder str = new StringBuilder();
            Value var = Variables.get(args[0].ToString());
            ArrayValue array = (ArrayValue)var;
            Variables.set(args[0].ToString(), new ArrayValue(array.append(args[1])));
            return ZERO;
        }
    }

    public class ForSplitGet : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            StringBuilder str = new StringBuilder();
            Value var = Variables.get(args[0].ToString());
            ArrayValue array = (ArrayValue)var;
            for (int i = 0; i < array.get().Length; i++)
            {
                str.Append(" " + new StringValue(array.get().ToArray()[i].asString()));
            }
            return new StringValue(str.ToString());
        }
    }

    public class ForArrayGet : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            StringBuilder str = new StringBuilder();
            Value var = Variables.get(args[0].ToString());
            ArrayValue array = (ArrayValue)var;
            for (int i = 0; i < array.get().Length; i++)
            {
                str.Append(" " + new StringValue(array.get().ToArray()[i].asString()) + ";");
            }
            return new StringValue(str.ToString());
        }
    }

    public class ForArrayLength : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Value var = Variables.get(args[0].ToString());
            ArrayValue array = (ArrayValue)var;
            return new NumberValue(array.get().Length);
        }
    }

    public class ForFileReadAll : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string str = File.ReadAllText(args[0].ToString());
            return new StringValue(str.ToString());
        }
    }

    public class ForFileWriteAll : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            File.WriteAllText(args[0].ToString(), args[1].asString());
            return ZERO;
        }
    }

    public class ForFileAppendAll : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            File.AppendAllText(args[0].ToString(), args[1].asString());
            return ZERO;
        }
    }

    public class ForFileDelete : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            File.Delete(args[0].ToString());
            return ZERO;
        }
    }

    public class ForThrowException : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            throw new Exception(args[0].ToString());
        }
    }

    public class ForCSConsole : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            if (args[0].ToString() == "clear")
            {
                Console.Clear();
                return ZERO;
            }

            if (args[0].ToString() == "reset_color")
            {
                Console.ResetColor();
                return ZERO;
            }

            if (args[0].ToString() == "color")
            {
                if (args[1].ToString() == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (args[1].ToString() == "green")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (args[1].ToString() == "blue")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                return ZERO;
            }

            else
            {
                throw new Exception("One arg expected");
            }
        }
    }

    public class ForNetParse : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(args[0].ToString());
            StreamReader sr = new StreamReader(stream);
            string end_text = "";
            end_text = sr.ReadToEnd();
            stream.Close();
            return new StringValue(end_text);
        }
    }

    public class ForNetGetRequest : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(args[0].ToString());
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:17.0) Gecko/20100101 Firefox/17.0";
            req.CookieContainer = cookies;
            req.Headers.Add("DNT", "1");
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            resp.Close();
            string text = sr.ReadToEnd();
            sr.Close();
            return new StringValue(text);
        }
    }

    public class ForKeyboardGetKey : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            char key = ' ';
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true).KeyChar;
            }
            StringValue stringValue = new StringValue(key.ToString());
            return stringValue;
        }
    }

    public class ForConsoleTitle : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Console.Title = args[0].ToString();
            return ZERO;
        }
    }

    public class ForImport : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string input = File.ReadAllText(args[0].ToString());
            List<Token> tokens = new Lexer(input).tokenize();
            Statement program = new Parser(tokens).parse();
            program.execute();
            return ZERO;
        }
    }

    public class ForToImport : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Function func = Functions.get(args[0].ToString());
            Functions.set(args[0].ToString(), func);
            return ZERO;
        }
    }

    public class ForHTMLCreate : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            File.WriteAllText(args[0].ToString(), "<h1> Hello world! </h1>");
            return ZERO;
        }
    }

    public class ForHTMLAddText : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            File.AppendAllText(args[0].ToString(), ('\n' + "<" + args[1].ToString() + ">" + args[2].ToString() + "</" + args[1].ToString() + ">"));
            return ZERO;
        }
    }

    public class ForHTMLAddHref : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string text = "<a href=" + args[1].ToString() + ">" + args[2].ToString() + "</a>";
            File.AppendAllText(args[0].ToString(), '\n' + text);
            return ZERO;
        }
    }

    public class ForHTMLAddParagraph : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string text = "<p>" + args[1].ToString() + "</p>";
            File.AppendAllText(args[0].ToString(), '\n' + text);
            return ZERO;
        }
    }

    public class ForHTMLAddBody : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string text = "<body>" + args[1].ToString() + "</body>";
            File.AppendAllText(args[0].ToString(), '\n' + text);
            return ZERO;
        }
    }

    public class ForHTMLAddHead : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string text = "<head>" + args[1].ToString() + "</head>";
            File.AppendAllText(args[0].ToString(), '\n' + text);
            return ZERO;
        }
    }

    public class ForHTMLAddMark : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string text = "<mark>" + args[1].ToString() + "</mark>";
            File.AppendAllText(args[0].ToString(), '\n' + text);
            return ZERO;
        }
    }

    public class ForHTMLAddCustom : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string text = args[1].ToString();
            File.AppendAllText(args[0].ToString(), '\n' + text);
            return ZERO;
        }
    }

    public class ForCSSAddCustom : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string text = "<style>" + args[1].ToString() + "</style>";
            File.AppendAllText(args[0].ToString(), '\n' + text);
            return ZERO;
        }
    }

    public class ForJSAddCustom : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            string text = "<script>" + args[1].ToString() + "</script>";
            File.AppendAllText(args[0].ToString(), '\n' + text);
            return ZERO;
        }
    }

    public class ForFilesOpenWithArg : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Process.Start(args[0].ToString(), args[1].ToString());
            return ZERO;
        }
    }

    public class ForExit : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Environment.Exit(0);
            return ZERO;
            //throw new Exception("exit");
        }
    }

    public class ForWriteTableElement : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Console.WriteLine("{0,10}   |{1,10}", args[0].ToString(), args[1].ToString());
            return ZERO;
        }
    }

    public class ForSleep : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Thread.Sleep(int.Parse(args[0].ToString()));
            return ZERO;
        }
    }

    public class ForEval : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            double result = JsMath.Eval(args[0].ToString());
            return new NumberValue(result);
        }
    }

    public class ForKeyPress : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            SendKeys.SendWait(args[0].ToString());
            return ZERO;
        }
    }

    public class ForCreateTcpServer : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            ClientForm.StartServer(int.Parse(args[0].ToString()));
            return ZERO;
        }
    }

    public class ForTrue : Function
    {
        private static NumberValue ONE = new NumberValue(1);

        public Value execute(Value[] args)
        {
            return ONE;
        }
    }

    public class ForFalse : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            return ZERO;
        }
    }
}
