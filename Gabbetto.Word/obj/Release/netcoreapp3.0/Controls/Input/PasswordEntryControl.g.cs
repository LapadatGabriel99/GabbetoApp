﻿#pragma checksum "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6E30FD230DBB717994F36675128AF11C1CD4A3FB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Fasseto.Word;
using Fasseto.Word.Core;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Fasseto.Word {
    
    
    /// <summary>
    /// PasswordEntryControl
    /// </summary>
    public partial class PasswordEntryControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition LabelColumnDefinition;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Label;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox CurrentPassword;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox NewPassword;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox ConfirmPassword;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Fasseto.Word;component/controls/input/passwordentrycontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LabelColumnDefinition = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 2:
            this.Label = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.CurrentPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 78 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
            this.CurrentPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.CurrentPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NewPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 94 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
            this.NewPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.NewPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ConfirmPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 107 "..\..\..\..\..\Controls\Input\PasswordEntryControl.xaml"
            this.ConfirmPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.ConfirmPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EditButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
