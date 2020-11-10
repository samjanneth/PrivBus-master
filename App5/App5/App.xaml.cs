using App5.NewFolder3;
using App5.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrivBus.Clases;

namespace App5
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetail { get; set; }

        public async static Task NavigateMasterDetail(Page page)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(page);
        
        }


        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new Start());
            new GeoLocation().getLocationGPS();
            new NetWorkState().iHaveInternet();
            
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
