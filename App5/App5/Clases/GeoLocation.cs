using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrivBus.Clases
{
    public class GeoLocation
    {

        public static double lati { get; set; }
        public static double lon { get; set; }

        public async Task getLocationGPS()
        {
            
                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                    var location = await Geolocation.GetLocationAsync(request);

                    if (location != null)
                    {

                    lati = location.Latitude;
                    lon = location.Longitude;
                        //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    }
                    else
                {
                    var knowLocation = await Geolocation.GetLastKnownLocationAsync();
                    lati = knowLocation.Latitude;
                    lon = knowLocation.Longitude;

                }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    // Handle not enabled on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to get location
                }
            }


    }
    }

