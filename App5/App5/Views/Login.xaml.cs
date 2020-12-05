using App5.Views;
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
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace App5.NewFolder3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
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


        async private void loginTry(object sender, EventArgs e)
        {
            string WebAPIkey = "AIzaSyAjZ38ZK8lkN2xQSClolREWMPzPTvJqyro";

            //var myquery = await _connection.Table<Usuario.User>().Where(u => u.UserName.Equals(userEntry.Text) && u.Password.Equals(passwordEntry.Text)).FirstOrDefaultAsync();

            //if (myquery != null)
            //{
            //    App.Current.MainPage = new NavigationPage(new HomePage(myquery.UserName, myquery.Email, myquery.EmpNumber));
            //}

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(emailEntry.Text.ToString(), passwordEntry.Text.ToString());
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);

                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);


                if (content != null)
                {
                    App.Current.MainPage = new NavigationPage(new HomePage("mike123",emailEntry.Text.ToString(), "1601169"));
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }

            Device.BeginInvokeOnMainThread(async () =>
                {

                    var result = await this.DisplayAlert("Error", "Nombre de usuario y/o password incorrectos", "Aceptar", "Cancelar");

                    if (result)
                    {
                        emailEntry.Text = "";
                        passwordEntry.Text = "";
                    }
                    else
                    {
                        emailEntry.Text = "";
                        passwordEntry.Text = "";
                    }
                });
        }
    }

}