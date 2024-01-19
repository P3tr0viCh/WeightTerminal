using static P3tr0viCh.Utils.Converters;
using System.ComponentModel;
using P3tr0viCh.Utils;

namespace WeightTerminal
{
    public static class Enums
    {
        [TypeConverter(typeof(EnumDescriptionConverter))]
        public enum TerminalType
        {
            [Description("Отключено")]
            None = ScaleTerminal.TerminalType.None,
            [Description("Ньютон-42")]
            Newton42 = ScaleTerminal.TerminalType.Newton42,
            [Description("МИДЛ МИ ВДА/12Я")]
            MidlVda12 = ScaleTerminal.TerminalType.MidlVda12,
            [Description("Микросим М0601")]
            MicrosimM0601 = ScaleTerminal.TerminalType.MicrosimM0601,
        }
    }
}