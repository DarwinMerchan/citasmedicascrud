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


namespace citasmedicascrud
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://127.19.96.1/citas/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Datos> post;
                    
        public MainPage()
        {
            InitializeComponent();
            
        }

        public async void obtener()
        {
            var content = await cliente.GetStringAsync(Url);
            List<citasmedicascrud.WS.Datos> posts = JsonConvert.DeserializeObject<List<citasmedicascrud.WS.Datos>>(content);
            post = new ObservableCollection<WS.Datos>(post);
            lista.ItemsSource = post;

        }

        private void btnregistro_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());//
        }
    }
}
