using citasmedicascrud.WS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using citasmedicascrud.Modelo;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace citasmedicascrud
{
    public partial class MainPage : ContentPage
    {
        private string Url = Constantes.Constantes.Host + "/citas/obtener.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Paciente> post;
                    
        public MainPage()
        {
            InitializeComponent();
            obtener();
        }

        public async void obtener()
        {
            var content = await cliente.GetStringAsync(Url);
            List<Paciente> posts = JsonConvert.DeserializeObject<List<Paciente>>(content);
            post = new ObservableCollection<Paciente>(posts);
            lista.ItemsSource = post;

        }

        private void btnregistro_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());//
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var codigo = (Button)sender;
            Navigation.PushAsync(new Actualizar(codigo.CommandParameter.ToString()));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var codigo = (Button)sender;
            Navigation.PushAsync(new Eliminar(codigo.CommandParameter.ToString()));

           // DisplayAlert("ALERTA", codigo.CommandParameter.ToString(), "cerrar");
        }
    }
}
