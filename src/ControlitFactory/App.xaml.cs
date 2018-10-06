using System;
using System.Threading.Tasks;
using ControlitFactory.Services;
using ControlitFactory.Views;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Unity;
using Prism.Unity;
using Prism.Logging;
using Xamarin.Forms;

using DebugLogger = ControlitFactory.Services.DebugLogger;

namespace ControlitFactory
{
    public partial class App : PrismApplication
    {
        /* 
         * NOTE: 
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
            InitializeComponent();
            LogUnobservedTaskExceptions();

            await NavigationService.NavigateAsync("CustomNavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register the Popup Plugin Navigation Service
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterInstance(CreateLogger());


            // Navigating to "TabbedPage?createTab=ViewA&createTab=ViewB&createTab=ViewC will generate a TabbedPage
            // with three tabs for ViewA, ViewB, & ViewC
            // Adding `selectedTab=ViewB` will set the current tab to ViewB
            containerRegistry.RegisterForNavigation<TabbedPage>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<CustomNavigationPage>();
            containerRegistry.RegisterForNavigation<Settings>();
            containerRegistry.RegisterForNavigation<Equipment>();
            containerRegistry.RegisterForNavigation<EquipmentEdit>();
            containerRegistry.RegisterForNavigation<EditTabPage>();
            containerRegistry.RegisterForNavigation<Ieraksts>();
            containerRegistry.RegisterForNavigation<Defekti>();
            containerRegistry.RegisterForNavigation<DefektaRegistracija>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle IApplicationLifecycle
            base.OnSleep();

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle IApplicationLifecycle
            base.OnResume();

            // Handle when your app resumes
        }

        private ILoggerFacade CreateLogger() =>
            new DebugLogger();

        private void LogUnobservedTaskExceptions()
        {
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Container.Resolve<ILoggerFacade>().Log(e.Exception);
            };
        }
        static DataManager.DataManager database;
        public static DataManager.DataManager Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataManager.DataManager(DependencyService.Get<IFileHelper>().GetLocalFilePath("ControlitFactory.db3"));
                }
                return database;
            }
        }

        public static int AktaId { get; set; }


        public static ControlitFactory.Models.DefektacijasAkts Akts { get; set; }

        public static ControlitFactory.Models.Settings Profils { get; set; }
    }
}
