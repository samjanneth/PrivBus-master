using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrivBus.Clases;
using Xamarin.Forms.GoogleMaps;


namespace PrivBus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {

        public GeoLocation _Geolocation = new GeoLocation();


        public Detail()
        {

            InitializeComponent();
            configMap();
            moveToActualPosition();
        }


        //configuración del mapa 
        void configMap()
        {
            mapa.UiSettings.CompassEnabled = true;
            mapa.UiSettings.MyLocationButtonEnabled = true;
            mapa.UiSettings.MapToolbarEnabled = true;
            mapa.MyLocationEnabled = true;
            mapa.FlowDirection = FlowDirection.LeftToRight;
            mapa.MapType = MapType.Street;
        }

        void moveToActualPosition()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {

                await _Geolocation.getLocationGPS();
                Position _position = new Position(GeoLocation.lati, GeoLocation.lon );
                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(_position, Distance.FromMeters(500)), true);
            });
                
        }

   



    }
}