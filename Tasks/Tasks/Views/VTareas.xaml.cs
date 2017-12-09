using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VTareas : ContentPage
    {
        public ObservableCollection<Tareas> items { get; set; }
        public static IMobileServiceTable<Tareas> Tabla;
        public VTareas()
        {
            InitializeComponent();
            //Tabla = Inicio.cliente.GetTable<Tareas>;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Device.StartTimer(new TimeSpan(0, 0, 10), () =>
            {
                return true;
            });
            await RefreshItems(true);
        }

        public async void registrosLV_Refreshing(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                await RefreshItems(false);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }

            if (error != null)
            {
                await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
            Device.StartTimer(new TimeSpan(0, 0, 10), () =>
            {
                return true;
            });
        }

        public async void OnSyncItems(object sender, EventArgs e)
        {
            await RefreshItems(true);
        }

        private async Task RefreshItems(bool showActivityIndicator)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                if (mtodo.IsToggled == false)
                {
                    try
                    {
                        IEnumerable<Tareas> elementos = await Tabla.ToCollectionAsync();
                        items = new ObservableCollection<Tareas>(elementos);
                        BindingContext = this;
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("", "No se pudo mostrar por: " + ex, "Aceptar");
                    }
                }
                else
                {
                    if (mtodo.IsToggled == true)
                    {
                        try
                        {
                            IEnumerable<Tareas> elementos = await Tabla.IncludeDeleted().Where(DatosBD => DatosBD.Deleted == true).ToCollectionAsync();
                            items = new ObservableCollection<Tareas>(elementos);
                            BindingContext = this;
                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("", "No se pudo mostrar por: " + ex, "Aceptar");
                        }
                    }
                }
            }
        }

        private class ActivityIndicatorScope : IDisposable
        {
            private bool showIndicator;
            private ActivityIndicator indicator;
            private Task indicatorDelay;

            public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
            {
                this.indicator = indicator;
                this.showIndicator = showIndicator;

                if (showIndicator)
                {
                    indicatorDelay = Task.Delay(2000);
                    SetIndicatorActivity(true);
                }
                else
                {
                    indicatorDelay = Task.FromResult(0);
                }
            }

            private void SetIndicatorActivity(bool isActive)
            {
                this.indicator.IsVisible = isActive;
                this.indicator.IsRunning = isActive;
            }

            public void Dispose()
            {
                if (showIndicator)
                {
                    indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }

        private void buscarRegistrosSB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var teclado = buscarRSB.Text;
            //var sugNom = items.Where(n => n.Nombre.Contains(buscarRSB.Text.ToUpper()));
            //registrosLV.ItemsSource = sugNom;
        }

        private async void registrosLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new VTareaE(registrosLV.SelectedItem as Tareas));
            }
            return;
        }

        private void Agregar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RTarea());
        }

        private async void salir_Clicked(object sender, EventArgs e)
        {
            bool loggedOut = false;

            if (App.Authenticator != null)
            {
                loggedOut = await App.Authenticator.LogoutAsync();
                await Navigation.PushAsync(new Inicio());
            }
        }

        private void mtodo_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void usuarios_Clicked(object sender, EventArgs e)
        {

        }
    }
}