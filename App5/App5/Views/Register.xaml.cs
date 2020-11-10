using System;
using App5.NewFolder3;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App5.Views;
using HelloWorld;
using SQLite;
using static PrivBus.Clases.Usuario;
using PrivBus.Clases;

namespace App5.NewFolder3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Register : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public Register()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
           
        }

        protected override async void OnAppearing()
        {
          await _connection.CreateTableAsync<User>();
            base.OnAppearing();
        }

        async void OnAdd(object  sender, System.EventArgs e)
        {
            User user = new User()
            {
                Names = nameEntry.Text,
                Email = emailEntry.Text,
                UserName = userNameEntry.Text,
                Password = passwordEntry.Text,
                EmpNumber = empNumberEntry.Text,
                DOB = DOBEntry.Date,
                DOC = DateTime.Now
            };

          
            await _connection.InsertAsync(user);

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Felicidades!",
                    "Usuario registrado con éxito", "Aceptar", "Regresar");

                if (result)
                    await Navigation.PushModalAsync(new Login());
                else
                {
                    await Navigation.PushModalAsync(new Register());
                }

            });

            
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Login());
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new Start());
            return true;
        }

    }
}