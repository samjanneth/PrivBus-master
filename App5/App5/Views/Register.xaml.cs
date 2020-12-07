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
using FireSharp.Interfaces;
using Firesharp = FireSharp.Config;
using FireSharp.Response;

namespace App5.NewFolder3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Register : ContentPage
    {

        readonly IFirebaseConfig config = new Firesharp.FirebaseConfig
        {
            AuthSecret = "ROzTU6nnUaU32kvGUkf4HMSYxx3FT8TSh466XVyf",
            BasePath = "https://privbus-1736c.firebaseio.com/"
        };

        IFirebaseClient client;
        private void firebase()
        {
            client = new FireSharp.FirebaseClient(config);
            //FirebaseResponse response = await client.GetAsync("Usuarios", FireSharp.QueryBuilder.New().OrderBy("Email").EndAt(email1).LimitToLast(1));
            //Usuario user = response.ResultAs<Usuario>();
        }
        public Register()
        {
            InitializeComponent();

            
           
        }

        async void OnAdd(object  sender, System.EventArgs e)
        {
            
            //var authdatabase = "ROzTU6nnUaU32kvGUkf4HMSYxx3FT8TSh466XVyf";
            //var firebaseClient = new FirebaseClient(
            //    "https://privbus-1736c.firebaseio.com/",
            //    new FirebaseOptions
            //    {
            //        AuthTokenAsyncFactory = () => Task.FromResult(authdatabase)
            //    });


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

                //var firebase = new FirebaseClient("https://privbus-1736c.firebaseio.com/");
                //var Usuario = await firebaseClient
                //    .Child("Usuarios")
                //    .PostAsync(user);

                client = new FireSharp.FirebaseClient(config);
                var usuario = user;
                PushResponse response = client.Push("Usuarios/", usuario);
                usuario.Id = response.Result.name;
                SetResponse setresp = client.Set("Usuarios/"+usuario.Id, usuario);

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