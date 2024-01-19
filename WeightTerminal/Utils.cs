using P3tr0viCh.Utils;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System;

namespace WeightTerminal
{
    public static class Utils
    {
        public static readonly Log Log = new Log();

        public static void WriteDebug(string s, [CallerMemberName] string memberName = "")
        {
            Debug.WriteLine(memberName + ": " + s);
        }

        public static void WriteLog(string s, [CallerMemberName] string memberName = "")
        {
            var text = string.Format("{0}: {1}", memberName, s);

            Debug.WriteLine(text);

            Log.Write(text);
        }

        public static void WriteLogError(Exception e, [CallerMemberName] string memberName = "")
        {
            if (e == null) return;

            WriteLogError(e.Message, memberName);

            WriteLogError(e.InnerException, memberName);
        }

        public static void WriteLogError(string err, [CallerMemberName] string memberName = "")
        {
            var error = string.Format("{0} fail: {1}", memberName, err);

            Debug.WriteLine(error);

            Log.Write(error);
        }
    }
}