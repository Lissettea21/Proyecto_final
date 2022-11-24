using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProyecTitulacion.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(GoogleAuthService))]
namespace ProyecTitulacion.Droid
{
    public class GoogleAuthService : IGoogleAuthService
    {
        internal static MainActivity mainact { get; set; }

        public GoogleAuthService()
        {
           

        }

        public void Autheticate(IGoogleAuthenticationDelegate googleAuthenticationDelegate)
        {
            GoogleAuthenticatorHelper.Auth = new GoogleAuthenticator(
               "502671190151-cg6e34dbm3c1rtchqev5r75esdk8makj.apps.googleusercontent.com",
               "email",
               "com.googleusercontent.apps.502671190151-cg6e34dbm3c1rtchqev5r75esdk8makj:/oauth2redirect",
              // "com.jdc.OAuth:/oauth2redirect",
               googleAuthenticationDelegate);

            // Display the activity handling the authentication
            var authenticator = GoogleAuthenticatorHelper.Auth.GetAuthenticator();
            mainact = (MainActivity)Forms.Context;
            var intent = authenticator.GetUI(mainact);
            mainact.StartActivity(intent);
        }
    }
}