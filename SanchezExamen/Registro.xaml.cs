using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SanchezExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro(string usuario)
        {
            InitializeComponent();

            //Se carga los datos para mostrar
            lblUsuario.Text = "Usuario conectado: " + usuario.ToString();

        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Variables de almacenamiento
                string nombreEstudiante = txtNombre.Text;
                double montoInicial = Convert.ToDouble(txtMontonInicial.Text);
                double montoTotal = 1800;
                double porcentajeMontonTotal = montoTotal * 0.05;

                //Operaciones a calcular
                if (string.IsNullOrEmpty(nombreEstudiante) || montoInicial <= 0 || montoInicial > 1800)
                {
                    DisplayAlert("IMPORTANTE", "Nombre y monton son requeridos (monton debe ser mayor que 0 y menor 1800)", "ok");
                }
                else
                {
                    double subtotalDeuda = montoTotal - montoInicial;
                    double totalPagoMensual = (subtotalDeuda / 3) + porcentajeMontonTotal;

                    //Visualizar resultado operaciones
                    txtPagoMensual.Text = totalPagoMensual.ToString();

                }


            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje de alerta", ex.Message, "ok");
            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                double totalPagoMensualCalculado = Convert.ToDouble(txtPagoMensual.Text);
                double totalPagar = totalPagoMensualCalculado * 3;

                string usuarioEnviar = lblUsuario.Text;
                string nombreEnviar = txtNombre.Text;


                if (totalPagoMensualCalculado > 0)
                {
                    //Permite abrir la ventana  (viewDos) 
                    await Navigation.PushAsync(new Resumen(usuarioEnviar, nombreEnviar, totalPagar));

                    await DisplayAlert("MENSAJE", "Elemento Guardado con éxito", "ok");
                }
                else
                {
                    await DisplayAlert("IMPORTANTE", "Primero calcule el monto mensual a pagar", "ok");

                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de alerta", ex.Message, "ok");
            }
        }
    }
}