using P3tr0viCh.Utils.Extensions;

namespace WeightTerminal
{
    public partial class Utils
    {
        public static class Msg
        {
            public static void Info(string text = "Hello, world!")
            {
                Log.Info(text.SingleLine(), "Msg.Info");

                P3tr0viCh.Utils.Msg.Info(text);
            }

            public static bool Question(string text = "To be or not to be?")
            {
                Log.Info(text.SingleLine(), "Msg.Question");

                var result = P3tr0viCh.Utils.Msg.Question(text);

                Log.Info(result ? "yes" : "no", "Msg.Question");

                return result;
            }

            public static void Error(string text = "Error!")
            {
                Log.Info(text.SingleLine(), "Msg.Error");

                P3tr0viCh.Utils.Msg.Error(text);
            }

            public static void Error(string format, object arg0)
            {
                Error(string.Format(format, arg0));
            }
        }
    }
}