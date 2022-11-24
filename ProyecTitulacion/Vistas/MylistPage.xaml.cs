using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyecTitulacion.Model;
using Newtonsoft.Json;
using System.Linq;
using RestSharp;

namespace ProyecTitulacion.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MylistPage : ContentPage
    {
        public IList<ListMenu> FoodList { get; private set; }
        public List<TblProduct> ProductList { get; private set; }
        public List<TblProduct> SelectedProductList = new List<TblProduct>();

        public List<string> productos = new List<string> { };
        public MylistPage()
        {
            

            //FoodList = new List<ListMenu>();
            Retorno retorno = new Retorno();
            retorno = Functions.Services.MantenimientoGetProducts();
            // "SEL", 0, "", "", true, false,"","","","",true,"","") ;
            ProductList= JsonConvert.DeserializeObject<List<TblProduct>>(retorno.retorno.ToString());

            //BindingContext = new TblProduct();
            InitializeComponent();
            listaComida.ItemsSource = ProductList;
        }
        
        private void MenuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TblProduct selectedItem = e.SelectedItem as TblProduct;

        }

        private async void MenuListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            TblProduct tappedItem = e.Item as TblProduct;
            TblProduct selecedItem = tappedItem;
            string result =await DisplayPromptAsync("Numero de Pedidos", "Cuantos platos desea pedir?");
            
            bool answer = await DisplayAlert("Adventencia", "Seguro desea pedir " + result + " platos", "Si", "No");
            selecedItem.Quantity = result;
            SelectedProductList.Add(selecedItem);
            System.Diagnostics.Debug.WriteLine("Answer: " + answer);
            
            await DisplayAlert("COMENTARIO", "Disfrutelo, buen provecho", "Aceptar");
            
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            
            string result = await DisplayPromptAsync("Numero de Pedidos", "Cuantos platos desea pedir?");

            bool answer = await DisplayAlert("Adventencia", "Seguro desea pedir " + result + " platos", "Si", "No");
            System.Diagnostics.Debug.WriteLine("Answer: " + answer);
            
            await DisplayAlert("COMENTARIO", "Disfrutelo, buen provecho", "Aceptar");
            
        }

        void sb_search_SearchButtonPressed(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            //var container = sb_search.Text;
            //var produc = productos.Where(x => x.Contains(container));
            //var s = from x in productos where x.Contains(container) select x;
        }

        async void btnAgregarC_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Carrito(SelectedProductList));
        }
    }

}