using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyecTitulacion.Model;
namespace ProyecTitulacion.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carrito : ContentPage
    {
        public Carrito()
        {
            InitializeComponent();
        }
        public Carrito(List<TblProduct> selectedItems)
        {
            InitializeComponent();
            carrito.ItemsSource = selectedItems;
        }

        async void btnPide_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionCliente());
        }
    }
}