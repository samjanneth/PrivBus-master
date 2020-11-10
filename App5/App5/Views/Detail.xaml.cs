using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrivBus.Clases;


namespace PrivBus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {

        public GeoLocation _Geolocation = new GeoLocation();


        public Detail()
        {

            InitializeComponent();
            moveToActualPosition();
            
        }


        void moveToActualPosition()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {

                await _Geolocation.getLocationGPS();
                lati.Text = GeoLocation.lati.ToString();
                lon.Text = GeoLocation.lon.ToString();
            });
                
        }
    }
}