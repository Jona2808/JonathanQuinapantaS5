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

namespace JonathanQuinapantaS5
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.0.3/moviles/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<JonathanQuinapantaS5.WS.Datos> post;
        public MainPage()
        {
            InitializeComponent();
            Obtener();
            //Actualizar();
            //Eliminar();
        }

        public async void Obtener()
        {
            var content = await cliente.GetStringAsync(Url);
            List<JonathanQuinapantaS5.WS.Datos> posts = JsonConvert.DeserializeObject<List<JonathanQuinapantaS5.WS.Datos>>(content);
            post = new ObservableCollection<WS.Datos>(posts);
            lista.ItemsSource = post;   
        }
                
        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objt = (WS.Datos)e.SelectedItem;
            var item = objt.codigo.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Editar(objt));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
