using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Tasks.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, ISQLAzure
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        private MobileServiceUser usuario;

        public async Task<MobileServiceUser> AuthenticateO()
        {
            var message = string.Empty;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                if (usuario == null)
                {
                    usuario = await Tasks.Views.Inicio.cliente.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.MicrosoftAccount, "tasks-t.azurewebsites.net");
                    if (usuario != null)
                    {
                        message = string.Format("Tú haz ingresado como {0}.", usuario.UserId);
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            UIAlertView avAlert = new UIAlertView("Sign-in result", message, null, "OK", null);
            avAlert.Show();
            return usuario;
        }
        public async Task<bool> LogoutAsync()
        {
            usuario = null;
            foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
            {
                NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
            }
            await Tasks.Views.Inicio.cliente.LogoutAsync();
            return true;
        }
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            App.Init(this);
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
