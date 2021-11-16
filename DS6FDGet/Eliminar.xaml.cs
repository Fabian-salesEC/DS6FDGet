using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DS6FDGet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eliminar : ContentPage
    {
        public Eliminar()
        {
            InitializeComponent();
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);

                cliente.UploadValues("http://192.168.100.12/moviles/post.php", "DELETE", parametros);
                DisplayAlert("Mensaje", "Resgistro borrado", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message, "OK");
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}