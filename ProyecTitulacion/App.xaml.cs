using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyecTitulacion
{
    public partial class App : Application
    {
        public static FlyoutPage MAsterDet { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MasterPage());
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
