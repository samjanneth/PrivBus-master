using App5;
using App5.NewFolder3;
using HelloWorld;
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
        private SQLiteAsyncConnection _connection;
       

    
        public HomePage(string userName, string email, string empnumber)
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            this.Master = new Master(userName, email, empnumber);
            this.Detail = new NavigationPage(new Detail());
            App.MasterDetail = this;

        }
    

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new Login());
            return true;
        }
    }
}