using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Base.Helpers
{
    public class Logger
    {
        [Conditional("DEBUG")]
        public static void PringDebug(string msg)
        {
            Console.WriteLine(msg);
        }

        public static string GetFuncName([CallerMemberName]string name = "")
        {
            return name;
        }

    }
}
