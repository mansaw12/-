﻿using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace fb.Properties
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = (Settings)SettingsBase.Synchronized((SettingsBase)new Settings());

        public static Settings Default
        {
            get
            {
                Settings defaultInstance = Settings.defaultInstance;
                return defaultInstance;
            }
        }
    }
}
