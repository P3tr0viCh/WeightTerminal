﻿using P3tr0viCh.Utils;

namespace WeightTerminal
{
    public partial class Utils
    {
        public static class Msg
        {
            public static void Info(string text = "Hello, world!")
            {
                Log.Write(text.Replace("\r\n", Str.Space).Replace("\n", Str.Space).Replace("\r", Str.Space));

                P3tr0viCh.Utils.Msg.Info(text);
            }

            public static void Info(string format, object arg0)
            {
                Info(string.Format(format, arg0));
            }

            public static void Info(string format, object arg0, object arg1)
            {
                Info(string.Format(format, arg0, arg1));
            }

            public static bool Question(string text = "To be or not to be?")
            {
                Log.Write(text.Replace("\r\n", Str.Space).Replace("\n", Str.Space).Replace("\r", Str.Space));

                var result = P3tr0viCh.Utils.Msg.Question(text);

                Log.Write(result ? "yes" : "no");

                return result;
            }

            public static bool Question(string format, object arg0)
            {
                return Question(string.Format(format, arg0));
            }

            public static bool Question(string format, object arg0, object arg1)
            {
                return Question(string.Format(format, arg0, arg1));
            }

            public static void Error(string text = "Error!")
            {
                Log.Default.Write(text.Replace("\r\n", Str.Space).Replace("\n", Str.Space).Replace("\r", Str.Space));

                P3tr0viCh.Utils.Msg.Error(text);
            }

            public static void Error(string format, object arg0)
            {
                Error(string.Format(format, arg0));
            }

            public static void Error(string format, object arg0, object arg1)
            {
                Error(string.Format(format, arg0, arg1));
            }
        }
    }
}