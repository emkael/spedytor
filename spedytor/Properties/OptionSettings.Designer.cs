﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace spedytor.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class OptionSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static OptionSettings defaultInstance = ((OptionSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new OptionSettings())));
        
        public static OptionSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection DB_NAMES {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["DB_NAMES"]));
            }
            set {
                this["DB_NAMES"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SEND_FLAG {
            get {
                return ((bool)(this["SEND_FLAG"]));
            }
            set {
                this["SEND_FLAG"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public decimal RUN_INTERVAL {
            get {
                return ((decimal)(this["RUN_INTERVAL"]));
            }
            set {
                this["RUN_INTERVAL"] = value;
            }
        }
    }
}
