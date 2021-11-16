using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace DS6FDGet
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.12/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<DS6FDGet.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<DS6FDGet.Ws.Datos> posts = JsonConvert.DeserializeObject<List<DS6FDGet.Ws.Datos>>(content);
                _post = new ObservableCollection<DS6FDGet.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var mensaje = "Alerta Toast Xamarin";
            DependencyService.Get<Mensaje>().longAlert(mensaje);
            await Navigation.PushAsync(new NavigationPage(new vieInsertar()));

        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var mensaje = "Borrar registro";
            DependencyService.Get<Mensaje>().longAlert(mensaje);
            await Navigation.PushAsync(new NavigationPage(new Eliminar()));
        }
    }
}
