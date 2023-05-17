﻿using System;
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
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("http://192.168.3.8/citas/post.php");
                Request.Method = "POST";
                Request.ContentType = "application/json";

                StreamWriter sw= new StreamWriter(Request.GetRequestStream());
                Paciente Paciente = new Paciente() {
                apellido=txtApellido.Text,
                nombre=txtNombre.Text,
                edad= Convert.ToInt32(txtEdad.Text)
                };
                sw.Write(JsonConvert.SerializeObject(Paciente));
                sw.Flush();
                sw.Close();
                try {
                    HttpWebResponse response = (HttpWebResponse)Request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string result = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    DisplayAlert("Alerta", "Dato Ingresado "+ result, "salir");
                } catch (Exception es){
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