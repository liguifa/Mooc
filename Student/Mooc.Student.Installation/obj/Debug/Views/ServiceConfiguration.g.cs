﻿#pragma checksum "..\..\..\Views\ServiceConfiguration.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6EF37EEDF2EB862684B56A5D234C6D6C"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MMS.UI.Default;
using StudentClient.Installation.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace StudentClient.Installation.Views {
    
    
    /// <summary>
    /// ServiceConfiguration
    /// </summary>
    public partial class ServiceConfiguration : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Views\ServiceConfiguration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MMS.UI.Default.TextBox address;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\ServiceConfiguration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MMS.UI.Default.TextBox port;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\ServiceConfiguration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock serverInstance;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\ServiceConfiguration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MMS.UI.Default.TextBox port;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\ServiceConfiguration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MMS.UI.Default.TextBox username;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Views\ServiceConfiguration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MMS.UI.Default.TextBox password;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Views\ServiceConfiguration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button installBtn;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Views\ServiceConfiguration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StudentClient.Installation;component/views/serviceconfiguration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ServiceConfiguration.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.address = ((MMS.UI.Default.TextBox)(target));
            return;
            case 2:
            this.port = ((MMS.UI.Default.TextBox)(target));
            return;
            case 3:
            this.serverInstance = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.port = ((MMS.UI.Default.TextBox)(target));
            return;
            case 5:
            this.username = ((MMS.UI.Default.TextBox)(target));
            return;
            case 6:
            this.password = ((MMS.UI.Default.TextBox)(target));
            return;
            case 7:
            this.installBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.cancelBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

