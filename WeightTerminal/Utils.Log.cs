using P3tr0viCh.Utils;
using System;
using System.Runtime.CompilerServices;

namespace WeightTerminal
{
    public static partial class Utils
    {
        public static class Log
        {
            private static readonly P3tr0viCh.Utils.Log defaultInstance = new P3tr0viCh.Utils.Log();

            public static P3tr0viCh.Utils.Log Default => defaultInstance;

            public static void Info(string s, [CallerMemberName] string memberName = "")
            {
                var text = string.Format("{0}: {1}", memberName, s);

                DebugWrite.Line(s, memberName);

                Default.Write(text);
            }

            public static void Error(Exception e, [CallerMemberName] string memberName = "")
            {
                if (e == null) return;

                Error(e.Message, memberName);

                Error(e.InnerException, memberName);
            }

            public static void Error(string err, [CallerMemberName] string memberName = "")
            {
                var error = string.Format("{0} fail: {1}", memberName, err);

                DebugWrite.Error(err, memberName);

                Default.Write(error);
            }
        }
    }
}