using P3tr0viCh.Utils;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System;

namespace WeightTerminal
{
    public static partial class Utils
    {
        public static class Log
        {
            private static readonly P3tr0viCh.Utils.Log defaultInstance = new P3tr0viCh.Utils.Log();

            public static P3tr0viCh.Utils.Log Default
            {
                get
                {
                    return defaultInstance;
                }
            }

            public static void WriteDebug(string s, [CallerMemberName] string memberName = "")
            {
                Debug.WriteLine(memberName + ": " + s);
            }

            public static void Write(string s, [CallerMemberName] string memberName = "")
            {
                var text = string.Format("{0}: {1}", memberName, s);

                Debug.WriteLine(text);

                Default.Write(text);
            }

            public static void WriteError(Exception e, [CallerMemberName] string memberName = "")
            {
                if (e == null) return;

                WriteError(e.Message, memberName);

                WriteError(e.InnerException, memberName);
            }

            public static void WriteError(string err, [CallerMemberName] string memberName = "")
            {
                var error = string.Format("{0} fail: {1}", memberName, err);

                Debug.WriteLine(error);

                Default.Write(error);
            }
        }
    }
}