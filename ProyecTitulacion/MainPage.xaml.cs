using ProyecTitulacion.MenusItem;
using ProyecTitulacion.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyecTitulacion
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            
            if (Helpers.Settings.IsLoged == true)
            {
                btnInicio.Text = "Cerrar Sesión";
                btnCarritoCompra.IsVisible = true;
                btnMenu1.IsVisible = true;
            }
            else {
                btnInicio.Text = "iniciar Sesión";
                btnCarritoCompra.IsVisible = false;
                btnMenu1.IsVisible = false;
            }

        }
        async void BtnInicio(object sender, EventArgs e)
        {
            if (Helpers.Settings.IsLoged)
            {
                Helpers.Settings.IsLoged = false;
                Helpers.Settings.MemberId = null;
                Helpers.Settings.MemberFistname = null;
                Helpers.Settings.MemberLastName = null;
                Helpers.Settings.MemberEmail = null;
                Application.Current.MainPage = new NavigationPage(new MasterPage());
                await Navigation.PopToRootAsync();
            }
            else
            {
                await Navigation.PushAsync(new InicioSecion());
            }
            

        }

        async void BtnIrMenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MylistPage());

        }

        async void btnCarritoCompra_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Carrito());
        }
    }
}