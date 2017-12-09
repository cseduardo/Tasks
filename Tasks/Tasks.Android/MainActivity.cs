using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Android.Webkit;

namespace Tasks.Droid
{
    [Activity(Label = "Tasks", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ISQLAzure
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> AuthenticateO()
        {
            var message = string.Empty;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                usuario = await Tasks.Views.Inicio.cliente.LoginAsync(this, MobileServiceAuthenticationProvider.MicrosoftAccount, "tasks-t.azurewebsites.net");
                if (usuario != null)
                {
                    message = string.Format("Tú haz ingresado como {0}.",
                        usuario.UserId);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Sign-in result");
            builder.Create().Show();
            return usuario;
        }
        public async Task<bool> LogoutAsync()
        {
            usuario = null;
            CookieManager.Instance.RemoveAllCookie();
            await Tasks.Views.Inicio.cliente.LogoutAsync();
            return true;
        }
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            App.Init((ISQLAzure)this);
            LoadApplication(new App());
        }
    }
}

