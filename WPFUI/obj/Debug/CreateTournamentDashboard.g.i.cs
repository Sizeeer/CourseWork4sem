﻿#pragma checksum "..\..\CreateTournamentDashboard.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2BA11CAE8873E4C470441E32707E9EBD7DBF8BE2D294B4FCC223A72419AE22E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPFUI;


namespace WPFUI {
    
    
    /// <summary>
    /// CreateTournamentDashboard
    /// </summary>
    public partial class CreateTournamentDashboard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\CreateTournamentDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbLoadExistingTournament;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\CreateTournamentDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_loadTournament;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CreateTournamentDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_createTournament;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFUI;component/createtournamentdashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateTournamentDashboard.xaml"
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
            this.cbLoadExistingTournament = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.button_loadTournament = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\CreateTournamentDashboard.xaml"
            this.button_loadTournament.Click += new System.Windows.RoutedEventHandler(this.btnLoadTournament_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.button_createTournament = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\CreateTournamentDashboard.xaml"
            this.button_createTournament.Click += new System.Windows.RoutedEventHandler(this.btnCreateTournament_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

