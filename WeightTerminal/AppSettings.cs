using System.ComponentModel;
using static P3tr0viCh.ScaleTerminal.ScaleTerminal;
using P3tr0viCh.Utils.Converters;
using static WeightTerminal.Enums;
using P3tr0viCh.Utils.Settings;

namespace WeightTerminal
{
    public class AppSettings : SettingsBase<AppSettings>
    {
        [Category("Весовой терминал")]
        [DisplayName("Порт")]
        [Description("COM-порт")]
        [TypeConverter(typeof(ComPortStringConverter))]
        public string ComPortName { get; set; } = string.Empty;

        [Category("Весовой терминал")]
        [DisplayName("Терминал")]
        [Description("Тип терминала")]
        public TerminalType TerminalType { get; set; } = TerminalType.None;

        [Category("Весовой терминал")]
        [DisplayName("Единицы измерения")]
        [Description("Единицы измерения терминала")]
        public MassUnit TerminalMassUnit { get; set; } = MassUnit.tn;

        // ------------------------------------------------------------------------------------------------------------
        [Category("Формат")]
        [DisplayName("Единицы измерения")]
        [Description("Единицы измерения в окне программы")]
        public MassUnit OutputMassUnit { get; set; } = MassUnit.tn;

        // ------------------------------------------------------------------------------------------------------------
        [Category("Каналы")]
        [DisplayName("Количество")]
        [Description("Количество каналов в окне программы")]
        public ChannelCount ChannelCount { get; set; } = ChannelCount.Four;

        [Category("Каналы")]
        [DisplayName("Канал 1")]
        [Description("Канал 1 в окне программы")]
        public Channel Channel1 { get; set; } = Channel.LeftFar;
        [Category("Каналы")]
        [DisplayName("Канал 2")]
        [Description("Канал 2 в окне программы")]
        public Channel Channel2 { get; set; } = Channel.RightFar;
        [Category("Каналы")]
        [DisplayName("Канал 3")]
        [Description("Канал 3 в окне программы")]
        public Channel Channel3 { get; set; } = Channel.LeftNear;
        [Category("Каналы")]
        [DisplayName("Канал 4")]
        [Description("Канал 4 в окне программы")]
        public Channel Channel4 { get; set; } = Channel.RightNear;
    }
}