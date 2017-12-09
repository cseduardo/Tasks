using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public static MobileServiceClient cliente;
        public static MobileServiceUser usuario;
        
        
        public Inicio()
        {
            InitializeComponent();

            cliente = new MobileServiceClient(AzureConnection.AzureURL);
        }

        private async void loutlook_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                usuario = await App.Authenticator.AuthenticateO();
            await Navigation.PushAsync(new Tasks.Views.VTareas());
        }
    }
}