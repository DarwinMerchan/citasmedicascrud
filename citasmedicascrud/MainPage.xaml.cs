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

namespace citasmedicascrud
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.3.8/citas/post.php";
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
            DisplayAlert("test",codigo.CommandParameter.ToString(),"Cerrar");
        }
    }
}
