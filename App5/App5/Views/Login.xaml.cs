using App5.Views;
using HelloWorld;
using PrivBus.Clases;
using PrivBus.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PrivBus.Clases.Usuario;

namespace App5.NewFolder3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public Login()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new Start());
            return true;
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<User>();
            base.OnAppearing();
        }

         async private void loginTry(object sender, EventArgs e)
        {
            var myquery = await _connection.Table<User>().Where(u => u.UserName.Equals(userEntry.Text) && u.Password.Equals(passwordEntry.Text)).FirstOrDefaultAsync();

            if (myquery!=null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async() =>
                    {

                    var result = await this.DisplayAlert("Error", "Nombre de usuario y/o password incorrectos", "Aceptar", "Cancelar");

                    if (result)
                        await Navigation.PushModalAsync(new Login());
                    else
                    {
                        await Navigation.PushModalAsync(new Login());
                    }
                });
            }
        }
    }
}