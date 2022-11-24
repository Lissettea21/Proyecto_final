using ProyecTitulacion.MenusItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyecTitulacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : FlyoutPage
    {
        public List<Menuu> Menuu { get; set; }

        public MasterPage()
        {
            InitializeComponent();
            Menuu = new List<Menuu>();
            Menuu principal = new Menuu() { Titulo = "Paguina Principal", Pagina = typeof(MainPage) };
            Menuu.Add(principal);
            Menuu contactanos = new Menuu() { Titulo = "Contactanos", Pagina = typeof(Contactanos) };
            Menuu.Add(contactanos);
            Menuu QuienesS = new Menuu() { Titulo = "Quienes Somos", Pagina = typeof(QuienesS) };
            Menuu.Add(QuienesS);
            Menuu Usuario = new Menuu() { Titulo = "Usuario", Pagina = typeof(Registro) };
            Menuu.Add(Usuario);

            this.listMenu.ItemsSource = Menuu;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
            this.listMenu.ItemSelected += ListMenu_ItemSelected;
        }
        
        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // controlar si el usuario esta conectado
            if (Helpers.Settings.IsLoged)
            {

            }
            Menuu pagina = e.SelectedItem as Menuu;
            if (pagina.Titulo == "Usuario")
            {
                Helpers.Settings.IsUpdateView = true;
            }
            else
            {
                Helpers.Settings.IsUpdateView = false;
            }
            Detail = new NavigationPage((Page)Activator.CreateInstance(pagina.Pagina));
            IsPresented = false;

        }
   
}
}
