﻿#pragma checksum "..\..\..\..\Pages\DietPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "291F1EA3E24B53645A64EE887A19B85866C66ED5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekt;
using Projekt.Pages;
using Projekt.Properties;
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


namespace Projekt.Pages {
    
    
    /// <summary>
    /// DietPage
    /// </summary>
    public partial class DietPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Pages\DietPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Day_textblock;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Pages\DietPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Meals_listview;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\Pages\DietPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Ingredients_listview;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\Pages\DietPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GenerateMeals_button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DietApp;component/pages/dietpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\DietPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Day_textblock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Meals_listview = ((System.Windows.Controls.ListView)(target));
            
            #line 41 "..\..\..\..\Pages\DietPage.xaml"
            this.Meals_listview.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Meals_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Ingredients_listview = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.GenerateMeals_button = ((System.Windows.Controls.Button)(target));
            
            #line 156 "..\..\..\..\Pages\DietPage.xaml"
            this.GenerateMeals_button.Click += new System.Windows.RoutedEventHandler(this.GenerateMeals_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

