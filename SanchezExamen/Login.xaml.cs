using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SanchezExamen
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnAcceder_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Variables de almacenamiento
                string usuario = txtUsuario.Text;
                string clave = txtClave.Text;

                //Verificando ingreso de datos no sean nulos, ni vacios
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
                {
                    await DisplayAlert("IMPORTANTE", "Usuario y clave son requeridos", "ok");
                }
                else
                {
                    //validando valores de conexion
                    if (usuario.Equals("estudiante2021") && clave.Equals("uisrael2021"))
                    {
                        //Presentara segunda pantalla 
                        await Navigation.PushAsync(new Registro(usuario));                      
                    }
                    else
                    {
                        await DisplayAlert("Mensaje de Error:", "Usuario y/o clave incorrectos", "ok");
                    }

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de alerta", ex.Message, "ok");
            }
        }
    }
}
