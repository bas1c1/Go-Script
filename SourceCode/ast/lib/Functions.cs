using System;
using Gtk;
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
using Microsoft.Win32;
using System.Reflection;
using Socket = System.Net.Sockets.Socket;

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
            functions.Add("n", new ForN());
            functions.Add("not", new ForNot());
            functions.Add("cmd", new ForCmd());
            functions.Add("get_keyf", new ForGetKeyF());
            functions.Add("num_to_char", new ForIntToChar());
            functions.Add("get_arg", new ForGetConsoleArg());
            functions.Add("exec_st", new AstStatementExec());
            functions.Add("byte", new ToByteArray());
            functions.Add("to_obj", new ForToObject());
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

                case "np":
                    {
                        try
                        {
                            functions.Add("dot", new ForNpDot());
                            functions.Add("exp", new ForNpExp());
                        }
                        catch
                        {
                            functions.Remove("dot");
                            functions.Remove("exp");
                            functions.Add("dot", new ForNpDot());
                            functions.Add("exp", new ForNpExp());
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
                case "gtk":
                    {
                        try
                        {
                            functions.Add("gtk_init", new GtkInit());
                            functions.Add("gtk_window", new GtkWindow());
                            functions.Add("gtk_run", new GtkAppRun());
                            functions.Add("gtk_button", new GtkButton());
                            functions.Add("gtk_label", new GtkLabel());
                            functions.Add("gtk_example", new GtkExample());
                        }
                        catch
                        {
                            functions.Remove("gtk_init");
                            functions.Remove("gtk_window");
                            functions.Remove("gtk_run");
                            functions.Remove("gtk_button");
                            functions.Remove("gtk_label");
                            functions.Remove("gtk_example");
                            functions.Add("gtk_init", new GtkInit());
                            functions.Add("gtk_window", new GtkWindow());
                            functions.Add("gtk_run", new GtkAppRun());
                            functions.Add("gtk_button", new GtkButton());
                            functions.Add("gtk_label", new GtkLabel());
                            functions.Add("gtk_example", new GtkExample());
                        }
                        break;
                    }
                case "winapi":
                    {
                        try
                        {
                            functions.Add("title", new ForConsoleTitle());
                            functions.Add("color", new ForConsoleColor());
                            functions.Add("reset_color", new ForResetConsoleColor());
                            functions.Add("beep", new ForBeep());
                            functions.Add("clear", new ForClear());
                            functions.Add("set_cursor_position", new ForSetCursorPosition());
                            functions.Add("set_window_size", new ForWindowSize());
                            functions.Add("set_window_pos", new ForWindowPos());
                        }
                        catch
                        {
                            functions.Remove("title");
                            functions.Remove("color");
                            functions.Remove("reset_color");
                            functions.Remove("beep");
                            functions.Remove("clear");
                            functions.Remove("set_cursor_position");
                            functions.Remove("set_window_size");
                            functions.Remove("set_window_pos");

                            functions.Add("title", new ForConsoleTitle());
                            functions.Add("color", new ForConsoleColor());
                            functions.Add("reset_color", new ForResetConsoleColor());
                            functions.Add("beep", new ForBeep());
                            functions.Add("clear", new ForClear());
                            functions.Add("set_cursor_position", new ForSetCursorPosition());
                            functions.Add("set_window_size", new ForWindowSize());
                            functions.Add("set_window_pos", new ForWindowPos());
                        }
                        break;
                    }
                case "net":
                    {
                        try
                        {
                            functions.Add("get_request", new ForNetGetRequest());
                            functions.Add("post_request", new ForPostGetRequest());
                        }
                        catch
                        {
                            functions.Remove("get_request");
                            functions.Remove("post_request");
                            functions.Add("get_request", new ForNetGetRequest());
                            functions.Add("post_request", new ForPostGetRequest());
                        }
                        break;
                    }
                case "files":
                    {
                        try
                        {
                            functions.Add("read_byte", new ForFileReadByte());
                            functions.Add("write_byte", new ForFileWriteByte());
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
                            functions.Remove("read_byte");
                            functions.Remove("write_byte");
                            functions.Remove("delete");
                            functions.Remove("append_text");
                            functions.Remove("open");
                            functions.Add("read", new ForFileReadAll());
                            functions.Add("write", new ForFileWriteAll());
                            functions.Add("delete", new ForFileDelete());
                            functions.Add("append_text", new ForFileAppendAll());
                            functions.Add("open", new ForFilesOpenWithArg());
                            functions.Add("read_byte", new ForFileReadByte());
                            functions.Add("write_byte", new ForFileWriteByte());
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
                case "cs":
                    {
                        try
                        {
                            functions.Add("exec_cs_method", new ExecuteCsMethod());
                            functions.Add("get_cs_class_inst", new GetCsClassInstance());
                            functions.Add("import_cs_class", new ImportCsClass());
                            functions.Add("ez_exec_cs_method", new EasyExecuteCsMethod());
                        }

                        catch
                        {
                            functions.Remove("exec_cs_method");
                            functions.Remove("get_cs_class_inst");
                            functions.Remove("import_cs_class");
                            functions.Remove("ez_exec_cs_method");
                            functions.Add("exec_cs_method", new ExecuteCsMethod());
                            functions.Add("get_cs_class_inst", new GetCsClassInstance());
                            functions.Add("import_cs_class", new ImportCsClass());
                            functions.Add("ez_exec_cs_method", new EasyExecuteCsMethod());
                        }
                        break;
                    }
                case "ast":
                    {
                        try
                        {
                            functions.Add("ast_statement_exec", new AstStatementExec());
                            functions.Add("ast_block_exec", new AstBlockExec());
                            functions.Add("ast_expr_eval", new AstExprEval());
                            functions.Add("ast_binary_op", new AstBinaryOp());
                            functions.Add("ast_unart_op", new AstUnaryOp());
                            functions.Add("ast_suffix_op", new AstSuffixOp());
                            functions.Add("ast_value_expr", new AstValueExpr());
                            functions.Add("ast_stack_op", new AstStackOp());
                            functions.Add("ast_funct_op", new AstFunctOp());
                            functions.Add("ast_eq_op", new AstEqOp());
                            functions.Add("ast_dict_op", new AstDictOp());
                            functions.Add("ast_ddot_op", new AstDdotOp());
                            functions.Add("ast_const_op", new AstConstOp());
                            functions.Add("ast_class_op", new AstClassOp());
                            functions.Add("ast_array_op", new AstArrayOp());
                        }
                        catch
                        {
                            functions.Remove("ast_statement_exec");
                            functions.Remove("ast_block_exec");
                            functions.Remove("ast_expr_eval");
                            functions.Remove("ast_binary_op");
                            functions.Remove("ast_unart_op");
                            functions.Remove("ast_suffix_op");
                            functions.Remove("ast_value_expr");
                            functions.Remove("ast_stack_op");
                            functions.Remove("ast_funct_op");
                            functions.Remove("ast_eq_op");
                            functions.Remove("ast_dict_op");
                            functions.Remove("ast_ddot_op");
                            functions.Remove("ast_const_op");
                            functions.Remove("ast_class_op");
                            functions.Remove("ast_array_op");

                            functions.Add("ast_statement_exec", new AstStatementExec());
                            functions.Add("ast_block_exec", new AstBlockExec());
                            functions.Add("ast_expr_eval", new AstExprEval());
                            functions.Add("ast_binary_op", new AstBinaryOp());
                            functions.Add("ast_unart_op", new AstUnaryOp());
                            functions.Add("ast_suffix_op", new AstSuffixOp());
                            functions.Add("ast_value_expr", new AstValueExpr());
                            functions.Add("ast_stack_op", new AstStackOp());
                            functions.Add("ast_funct_op", new AstFunctOp());
                            functions.Add("ast_eq_op", new AstEqOp());
                            functions.Add("ast_dict_op", new AstDictOp());
                            functions.Add("ast_ddot_op", new AstDdotOp());
                            functions.Add("ast_const_op", new AstConstOp());
                            functions.Add("ast_class_op", new AstClassOp());
                            functions.Add("ast_array_op", new AstArrayOp());
                        }
                        break;
                    }
                case "threading":
                    {
                        try
                        {
                            functions.Add("create_thread", new CreateThread());
                            functions.Add("start_thread", new StartThread());
                            functions.Add("get_curr_thread", new GetCurrThread());
                            functions.Add("abort_thread", new AbortThread());
                            functions.Add("join_thread", new JoinThread());
                        }
                        catch
                        {
                            functions.Remove("create_thread");
                            functions.Remove("start_thread");
                            functions.Remove("get_curr_thread");
                            functions.Remove("abort_thread");
                            functions.Remove("join_thread");
                            functions.Add("create_thread", new CreateThread());
                            functions.Add("start_thread", new StartThread());
                            functions.Add("get_curr_thread", new GetCurrThread());
                            functions.Add("abort_thread", new AbortThread());
                            functions.Add("join_thread", new JoinThread());
                        }
                        break;
                    }
                case "socket":
                    {
                        try
                        {
                            functions.Add("new_socket", new ForNewSocket());
                            functions.Add("socket_shutdown", new ForSocketShutdown());
                            functions.Add("socket_close", new ForSocketClose());
                            functions.Add("socket_connect", new ForSocketConnect());
                            functions.Add("socket_accept", new ForSocketAccept());
                            functions.Add("socket_bind", new ForSocketBind());
                            functions.Add("socket_listen", new ForSocketListen());
                            functions.Add("socket_recieve", new ForSocketRecieve());
                            functions.Add("socket_send", new ForSocketSend());
                            functions.Add("socket_ip_create", new ForIpCreate());
                            functions.Add("socket_get_socket", new ForGetSocket());
                        }
                        catch
                        {
                            functions.Add("new_socket", new ForNewSocket());
                            functions.Add("socket_shutdown", new ForSocketShutdown());
                            functions.Add("socket_close", new ForSocketClose());
                            functions.Add("socket_connect", new ForSocketConnect());
                            functions.Add("socket_accept", new ForSocketAccept());
                            functions.Add("socket_bind", new ForSocketBind());
                            functions.Add("socket_listen", new ForSocketListen());
                            functions.Add("socket_recieve", new ForSocketRecieve());
                            functions.Add("socket_send", new ForSocketSend());
                            functions.Add("socket_ip_create", new ForIpCreate());
                            functions.Add("socket_get_ip", new ForGetSocket());
                            functions.Remove("new_socket");
                            functions.Remove("socket_shutdown");
                            functions.Remove("socket_close");
                            functions.Remove("socket_connect");
                            functions.Remove("socket_accept");
                            functions.Remove("socket_bind");
                            functions.Remove("socket_listen");
                            functions.Remove("socket_recieve");
                            functions.Remove("socket_send");
                            functions.Remove("socket_ip_create");
                            functions.Remove("socket_get_socket");
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
                            
                            functions.Add("as_var", new ForAsVar());
                            functions.Add("new_stack", new ForStack());
                            functions.Add("get_stack", new ForGetStack());
                            functions.Add("append", new ForStackAppend());
                            functions.Add("get_by_index", new ForGetByIndexStack());
                            functions.Add("new_arr", new ForArray());
                            functions.Add("get_by_key", new ForDictionaryGetByElement());
                            functions.Add("new_dictionary", new ForDictionary());
                            functions.Add("add", new ForDictionaryAppend());
                            functions.Add("get_arr", new ForArrayGet());
                            functions.Add("get_barr", new ForGetByteArray());
                            functions.Add("to_bool", new ForToBool());
                            functions.Add("exit", new ForExit());
                            functions.Add("sleep", new ForSleep());
                            functions.Add("key_press", new ForKeyPress());
                            functions.Add("sout_element", new ForWriteTableElement());
                            functions.Add("eval", new ForEval());
                            functions.Add("length", new ForArrayLength());
                            functions.Add("split", new ForSplit());
                            functions.Add("variable", new ForAddVariable());
                            functions.Add("get_var_by_name", new ForGetVarByName());
                        }
                        catch
                        {
                            functions.Remove("get_barr");
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
                            functions.Remove("new_stack");
                            functions.Remove("get_stack");
                            functions.Remove("append");
                            functions.Remove("get_by_index");
                            functions.Remove("variable");
                            functions.Remove("get_var_by_name");
                            functions.Remove("as_var");
                            functions.Remove("get_by_key");
                            functions.Remove("new_dictionary");
                            functions.Remove("add");
                            functions.Remove("to_bool");

                            functions.Add("get_barr", new ForGetByteArray());
                            functions.Add("to_bool", new ForToBool());
                            functions.Add("as_var", new ForAsVar());
                            functions.Add("get_var_by_name", new ForGetVarByName());
                            functions.Add("variable", new ForAddVariable());
                            functions.Add("get_by_index", new ForGetByIndexStack());
                            functions.Add("new_stack", new ForStack());
                            functions.Add("get_stack", new ForGetStack());
                            functions.Add("append", new ForStackAppend());
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
                            functions.Add("get_by_key", new ForDictionaryGetByElement());
                            functions.Add("new_dictionary", new ForDictionary());
                            functions.Add("add", new ForDictionaryAppend());
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
            if (Variables.isExists(key))
            {
                set(key, (Ldef)((ObjectValue)Variables.get(key)).asObject());
                Function function = functions[key];
                functions.Remove(key);
                return function;
            }
            if (!isExists(key)) throw new System.Exception("Unknown function " + key);
            
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

    public class ForToObject : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(args[0].asObject());
        }
    }

    public class ForGetByteArray : Function
    {
        public Value execute(Value[] args)
        {
            return ((ByteValue)args[0]).asArray();
        }
    }

    public class ForSocketSend : Function
    {
        public Value execute(Value[] args)
        {
            Socket client = (Socket)((ObjectValue)args[0]).asObject();
            int output = client.Send(Encoding.UTF8.GetBytes(args[1].asString()), SocketFlags.None);
            return new NumberValue(output);
        }
    }

    public class ForSocketRecieve : Function
    {
        public Value execute(Value[] args)
        {
            Socket client = (Socket)((ObjectValue)args[0]).asObject();
            var buffer = new byte[1024];
            var output = client.Receive(buffer, SocketFlags.None);
            return new StringValue(Encoding.UTF8.GetString(buffer, 0, output));
        }
    }

    public class ForSocketListen : Function
    {
        public Value execute(Value[] args)
        {
            Socket client = (Socket)((ObjectValue)args[0]).asObject();
            client.Listen(args[1].asNumber());
            return new NumberValue(0);
        }
    }

    public class ForSocketBind : Function
    {
        public Value execute(Value[] args)
        {
            Socket client = (Socket)((ObjectValue)args[0]).asObject();
            IPEndPoint iPEndPoint = (IPEndPoint)((ObjectValue)args[1]).asObject();
            client.Bind(iPEndPoint);
            return new NumberValue(0);
        }
    }

    public class ForSocketAccept : Function
    {
        public Value execute(Value[] args)
        {
            Socket client = (Socket)((ObjectValue)args[0]).asObject();
            Socket handler = client.Accept();
            return new ObjectValue(handler);
        }
    }

    public class ForSocketConnect : Function
    {
        public Value execute(Value[] args)
        {
            Socket client = (Socket)((ObjectValue)args[0]).asObject();
            client.Connect((IPEndPoint)((ObjectValue)args[1]).asObject());
            return new NumberValue(0);
        }
    }

    public class ForSocketClose : Function
    {
        public Value execute(Value[] args)
        {
            Socket client = (Socket)((ObjectValue)args[0]).asObject();
            client.Close();
            return new NumberValue(0);
        }
    }

    public class ForSocketShutdown : Function
    {
        public Value execute(Value[] args)
        {
            Socket client = (Socket)((ObjectValue)args[0]).asObject();
            client.Shutdown(SocketShutdown.Both);
            return new NumberValue(0);
        }
    }

    public class ForIpCreate : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new IPEndPoint(IPAddress.Parse(args[0].asString()), args[1].asNumber()));
        }
    }

    public class ForGetSocket : Function
    {
        public Value execute(Value[] args)
        {
            Socket client = (Socket)((ObjectValue)args[0]).asObject();
            return new StringValue(client.RemoteEndPoint.ToString());
        }
    }

    public class ForNewSocket : Function
    {
        public Value execute(Value[] args)
        {
            AddressFamily addressFamily = (AddressFamily)((ObjectValue)args[0]).asObject();
            SocketType socketType = (SocketType)((ObjectValue)args[1]).asObject();
            ProtocolType protocolType = (ProtocolType)((ObjectValue)args[2]).asObject();
            Socket socket = new Socket(addressFamily, socketType, protocolType);
            return new ObjectValue(socket);
        }
    }

    public class GtkInit : Function
    {
        public Value execute(Value[] args)
        {
            Gtk.Application.Init();
            return new NumberValue(0);
        }
    }

    public class GtkAppRun : Function
    {
        public Value execute(Value[] args)
        {
            Gtk.Application.Run();
            return new NumberValue(0);
        }
    }

    public class GtkLabel : Function
    {
        public Value execute(Value[] args)
        {
            Gtk.Label label = new Gtk.Label();
            label.Text = args[0].ToString();
            Gtk.Window window = (Gtk.Window)((ObjectValue)args[1]).asObject();
            window.Add(label);
            window.ShowAll();
            return new ObjectValue(label);
        }
    }

    public class GtkButton : Function
    {
        public Value execute(Value[] args)
        {
            Gtk.Button label = new Gtk.Button();
            label.Label = args[0].ToString();
            Gtk.Window window = (Gtk.Window)((ObjectValue)args[1]).asObject();
            window.Add(label);
            window.ShowAll();
            return new ObjectValue(label);
        }
    }

    public class GtkWindow : Function
    {
        public Value execute(Value[] args)
        {
            Window newWindow = new Window(args[0].asString());
            newWindow.Resize(args[1].asNumber(), args[2].asNumber());
            return new ObjectValue(newWindow);
        }
    }

    public class GtkExample : Function
    {
        public Value execute(Value[] args)
        {
            Gtk.Application.Init();
            Window myWin = new Window("My first GTK-O Application! ");
            myWin.Resize(200, 200);
            Gtk.Label myLabel = new Gtk.Label();
            myLabel.Text = "Hello World!!!!";
            myWin.Add(myLabel);
            myWin.ShowAll();
            Gtk.Application.Run();
            return new NumberValue(0);
        }
    }

    public class ToByteArray : Function
    {
        public Value execute(Value[] args)
        {
            if (!(args[0] is StringValue))
                return new ByteValue(ByteValue.GetBytesFromObj(args[0]));
            return new ByteValue(ByteValue.GetBytes(args[0].asString()));
        }
    }

    public class ForGetConsoleArg : Function
    {
        public Value execute(Value[] args)
        {
            int index = int.Parse(args[0].asString());
            return new ObjectValue(CommandLineArgs.args[index]);
        } 
    }

    public class AstBlockExec : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            BlockStatement st = (BlockStatement)((ObjectValue)args[0]).asObject();
            st.execute();
            return ZERO;
        }
    }

    public class AstStatementExec : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            try
            {
                Statement st = (Statement)((ObjectValue)args[0]).asObject();
                st.execute();
                return ZERO;
            }
            catch
            {
                ((StatementValue)args[0]).asStatement().execute();
                return ZERO;
            }
        }
    }

    public class AstExprEval : Function
    {
        public Value execute(Value[] args)
        {
            Expression expr = (Expression)((ObjectValue)args[0]).asObject();
            return new ObjectValue(expr.eval());
        }
    }

    public class AstClassOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new ClassExpression(args[0].asString()));
        }
    }

    public class AstConstOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new ConstantExpression(args[0].asString()));
        }
    }

    public class AstDdotOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new DdotExpression(args[0].asString(), args[1].asString()));
        }
    }

    public class AstArrayOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new ArrayAccesExpression(args[0].asString(), new ValueExpression(args[1])));
        }
    }

    public class AstDictOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new DictionaryAccesExpression(args[0].asString(), new ValueExpression(args[1])));
        }
    }

    public class AstEqOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new ForEqExpression(args[0].asChar(), new ValueExpression(args[1]), new ValueExpression(args[2])));
        }
    }

    public class AstStackOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new StackAccesExpression(args[0].asString(), new ValueExpression(args[1])));
        }
    }

    public class AstFunctOp : Function
    {
        public Value execute(Value[] args)
        {
            List<Expression> fargs = new List<Expression>();
            foreach(Value val in (ArrayValue)args[1])
            {
                fargs.Add(new ValueExpression(val));
            }
            return new ObjectValue(new FunctionalExpression(args[0].asString(), fargs));
        }
    }

    public class AstSuffixOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new SuffixExpression(args[0].asChar(), new ValueExpression(args[1])));
        }
    }

    public class AstUnaryOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new UnaryExpression(args[0].asChar(), new ValueExpression(args[1])));
        }
    }

    public class AstBinaryOp : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new BinaryExpression(args[0].asChar(), new ValueExpression(args[1]), new ValueExpression(args[2])));
        }
    }

    public class AstValueExpr : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(new ValueExpression(args[0]));
        }
    }




    public class CreateThread : Function
    {
        public Value execute(Value[] args)
        {
            FunctionalExpression function = new FunctionalExpression(args[0].asString());
            List<Value> argsth = ((StackValue)args[1]).get().ToList();
            Thread thread = new Thread(new ThreadStart(function.void_eval));
            return new ObjectValue(thread);
        }
    }

    public class StartThread : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Thread th = (Thread)(((ObjectValue)args[0]).asObject());
            th.Start();
            return ZERO;
        }
    }

    public class AbortThread : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Thread th = (Thread)(((ObjectValue)args[0]).asObject());
            th.Abort();
            return ZERO;
        }
    }

    public class JoinThread : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Thread th = (Thread)(((ObjectValue)args[0]).asObject());
            th.Join();
            return ZERO;
        }
    }

    public class GetCurrThread : Function
    {
        public Value execute(Value[] args)
        {
            return new ObjectValue(Thread.CurrentThread);
        }
    }

    public class EasyExecuteCsMethod : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Assembly a = Assembly.Load(args[0].asString());
            object instance = a.CreateInstance(args[1].asString());
            Type type = a.GetType(args[1].ToString());
            MethodInfo mi = type.GetMethod(args[2].asString());
            if (mi == null)
            {
                return new NumberValue(0);
            }
            StackValue stack = (StackValue)args[3];
            List<object> values = new List<object>();
            foreach (Value val in stack.getElements())
            {
                try
                {
                    StringValue str = (StringValue)val;
                    values.Add(str.asString());
                }
                catch
                {
                    try
                    {
                        NumberValue str = (NumberValue)val;
                        values.Add(str.asNumber());
                    }
                    catch
                    {
                        BoolValue str = (BoolValue)val;
                        values.Add(str.asBool());
                    }
                }
            }
            //return new ObjectValue(mi.Invoke(((ObjectValue)args[1]).asObject(), values.ToArray()));
            return new ObjectValue(mi.Invoke(instance, values.ToArray()));
        }
    }

    public class ExecuteCsMethod : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            object t0 = ((ObjectValue)args[0]).asObject();
            Type t = (Type)t0;
            MethodInfo mi = t.GetMethod(args[2].asString());
            StackValue stack = (StackValue)args[3];
            List<object> values = new List<object>();
            foreach (Value val in stack.getElements())
            {
                try
                {
                    StringValue str = (StringValue)val;
                    values.Add(str.asString());
                }
                catch
                {
                    try
                    {
                        NumberValue str = (NumberValue)val;
                        values.Add(str.asNumber());
                    }
                    catch
                    {
                        BoolValue str = (BoolValue)val;
                        values.Add(str.asBool());
                    }
                }
            }
            return new ObjectValue(mi.Invoke( ((ObjectValue)args[1]).asObject(), values.ToArray() ));
        }
    }

    public class GetCsClassInstance : Function 
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Assembly a = Assembly.Load(args[0].asString());
            object instance = a.CreateInstance(args[1].asString());

            return new ObjectValue(instance);
        }
    }

    public class ImportCsClass : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        
        public Value execute(Value[] args)
        {
            Assembly a = Assembly.Load(args[0].asString());
            Type type = a.GetType(args[1].asString());
            
            return new ObjectValue(type);
        }
    }

    public class Sin : Function
    {
        public Value execute(Value[] args)
        {
            if (args.Length != 1) throw new System.Exception("One arg expected");
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

    public class ForAsVar : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            return new StringValue(Variables.get(args[0].ToString()).ToString());
        }
    }

    public class ForStop : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            if (args.Length != 0) throw new Exception("Zero args expected");
            char key = Console.ReadKey(true).KeyChar;
            return new StringValue(key.ToString());
        }
    }

    public class ForGetKeyF : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            if (args.Length != 0) throw new Exception("Zero args expected");
            int key = Console.ReadKey(true).KeyChar;
            return new NumberValue(key);
        }
    }

    public class ForIntToChar : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            return new StringValue(((char)args[0].asNumber()).ToString());
        }
    }

    public class ForRandomInt : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        public Value execute(Value[] args)
        {
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
            Stack<string> a = new Stack<string>(args[0].ToString().Split(Char.Parse(args[1].ToString())));
            Stack<StringValue> strings = new Stack<StringValue>();
            foreach (string lol in a) 
            {
                strings.Push(new StringValue(lol));
            }
            return new ArrayValue(strings.ToArray());
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
            try
            {
                Value var = Variables.get(args[0].ToString());
                ArrayValue array = (ArrayValue)var;
                return new NumberValue(array.get().Length);
            }
            catch
            {
                Value var = Variables.get(args[0].ToString());
                StackValue array = (StackValue)var;
                return new NumberValue(array.get().Count);
            }
            
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

    public class ForFileReadByte : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            ByteValue bytearr = new ByteValue(File.ReadAllBytes(args[0].ToString()));
            return bytearr;
        }
    }

    public class ForFileWriteByte : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            File.WriteAllBytes(args[0].ToString(), ((ByteValue)(args[1])).asByteArray());
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

    public class ForNetGetRequest : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(args[0].ToString());
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

    public class ForPostGetRequest : Function
    {
        private static NumberValue ZERO = new NumberValue(0);
        private static readonly HttpClient httpClient = new HttpClient();
        public Value execute(Value[] args)
        {
            Dictionary<string, Value> dict = ((DictionaryValue)args[0]).get();
            Dictionary<string, string> newdict = new Dictionary<string, string>();

            foreach(KeyValuePair<string, Value> pair in dict)
            {
                newdict.Add(pair.Key, pair.Value.asString());
            }

            var content = new FormUrlEncodedContent(newdict);
            var response = (HttpResponseMessage)GetResponsePostRequest(args[1].asString(), content);
            var responseStr = response.Content.ReadAsStringAsync();
            return new StringValue(responseStr.Result);
        }

        private object GetResponsePostRequest(string url, object content)
        {
            var response = httpClient.PostAsync(url, (HttpContent)content);
            return response;
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
            object result = JsMath.Eval(args[1].ToString());
                
            switch(args[0].ToString())
            {
                case "string":
                    return new StringValue(result.ToString());
                case "number":
                    return new NumberValue((double)result);
                default:
                    return ZERO;
            }
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

    public class ForDictionary : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            return new DictionaryValue(new Dictionary<string, Value>());
        }
    }

    public class ForDictionaryGetByElement : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            DictionaryValue dictionary = (DictionaryValue)Variables.get(args[0].ToString());
            return dictionary.get_by_index(args[1].ToString());
        }
    }

    public class ForDictionaryAppend : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Value var = Variables.get(args[0].ToString());
            DictionaryValue array = (DictionaryValue)var;
            //array.append(args[1].ToString(), args[2]);
            Variables.set(args[0].ToString(), new DictionaryValue(array.append(args[1].ToString(), args[2])));
            //Variables.set(args[1].ToString(), args[2]);

            return ZERO;
        }
    }

    public class ForStack : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            return new StackValue(new Stack<Value>(args));
        }
    }

    public class ForStackAppend : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Value var = Variables.get(args[0].ToString());
            StackValue array = (StackValue)var;
            Variables.set(args[0].ToString(), new StackValue(array.append(args[1])));

            return ZERO;
        }
    }

    public class ForGetStack : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            StringBuilder str = new StringBuilder();
            Value var = Variables.get(args[0].ToString());
            StackValue array = (StackValue)var;
            str.Append("{");
            for (int i = 0; i < array.get().Count; i++)
            {
                str.Append(" " + new StringValue(array.get().ToArray()[i].asString()) + ";");
            }
            str.Append("}");
            return new StringValue(str.ToString());
        }
    }

    public class ForGetByIndexStack : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Value var = Variables.get(args[0].ToString());
            StackValue array = (StackValue)var;
            return new StringValue(array.get_by_index(int.Parse(args[1].ToString())).ToString());
        }
    }

    public class ForAddVariable : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Variables.set(args[0].ToString(), args[1]);
            return ZERO;
        }
    }

    public class ForGetVarByName : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            return Variables.get(args[0].ToString());
        }
    }

    public class ForN : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            return args[0];
        }
    }

    public class ForNot : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            if (args[0].asNumber() == 0)
                return new BoolValue(true);
            if (args[0].asNumber() == 1)
                return new BoolValue(false);
            else
            {
                throw new Exception("Bool Exception");
            }
        }
    }

    public class ForToBool : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            if (args[0].asNumber() == 0)
                return new BoolValue(false);
            if (args[0].asNumber() == 1)
                return new BoolValue(true);
            else
            {
                throw new Exception("Bool Exception");
            }
        }
    }

    public class ForSetCursorPosition : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Console.SetCursorPosition(int.Parse(args[0].ToString()), int.Parse(args[1].ToString()));
            return ZERO;
        }
    }

    public class ForClear : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Console.Clear();
            return ZERO;
        }
    }

    public class ForWindowSize : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Console.SetWindowSize(int.Parse(args[0].ToString()), int.Parse(args[1].ToString()));
            return ZERO;
        }
    }

    public class ForWindowPos : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Console.SetWindowPosition(int.Parse(args[0].ToString()), int.Parse(args[1].ToString()));
            return ZERO;
        }
    }

    public class ForBeep : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Console.Beep();
            return ZERO;
        }
    }

    public class ForResetConsoleColor : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Console.ResetColor();
            return ZERO;
        }
    }

    public class ForConsoleColor : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            if (args[0].ToString() == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (args[0].ToString() == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (args[0].ToString() == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            return ZERO;
        }
    }

    public class ForCmd : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            Process.Start("cmd.exe", "/C " + args[0].ToString());

            return ZERO;
        }
    }

    public class ForNpDot : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            int n = args[0].asNumber();

            double result = 0;

            try
            {
                ArrayValue vector1 = (ArrayValue)Variables.get(args[1].ToString());
                ArrayValue vector2 = (ArrayValue)Variables.get(args[2].ToString());
                for (int i = 0; i < n; ++i)
                    result += vector1.get_by_index(i).asNumber() * vector2.get_by_index(i).asNumber();
                return new NumberValue(result);
            }
            catch
            {
                StackValue vector1 = (StackValue)Variables.get(args[1].ToString());
                StackValue vector2 = (StackValue)Variables.get(args[2].ToString());
                
                for (int i = 0; i < n; ++i)
                    result += vector1.get_by_index(i).asNumber() * vector2.get_by_index(i).asNumber();
                return new NumberValue(result);
            }


            //return new NumberValue(result);
        }
    }

    public class ForNpExp : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value execute(Value[] args)
        {
            return new NumberValue(Math.Exp(args[0].asDouble()));
        }
    }
}
/*  
    
    This is the multiline comment.
    Why?
    IDK.
    
*/
