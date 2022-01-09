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
    public class Classes
    {
        private static Dictionary<string, Class> classes;

        static Classes()
        {
            classes = new Dictionary<string, Class>();
        }

        public static bool isExists(string key)
        {
            return classes.ContainsKey(key);
        }

        public static Class get(string key)
        {
            if (!isExists(key)) throw new Exception("Unknown class " + key);
            return classes[key];
        }

        public static void set(string key, Class classess)
        {
            try
            {
                classes.Add(key, classess);
            }
            catch
            {
                classes.Remove(key);
                classes.Add(key, classess);
            }
        }
    }
}
