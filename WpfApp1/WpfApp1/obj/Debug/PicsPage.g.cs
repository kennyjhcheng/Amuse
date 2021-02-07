﻿#pragma checksum "..\..\PicsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "85277A4A157BB98F4586CB327C925E7054C423E3C6E3FC356211B89716C84375"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using MaterialIcons;
using SourceChord.FluentWPF;
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
using WpfAnimatedGif;
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// PicsPage
    /// </summary>
    public partial class PicsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 73 "..\..\PicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\PicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Spinner;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\PicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DislikeButton;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\PicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.IconPacks.PackIconControl DislikeIcon;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\PicsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialIcons.MaterialIcon HeartIcon;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/picspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PicsPage.xaml"
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
            
            #line 21 "..\..\PicsPage.xaml"
            ((WpfApp1.PicsPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.PicsPage_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.image = ((System.Windows.Controls.Image)(target));
            
            #line 76 "..\..\PicsPage.xaml"
            this.image.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Spinner = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.DislikeButton = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\PicsPage.xaml"
            this.DislikeButton.Click += new System.Windows.RoutedEventHandler(this.DislikeButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DislikeIcon = ((MahApps.Metro.IconPacks.PackIconControl)(target));
            return;
            case 6:
            
            #line 157 "..\..\PicsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.HeartIcon = ((MaterialIcons.MaterialIcon)(target));
            return;
            case 8:
            
            #line 182 "..\..\PicsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GoToJoke);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

