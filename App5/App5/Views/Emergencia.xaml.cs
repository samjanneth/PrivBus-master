using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using PrivBus.Clases;

namespace PrivBus.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Emergencia : ContentPage
    {


        readonly IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "ROzTU6nnUaU32kvGUkf4HMSYxx3FT8TSh466XVyf",
            BasePath = "https://privbus-1736c.firebaseio.com/"
        };

        IFirebaseClient client;
        public readonly string user;
        public readonly string em;
        public readonly string emp;
        public Emergencia(string userName, string email, string empnumber)
        {
            

            InitializeComponent();
            
           var us = "prueba";
            us = userName;
            em = email;
            emp = empnumber;
        }

        private void firebase()
        {
            client = new FireSharp.FirebaseClient(config);
            //FirebaseResponse response = await client.GetAsync("Usuarios", FireSharp.QueryBuilder.New().OrderBy("Email").EndAt(email1).LimitToLast(1));
            //Usuario user = response.ResultAs<Usuario>();
        }




        public object Toast { get; private set; }
        public object ToastLength { get; private set; }


        void Cancela1_Clicked(object sender, System.EventArgs e)
        {
            firebase();

            FirebaseResponse response = client.Get("Usuarios", FireSharp.QueryBuilder.New().OrderBy("Email").EndAt(em).LimitToLast(1));
            Usuario user = response.ResultAs<Usuario>();

            char delim = '"';
            string[] json = response.Body.Split(delim);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("PrivBusApp@gmail.com");//Este debe ser nuestro correo Gmail al que le dimos los permisos necesarios es decir el que envia los correos
                mail.To.Add("samanthajanneth5@gmail.com");//este es el correo al que llegara el correo
                mail.Subject = "CANCELADA SOLICITUD DE EMERGENCIA";// El titulo del mensaje
                mail.Body = "El usuario " + json[25] + " ha cancelado la solicitud de emergencia con correo  " + json[13] + " y número de empleado " + json[17] + ".";//El mensaje que se almaceno en el String
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("PrivBusApp@gmail.com", "Seguridadapp4");// aqui debe ir nuestro correo Gmail y nuestra contraseña
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                DisplayAlert("CORREO", "SOLICITUD CANCELADA", "OK");
            }

            catch (Exception ex)
            {
                DisplayAlert("Faild", ex.Message, "OK");
            }

        }




        void Emergencia1_Clicked(object sender, System.EventArgs e)
        {
            firebase();

            FirebaseResponse response = client.Get("Usuarios", FireSharp.QueryBuilder.New().OrderBy("Email").EndAt(em).LimitToLast(1));
            Usuario user = response.ResultAs<Usuario>();

            char delim = '"';
            string[] json = response.Body.Split(delim);

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("PrivBusApp@gmail.com");//Este debe ser nuestro correo Gmail al que le dimos los permisos necesarios es decir el que envia los correos
                mail.To.Add("samanthajanneth5@gmail.com");//este es el correo al que llegara el correo
                mail.Subject = "EMERGENCIA";// El titulo del mensaje
                mail.Body = "El usuario " + json[25] + " ha avisado que se encuentra en una situación de emergencia, con correo  " + json[13] + " y número de empleado " + json[17] + ".";//El mensaje que se almaceno en el String
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("PrivBusApp@gmail.com", "Seguridadapp4");// aqui debe ir nuestro correo Gmail y nuestra contraseña
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                DisplayAlert("CORREO", "SOLICITUD ENVIADA CON ÉXITO", "OK");
            }

            catch (Exception ex)
            {
                DisplayAlert("Faild", ex.Message, "OK");
            }

        }


    }
}