using HelloWorld;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace PrivBus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Codigo : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public Codigo(string username, string email, string empNumber)
        {
            string[] CodeQR_Data = new string[] { username, email, empNumber };
            DateTime now = DateTime.Now;
            string date = now.ToString("dd-MM-yyyy HH:mm:ss");
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            CodeQR.BarcodeValue = CodeQR_Data[0] + "" +
                " " + CodeQR_Data[1] + "" +
                " " + CodeQR_Data[2] + " " +
                " " + date;

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