﻿#pragma checksum "..\..\..\CreateWindown.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F109866948FCE463BBF8F58DD35E8D3FBEC747D2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AssignmentGroup;
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


namespace AssignmentGroup {
    
    
    /// <summary>
    /// CreateWindown
    /// </summary>
    public partial class CreateWindown : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\CreateWindown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtYear;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\CreateWindown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSellingPrice;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\CreateWindown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPresentPrice;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\CreateWindown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKmDriven;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\CreateWindown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbFuelType;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\CreateWindown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbSellerType;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\CreateWindown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbTransmission;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\CreateWindown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbOwner;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\CreateWindown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AssignmentGroup;component/createwindown.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreateWindown.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtYear = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtSellingPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtPresentPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtKmDriven = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbbFuelType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cbbSellerType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cbbTransmission = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cbbOwner = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\CreateWindown.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

