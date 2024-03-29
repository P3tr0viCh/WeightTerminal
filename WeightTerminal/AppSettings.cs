﻿using P3tr0viCh.Utils;
using System.ComponentModel;
using WeightTerminal.Properties;
using static P3tr0viCh.Utils.Converters;
using static WeightTerminal.Enums;

namespace WeightTerminal
{
    public class LocalizedCategoryAttribute : CategoryAttribute
    {
        static string Localize(string key)
        {
            return Resources.ResourceManager.GetString(key);
        }

        public LocalizedCategoryAttribute(string key) : base(Localize(key))
        {
        }
    }

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
        public MassUnit TerminalMassUnit { get; set; } = MassUnit.kg;

        [Category("Формат")]
        [DisplayName("Единицы измерения")]
        [Description("Единицы измерения в окне программы")]
        public MassUnit OutputMassUnit { get; set; } = MassUnit.kg;
    }
}