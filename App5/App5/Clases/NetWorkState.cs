using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PrivBus.Clases
{
    public class NetWorkState
    {

        public static bool isConnect = false;


        //se obtiene el estado de la red
        public void iHaveInternet()
        {
            NetworkAccess current = Connectivity.NetworkAccess;
            determineState(current);

            //detecta el cambio en la red
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            determineState(e.NetworkAccess);

        }

        //determina el estado de la red y su método
        public void determineState(NetworkAccess state)
        {
            if(state == NetworkAccess.Internet)
            {
                isConnect = true;
            }
            else if (state == NetworkAccess.Local)
            {
                isConnect = true;
            }
            else if (state == NetworkAccess.ConstrainedInternet)
            {
                isConnect = false;
            }
            else
            {
                isConnect = false;
            }

        }




    }
}
