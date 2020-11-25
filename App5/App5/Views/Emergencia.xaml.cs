﻿using System;
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



namespace PrivBus.Views
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Emergencia : ContentPage
    {

        //se agrega parámetro de username para tomar la variable en el cuerpo del mensaje
        public readonly string username;

        public Emergencia(string userName, string email, string empnumber)
        {
            InitializeComponent();

          username = userName;
        }

      



        public object Toast { get; private set; }
        public object ToastLength { get; private set; }

            }

        



        void Emergencia1_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("PrivBusApp@gmail.com");//Este debe ser nuestro correo Gmail al que le dimos los permisos necesarios es decir el que envia los correos
                mail.To.Add("samanthajanneth5@gmail.com");//este es el correo al que llegara el correo
                mail.Subject = "EMERGENCIA";// El titulo del mensaje
                //se concatena variable username
                mail.Body = "El usuario "+ username +" se encuentra en una situación de emergencia";//El mensaje que se almaceno en el estring
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