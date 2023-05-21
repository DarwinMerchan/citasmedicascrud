using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;
using citasmedicascrud.Modelo;
using Newtonsoft.Json;

namespace citasmedicascrud
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            if (usuario == "estudiante2023" && contrasena == "uisrael2023")
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                //bota la alerta y se limpia el cuadro 
                await DisplayAlert("ALERTA", "Usuario/Contraseña Incorrectos", "Cerrar");
                txtUsuario.Text = "";
                txtContrasena.Text = "";
            }
        }

    }
}
