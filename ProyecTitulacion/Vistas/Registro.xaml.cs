using Microsoft.AspNetCore.Http;
using Plugin.Media.Abstractions;
using ProyecTitulacion.Functions;
using ProyecTitulacion.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyecTitulacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private int ai_banderaEstado = 0;

        public Registro()
        {
            InitializeComponent();
            if (Helpers.Settings.IsUpdateView)
            {
                //llenar los datos del usuario
                txtFirstName.Text = Helpers.Settings.MemberFistname;
                txtApellidoR.Text = Helpers.Settings.MemberLastName;
                txtEmailR.Text = Helpers.Settings.MemberEmail;

                //controlar los campos que no edite
                txtFirstName.IsEnabled = false;
                txtApellidoR.IsEnabled = false;
                txtEmailR.IsEnabled = false;

                txtPasswordR.IsVisible = false;
                txtConfirR.IsVisible = false;
                txtPasswordR.IsEnabled = false;
                txtConfirR.IsEnabled = false;
                btnActualizar.IsVisible = true;
                btnRegistrar.IsVisible = false;
            }


        }
        TblMembers miembro = new TblMembers();
        async void BtnRegistrar(object sender, EventArgs e)
        {
            if (txtPasswordR.Text.Equals(txtConfirR.Text))
            {
                bool registro;
                try
                {
                    
                    miembro.FirstName = txtFirstName.Text;
                    miembro.LastName = txtApellidoR.Text;
                    miembro.EmailId = txtEmailR.Text;
                    miembro.Password = txtPasswordR.Text;
                    registro = Services.RegistraUsuario(miembro,laFoto);
                    if (registro)
                    {
                        await DisplayAlert("Alerta", "Su usuario ha sido creado éxitosamente", "Ok");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Error al conectarse al servicio, porfavor ponerse en contando con el proveedor", "Ok");
                    }


                }
                catch
                {
                    await DisplayAlert("Error", "Error al conectarse al servicio, porfavor ponerse en contando con el proveedor", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "Las contraseñas ingresadas no coinciden", "Ok");
            }


            //await Navigation.PopToRootAsync ();

        }

        async void BtnUpdateMember(object sender, EventArgs e)
        {
            if (ai_banderaEstado == 0)
            {
                //encerar datos
                //txtFirstName.Text = "";
                //txtApellidoR.Text = "";
                //txtEmailR.Text = "";

                txtFirstName.IsEnabled = true;
                txtApellidoR.IsEnabled = true;
                txtEmailR.IsEnabled = true;

                txtPasswordR.IsVisible = true;
                txtConfirR.IsVisible = true;
                txtPasswordR.IsEnabled = true;
                txtConfirR.IsEnabled = true;
                btnActualizar.Text = "Actualizar Datos";
                ai_banderaEstado = 1;
            }
            else
            {

                txtFirstName.IsEnabled = false;
                txtApellidoR.IsEnabled = false;
                txtEmailR.IsEnabled = false;
                txtPasswordR.IsVisible = false;
                txtConfirR.IsVisible = false;
                txtPasswordR.IsEnabled = false;
                txtConfirR.IsEnabled = false;
                btnActualizar.Text = "Actualizar";
                ai_banderaEstado = 0;
                if (txtPasswordR.Text.Equals(txtConfirR.Text))
                {
                    Retorno retorno = new Retorno();
                    try
                    {
                        retorno = Functions.Services.MantenimientoLogIn("UPD",
                            int.Parse(Helpers.Settings.MemberId),
                            txtFirstName.Text,
                            txtApellidoR.Text,
                            txtEmailR.Text,
                            txtPasswordR.Text,
                            true,
                            false,
                            DateTime.Today,
                            DateTime.Today);
                        if (retorno.procesoCorrecto)
                        {
                            await DisplayAlert("Alerta", "Su usuario ha sido actualizado éxitosamente", "Ok");
                        }
                        else
                        {
                            await DisplayAlert("Error", "Error al conectarse al servicio, porfavor ponerse en contando con el proveedor", "Ok");
                        }


                    }
                    catch
                    {
                        await DisplayAlert("Error", "Error al conectarse al servicio, porfavor ponerse en contando con el proveedor", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Las contraseñas ingresadas no coinciden", "Ok");
                }


            }

        }
        FileParameter laFoto=null;
        async void btnFoto_Clicked(object sender, EventArgs e)
        {
            var photo =
                await Plugin.Media.CrossMedia.Current
                    .TakePhotoAsync(new StoreCameraMediaOptions());
            if (photo != null)
            {
                // miembro.bFoto =Convert.ToBase64String(Stream2Bytes(photo.GetStream()));
               
                imgFoto.Source = ImageSource.FromFile(photo.Path);
                
                laFoto = new FileParameter();
                laFoto.FileName = photo.Path;
            }
                
            
        }

        public static byte[] Stream2Bytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}