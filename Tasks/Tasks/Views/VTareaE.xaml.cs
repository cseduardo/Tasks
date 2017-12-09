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
	public partial class VTareaE : ContentPage
	{
		public VTareaE(object selectedItem)
        {
			InitializeComponent ();
            var dato = selectedItem as Tareas;
            BindingContext = dato;
            InitializeComponent();
            tarea.Text ="";
        }
	}
}