using App5.NewFolder3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        public Start()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
           await Navigation.PushModalAsync(new Login());
        }

       async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
        }
    }
}