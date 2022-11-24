using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyecTitulacion.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaMenu : ContentPage
    {
        public ListaMenu()
        {
            InitializeComponent();
        }
        async void BtnIrMenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MylistPage());

        }
    }
}