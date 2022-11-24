using Plugin.Geolocator;
using System.Diagnostics.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ProyecTitulacion.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicacionCliente : ContentPage
    {
        public UbicacionCliente()
        {
            InitializeComponent();
            CargaPosicion();
        }

        async void CargaPosicion()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(new System.TimeSpan(10000000));
           
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                 new Position(position.Latitude, position.Longitude), Distance.FromMiles(0.3)));

            Pin pin = new Pin
            {
                Label = "Cliente ",
                Address = "Ubicacion de entrega",
                Type = PinType.Place,
                Position = new Position(position.Latitude, position.Longitude)
            };
            map.Pins.Add(pin);

        }

        async void Button_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("GRACIAS", "Su pedido esta en camino", "Ok");
            await Navigation.PushAsync(new MainPage());
        }
    }
}