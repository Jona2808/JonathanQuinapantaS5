﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JonathanQuinapantaS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editar : ContentPage
    {
        
        private WS.Datos Dato { get; set; }
        public Editar(WS.Datos objt)
        {
            InitializeComponent();
            Dato = objt;
            CargarDatos();
        }
        private void CargarDatos()
        {
            txtCodigo.Text = Dato.codigo.ToString();
            txtNombre.Text = Dato.nombre.ToString();
            txtApellido.Text = Dato.apellido.ToString();
            txtEdad.Text = Dato.edad.ToString();
        }


        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                byte[] res = cliente.UploadValues("http://192.168.0.3/moviles/post.php?codigo= " + txtCodigo.Text, "DELETE", parametros);
                var r = System.Text.ASCIIEncoding.UTF8.GetString(res);
                DisplayAlert("Alerta", "Dato eliminado", "cerrar");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                cliente.UploadValues("http://192.168.0.3/moviles/post.php?codigo= " + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                DisplayAlert("Alerta", "Dato actualizados", "cerrar");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }

        private void btnAtras_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}