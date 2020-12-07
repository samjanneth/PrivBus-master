using Firebase.Database.Query;
using Firebase.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrivBus.Clases;
using Newtonsoft.Json;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp.Config;
using ZXing;

namespace PrivBus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Codigo : ContentPage
    {

       
        readonly IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "ROzTU6nnUaU32kvGUkf4HMSYxx3FT8TSh466XVyf",
            BasePath = "https://privbus-1736c.firebaseio.com/"
        };

        IFirebaseClient client;


        private  void firebase()
        {
            client = new FireSharp.FirebaseClient(config);
            //FirebaseResponse response = await client.GetAsync("Usuarios", FireSharp.QueryBuilder.New().OrderBy("Email").EndAt(email1).LimitToLast(1));
            //Usuario user = response.ResultAs<Usuario>();
        }

        public string email1 { get; set; }
        public Codigo(string username, string email, string empNumber)
        {
            email1 = email;
            
            //string[] CodeQR_Data = new string[] { username, email, empNumber };
            //DateTime now = DateTime.Now;
            //string date = now.ToString("dd-MM-yyyy HH:mm:ss");
            InitializeComponent();
            firebase();
            FirebaseResponse response = client.Get("Usuarios", FireSharp.QueryBuilder.New().OrderBy("Email").EndAt(email1).LimitToLast(1));
            Usuario user = response.ResultAs<Usuario>();

            char delim = '"';

            string[] json = response.Body.Split(delim);

            DateTime time = DateTime.Now;
            string date = time.ToString("yyy-MM-dd HH:mm:ss");
            CodeQR.BarcodeValue = json[23] + ": " + json[25] + System.Environment.NewLine +
                 json[15] + ": " + json[17] + System.Environment.NewLine +
                 "Fecha Nac: " + json[5] + System.Environment.NewLine +
                "Fecha: " + date;


            //CodeQR.BarcodeValue = response.Body;


            Console.WriteLine(json);

            //CodeQR.BarcodeValue = CodeQR_Data[0] + "" +
            //    " " + CodeQR_Data[1] + "" +
            //    " " + CodeQR_Data[2] + " " +
            //    " " + date;

        }

        //private async void New_QR(object sender, EventArgs e)
        //{
        //    InitializeComponent();
        //    client = new FireSharp.FirebaseClient(config);
        //    FirebaseResponse response = await client.GetAsync("Usuarios",FireSharp.QueryBuilder.New().OrderBy("Email").EndAt(email1).LimitToLast(1));
        //    Usuario user = response.ResultAs<Usuario>();
        //    CodeQR.BarcodeValue = response.Body;



            //Console.WriteLine(response.Body);
            //JsonConvert.DeserializeObject(response.Body.ToString());


            // var authdatabase = "ROzTU6nnUaU32kvGUkf4HMSYxx3FT8TSh466XVyf";
            // var firebaseClient = new FirebaseClient(
            //"https://privbus-1736c.firebaseio.com/",
            //new FirebaseOptions
            //{
            //    AuthTokenAsyncFactory = () => Task.FromResult(authdatabase)
            //});


            // var Users = await firebaseClient
            //     .Child("Usuarios/")
            //    .OrderBy("Email")
            //    .EqualTo(email1)
            //    .OnceAsync<Usuario>();


            // foreach (var User in Users)
            // {
            //     JsonConvert.DeserializeObject<Usuario>(User.Object);
            //     JsonConvert.DeserializeObject<Usuario>(User.Key.ToString());
            //     Console.WriteLine(User.Object);
            //     Console.WriteLine(User.Key);



            // }

            // Usuario Users = JsonConvert.DeserializeObject<Usuario>(Users));
            //JsonConvert.DeserializeObject<Usuario>(Users.ToString());
            //Console.WriteLine();

            //foreach(var User in Users)
            //{
            //    Console.WriteLine($"{User.Key}");
            //    Console.WriteLine($"{User.Object}");
            //}


        //}

    }
}