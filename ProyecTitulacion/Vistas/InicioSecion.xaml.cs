using Newtonsoft.Json;
using ProyecTitulacion.Model;
using ProyecTitulacion.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyecTitulacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioSecion : ContentPage, IGoogleAuthenticationDelegate
    {

        private IGoogleAuthService _googleAuthService;
        public InicioSecion()
        {
            InitializeComponent();
            _googleAuthService = DependencyService.Resolve<IGoogleAuthService>();
        }

        async void BtnRegistro (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());

        }

        async void BtnInicio (object sender, EventArgs e)
        {
            String sUsuario = txtCorreo.Text;
            String sPassword = txtPassword.Text;
            Retorno retorno = new Retorno();
            List<TblMembers> members = new List<TblMembers>();
            try
            {
                retorno = Functions.Services.MantenimientoLogIn("LOGIN", 0, "", "", sUsuario, sPassword, true, false, DateTime.Today, DateTime.Today);
                members.Add((TblMembers) retorno.retorno);
                //members= JsonConvert.DeserializeObject<List<TblMembers>>(retorno.retorno.ToString());
                if (members.Count != 0)
                {
                    if (members[0].EmailId.Equals(sUsuario) && members[0].Password.Equals(sPassword))
                    {
                        Helpers.Settings.MemberId = members[0].MemberId.ToString();
                        Helpers.Settings.MemberFistname = members[0].FirstName;
                        Helpers.Settings.MemberLastName = members[0].LastName;
                        Helpers.Settings.MemberEmail = members[0].EmailId;
                        Helpers.Settings.IsLoged = true;
                        await DisplayAlert("Alerta", "Usuario - Password Correctos  "+Helpers.Settings.MemberId, "Ok");
                        Application.Current.MainPage = new NavigationPage(new MasterPage());
                        await Navigation.PopToRootAsync();
                        
                    }
                    else
                    {
                        await DisplayAlert("Error", "Usuario - Password Incorrectos", "Ok");
                    }
                }
                else {
                    await DisplayAlert("Error", "Usuario - Password Incorrectos", "Ok");
                }


            }
            catch
            {

            }

           
        }

        private async Task<bool> validarFormulario()
        {
            bool isEmail = Regex.IsMatch(txtCorreo.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
                return false;
            }
            return true;
        }

        async void btnFaceLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FaceLogin());
        }

        private void btnGoogleLogin_Clicked(object sender, EventArgs e)
        {
            _googleAuthService.Autheticate(this);
        }

        public void OnAuthenticationCompleted(GoogleOAuthToken token)
        {
            var googleService = new GoogleAccountInfoService();
            this.DisplayAlert("Advertencia", "Login Ok", "OK");
           
        }

        public void OnAuthenticationFailed(string message, Exception exception)
        {
            this.DisplayAlert("Advertencia", "Login Faliido", "OK");
        }

        public void OnAuthenticationCanceled()
        {
            this.DisplayAlert("Advertencia", "Login Faliido", "OK");
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            _googleAuthService.Autheticate(this);
        }
    }
}