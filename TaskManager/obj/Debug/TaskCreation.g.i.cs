﻿#pragma checksum "..\..\TaskCreation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C2AEEC87847F6697902FA45F68E94FA67A398557AF39E5A02DDA0DF01B446109"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using TaskManager;


namespace TaskManager {
    
    
    /// <summary>
    /// TaskCreation
    /// </summary>
    public partial class TaskCreation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\TaskCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox taskTB;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\TaskCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePR;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\TaskCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox catCB;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\TaskCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label def;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\TaskCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label timeLL;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\TaskCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox timeCB;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\TaskCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label timeLLmin;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\TaskCreation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label timeLL_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/TaskManager;component/taskcreation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TaskCreation.xaml"
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
            
            #line 8 "..\..\TaskCreation.xaml"
            ((TaskManager.TaskCreation)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\TaskCreation.xaml"
            ((TaskManager.TaskCreation)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.taskTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.datePR = ((System.Windows.Controls.DatePicker)(target));
            
            #line 26 "..\..\TaskCreation.xaml"
            this.datePR.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.datePR_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 30 "..\..\TaskCreation.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 31 "..\..\TaskCreation.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 32 "..\..\TaskCreation.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.catCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.def = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            
            #line 54 "..\..\TaskCreation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBut_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 57 "..\..\TaskCreation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinWindow_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 69 "..\..\TaskCreation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.timeLL = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.timeCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 14:
            this.timeLLmin = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.timeLL_Copy = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

