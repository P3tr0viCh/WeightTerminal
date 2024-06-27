using static P3tr0viCh.ScaleTerminal.ScaleTerminal;

namespace WeightTerminal
{
    public static partial class Utils
    {
        public static string WeightToStr(int value, MassUnit massUnit)
        {
            switch (massUnit)
            {
                case MassUnit.tn:
                    return (value / 1000.0).ToString("0.000");
                default:
                    return value.ToString();
            }
        }
    }
}