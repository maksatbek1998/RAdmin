﻿#pragma checksum "..\..\..\UserControlFolder\Password.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "01CF2BA37F11A91B0C3FF706DEA434F3DEB8D5A03A2725A34603F39CEF72796A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using RAdminPanel.UserControlFolder;
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


namespace RAdminPanel.UserControlFolder {
    
    
    /// <summary>
    /// Password
    /// </summary>
    public partial class Password : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\UserControlFolder\Password.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal RAdminPanel.UserControlFolder.Password Win;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UserControlFolder\Password.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LogTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UserControlFolder\Password.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PassTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UserControlFolder\Password.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_2;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\UserControlFolder\Password.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_1;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\UserControlFolder\Password.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewPass;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\UserControlFolder\Password.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OldPass;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\UserControlFolder\Password.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_1_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/RAdminPanel;component/usercontrolfolder/password.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControlFolder\Password.xaml"
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
            this.Win = ((RAdminPanel.UserControlFolder.Password)(target));
            
            #line 8 "..\..\..\UserControlFolder\Password.xaml"
            this.Win.Closed += new System.EventHandler(this.Win_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LogTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PassTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.button_2 = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\UserControlFolder\Password.xaml"
            this.button_2.Click += new System.Windows.RoutedEventHandler(this.button_2_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button_1 = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\UserControlFolder\Password.xaml"
            this.button_1.Click += new System.Windows.RoutedEventHandler(this.button_1_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 46 "..\..\..\UserControlFolder\Password.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBlock_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NewPass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.OldPass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.button_1_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\UserControlFolder\Password.xaml"
            this.button_1_Copy.Click += new System.Windows.RoutedEventHandler(this.button_1_Copy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

