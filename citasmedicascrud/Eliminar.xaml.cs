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
using citasmedicascrud.Constantes;

namespace citasmedicascrud
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eliminar : ContentPage
    {
        public Eliminar(string Codigo)
        {
            InitializeComponent();
            CargarDatos(Codigo);
        }


        private void CargarDatos(string Codigo)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Constantes.Constantes.Host+"/citas/obtener.php?codigo=" + Codigo);
                Request.Method = "GET";

                try
                {
                    HttpWebResponse response = (HttpWebResponse)Request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string result = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    Paciente Paciente = new Paciente();
                    Paciente = JsonConvert.DeserializeObject<Paciente>(result);
                    txtNombre.Text = Paciente.nombre;
                    txtApellido.Text = Paciente.apellido;
                    txtEdad.Text = Paciente.edad.ToString();
                    txtCodigo.Text = Paciente.codigo.ToString();
                }
                catch (Exception es)
                {
                    DisplayAlert("ALERTA", es.Message, "cerrar");
                }
            }

            catch (Exception ex)
            {

                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Constantes.Constantes.Host + "/citas/eliminar.php");
                Request.Method = "DELETE";
                Request.ContentType = Constantes.Constantes.ContentType;

                StreamWriter sw = new StreamWriter(Request.GetRequestStream());
                Paciente Paciente = new Paciente()
                {
                    codigo = Convert.ToInt32(txtCodigo.Text),
                    apellido = txtApellido.Text,
                    nombre = txtNombre.Text,
                    edad = Convert.ToInt32(txtEdad.Text)
                };
                sw.Write(JsonConvert.SerializeObject(Paciente));
                sw.Flush();
                sw.Close();
                try
                {
                    HttpWebResponse response = (HttpWebResponse)Request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string result = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    DisplayAlert("Alerta", "Dato Ingresado " + result, "salir");
                }
                catch (Exception es)
                {
                    DisplayAlert("ALERTA", es.Message, "cerrar");
                }
            }

            catch (Exception ex)
            {

                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}