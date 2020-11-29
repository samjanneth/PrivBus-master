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
using Newtonsoft.Json;
using System.Reflection;

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

        void Ruta_Clicked(System.Object sender, System.EventArgs e)
        {
            var assembly = typeof(Detail).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"PrivBus.MapResources.Ruta.json");
            string Ruta;

            using (var reader = new System.IO.StreamReader(stream))
            {
                Ruta = reader.ReadToEnd();
            }

            var myJson = JsonConvert.DeserializeObject<List<Xamarin.Forms.GoogleMaps.Position>>(Ruta);


            mapa.Polylines.Clear();

            var polyline = new Xamarin.Forms.GoogleMaps.Polyline();
            polyline.StrokeColor = Color.Red;
            polyline.StrokeWidth = 4;

            foreach (var p in myJson)
            {
                polyline.Positions.Add(p);

            }
            mapa.Polylines.Add(polyline);

            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.GoogleMaps.Position(polyline.Positions[0].Latitude, polyline.Positions[0].Longitude), Xamarin.Forms.GoogleMaps.Distance.FromMiles(0.50f)));

            //var pin = new Xamarin.Forms.GoogleMaps.Pin
            //{
            //    Type = PinType.SearchResult,
            //    Position = new Xamarin.Forms.GoogleMaps.Position(polyline.Positions.First().Latitude, polyline.Positions.First().Longitude),
            //    Label = "Pin",
            //    Address = "Pin",
            //    Tag = "CirclePoint",
            //    Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CircleImg.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CircleImg.png", WidthRequest = 25, HeightRequest = 25 })

            //};
            //mapa.Pins.Add(pin);

            //var positionIndex = 1;

            //Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            //{
            //    if (myJson.Count > positionIndex)
            //    {
            //        UpdatePostions(myJson[positionIndex]);
            //        positionIndex++;
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //});
        }

        //async void UpdatePostions(Xamarin.Forms.GoogleMaps.Position position)
        //{
        //    if (mapa.Pins.Count == 1 && mapa.Polylines != null && mapa.Polylines?.Count > 1)
        //        return;

        //    var cPin = mapa.Pins.FirstOrDefault();

        //    if (cPin != null)
        //    {
        //        cPin.Position = new Xamarin.Forms.GoogleMaps.Position(position.Latitude, position.Longitude);
        //        cPin.Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 25, HeightRequest = 25 });
        //        mapa.MoveToRegion(MapSpan.FromCenterAndRadius(cPin.Position, Distance.FromMeters(200)));
        //        var previousPosition = mapa.Polylines?.FirstOrDefault()?.Positions?.FirstOrDefault();
        //        mapa.Polylines?.FirstOrDefault()?.Positions?.Remove(previousPosition.Value);
        //    }
        //    else
        //    {
        //        mapa.Polylines?.FirstOrDefault()?.Positions?.Clear();
        //    }
        //}

    }
}