using App5;
using App5.NewFolder3;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PrivBus.Clases.Usuario;

namespace PrivBus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : MasterDetailPage
    {
       

    
        public HomePage(string userName, string email, string empnumber)
        {
            InitializeComponent();

            this.Master = new Master(userName, email, empnumber);
            this.Detail = new NavigationPage(new Detail());
            App.MasterDetail = this;

        }


        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new MasterDetailPage());
            return true;
        }
    }
}