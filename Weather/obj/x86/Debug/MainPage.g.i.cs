﻿#pragma checksum "C:\Users\Александр Сергеевич\Desktop\Проекты\Kodisoft\Weather\Weather\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B38193B3424F83C6C1BF4A152EF4944D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Weather
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page
    {


        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private global::Windows.UI.Xaml.Controls.AppBarButton Settings; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private global::Windows.UI.Xaml.Controls.AppBarButton Update; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel Window; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private global::Windows.UI.Xaml.Controls.GridView Forecast; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock Temp_night; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;

            global::System.Uri resourceLocator = new global::System.Uri("ms-appx:///MainPage.xaml");
            global::Windows.UI.Xaml.Application.LoadComponent(this, resourceLocator, global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
        }

        
        private interface IMainPage_Bindings
        {
            void Initialize();
            void Update();
            void StopTracking();
        }
#pragma warning disable 0169    //  Proactively suppress unused field warning in case Bindings is not used.
        private IMainPage_Bindings Bindings;
#pragma warning restore 0169
    }
}

