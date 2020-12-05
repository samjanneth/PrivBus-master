using System;
using App5.NewFolder3;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App5.Views;
using SQLite;
using static PrivBus.Clases.Usuario;
using PrivBus.Clases;
using Firebase.Auth;

namespace App5.NewFolder3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();

           
        }

        async void OnAdd(object  sender, System.EventArgs e)
        {
            Usuario.User user = new Usuario.User()
            {
                Names = nameEntry.Text,
                Email = emailEntry.Text,
                UserName = userNameEntry.Text,
                Password = passwordEntry.Text,
                EmpNumber = empNumberEntry.Text,
                DOB = DOBEntry.Date,
                DOC = DateTime.Now
            };

            string WebAPIkey = "AIzaSyAjZ38ZK8lkN2xQSClolREWMPzPTvJqyro";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(emailEntry.Text.ToString(), passwordEntry.Text.ToString());
                string gettoken = auth.FirebaseToken;

                await Application.Current.MainPage.Navigation.PushAsync(new Login());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

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