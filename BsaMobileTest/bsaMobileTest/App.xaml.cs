using bsaMobileTest.Services;
using bsaMobileTest.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bsaMobileTest
{
    public partial class App : Application
    {
        static UserDataStore database;

        public static UserDataStore Database => (database == null) ? 
            (database =  new UserDataStore(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3"))) : database;
        
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
