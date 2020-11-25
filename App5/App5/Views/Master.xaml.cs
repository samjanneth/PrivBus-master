using App5;
using System;
using HelloWorld;
using SQLite;
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
    public partial class Master : ContentPage
    {
        private SQLiteAsyncConnection _connection;
       

        public Master(string userName, string email, string empnumber)
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            buttonA.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new Historial());
            };

            buttonB.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new Codigo(userName, email, empnumber));
            };

            buttonC.Clicked += async (sender, e) =>
            {
                //se envian argumentos a xaml de Emergencia
                await App.NavigateMasterDetail(new Emergencia(userName, email, empnumber));
            };

            buttonD.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new Configuracion());
            };


        }

        protected override async void OnAppearing()
        {
            var users = await _connection.Table<User>().ToListAsync();
            usersListView.ItemsSource = users;
            base.OnAppearing();
        }
    }
}