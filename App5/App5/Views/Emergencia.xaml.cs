using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrivBus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Emergencia : ContentPage
    {
        public Emergencia()
        {
            InitializeComponent();

        }


        private async void Emergencia1_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Mensaje","Emergencia!!","Cerrar");
        }
        private async void Cancela1_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Mensaje", "Se canceló la solicitud de emergencia", "Cerrar");
        }


    }
}