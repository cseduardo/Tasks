using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Tasks.UWP
{
    public sealed partial class MainPage : ISQLAzure
    {
        private MobileServiceUser usuario;

        public async Task<MobileServiceUser> AuthenticateO()
        {
            try
            {
                usuario = await Tasks.Views.Inicio.cliente.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount, "tasks-t.azurewebsites.net");
                if (usuario != null)
                {
                    await new MessageDialog(usuario.UserId, "Bienvenido").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message, "Error").ShowAsync();
            }
            return usuario;
        }

        public async Task<bool> LogoutAsync()
        {
            usuario = null;
            await Tasks.Views.Inicio.cliente.LogoutAsync();
            return true;
        }
        public MainPage()
        {
            this.InitializeComponent();
            Tasks.App.Init((ISQLAzure)this);
            LoadApplication(new Tasks.App());
        }
    }
}
