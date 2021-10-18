using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarenGruppen
{
    public partial class App : Application
    {
        static WGDatabase database;
        static WGDatabase database1;
        public static WGDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new WGDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RichtigeAntwort.db17"));
                }
                return database;
            }

        }
        public static WGDatabase Database1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new WGDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FalscheAntwort.db17"));
                }
                return database1;
            }

        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.CornflowerBlue , BarTextColor = Color.White };
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
