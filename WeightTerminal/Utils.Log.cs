using P3tr0viCh.Utils;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WeightTerminal
{
    public static partial class Utils
    {
        public static class Log
        {
            private class InternalLog : DefaultInstance<P3tr0viCh.Utils.Log> { }

            public static void WriteProgramStart() => InternalLog.Default.WriteProgramStart();

            public static void WriteProgramStop() => InternalLog.Default.WriteProgramStop();

            public static void WriteFormOpen(Form frm) => InternalLog.Default.WriteFormOpen(frm);

            public static void WriteFormClose(Form frm) => InternalLog.Default.WriteFormClose(frm);

            public static void Info(string s, [CallerMemberName] string memberName = "")
            {
                s = s.ReplaceEol();

                DebugWrite.Line(s, memberName);

                InternalLog.Default.Write($"{memberName}: {s}");
            }

            public static void Error(Exception e, [CallerMemberName] string memberName = "")
            {
                if (e == null) return;

                Error(e.Message, memberName);

                Error(e.InnerException, memberName);
            }

            public static void Error(string err, [CallerMemberName] string memberName = "")
            {
                err = err.ReplaceEol();

                DebugWrite.Error(err, memberName);

                InternalLog.Default.Write($"{memberName} fail: {err}");
            }
        }
    }
}