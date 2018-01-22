// -----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

[assembly: Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace RandomList
{
    using Autofac;
    using Prism.Autofac;
    using RandomList.Services;
    using RandomList.Views;
    using Xamarin.Forms;

    public partial class App : PrismApplication
    {
        /*
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor.
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            this.InitializeComponent();

            await this.NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            this.Builder.RegisterTypeForNavigation<NavigationPage>();
            this.Builder.RegisterTypeForNavigation<MainPage>();
            this.Builder.RegisterTypeForNavigation<RandomListDetailPage>();

            this.RegisterMockServices();
        }

        protected void RegisterMockServices()
        {
            this.Builder.RegisterType<MockDeviceStorage>().AsImplementedInterfaces();
        }
    }
}
