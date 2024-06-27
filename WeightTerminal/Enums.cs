using static P3tr0viCh.Utils.Converters;
using System.ComponentModel;
using System.Windows.Forms;

namespace WeightTerminal
{
    public class Enums
    {
        public enum Key
        {
            None = Keys.None,
            About = Keys.F1,
            State = Keys.F4,
            Channels = Keys.F10,
            Settings1 = Keys.F8,
            Settings2 = Keys.O | Keys.Control,
        }

        [TypeConverter(typeof(EnumDescriptionConverter))]
        public enum Channel
        {
            [Description("Левый дальний")]
            LeftFar,
            [Description("Правый дальний")]
            RightFar,
            [Description("Левый ближний")]
            LeftNear,
            [Description("Правый ближний")]
            RightNear
        }

        [TypeConverter(typeof(EnumDescriptionConverter))]
        public enum ChannelCount
        {
            [Description("Один (отключено)")]
            One,
            [Description("Два горизонтально")]
            TwoHorizontal,
            [Description("Два вертикально")]
            TwoVertical,
            [Description("Четыре")]
            Four,
        }
    }
}