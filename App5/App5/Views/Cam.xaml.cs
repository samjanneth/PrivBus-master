using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrivBus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cam : ContentPage
    {
        public Cam()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Scanner();
        }

        private async void Scanner()
        {
            var scannerPage = new ZXingScannerPage();

            scannerPage.Title = "Lector de QR";
            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    DisplayAlert("Valor obtenido", result.Text, "OK");
                });
            };
            await Navigation.PushAsync(scannerPage);

        }


    }
}