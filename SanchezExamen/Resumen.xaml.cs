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
    public partial class Resumen : ContentPage
    {
        public Resumen(string usuario, string nombre, double totalPagar)
        {
            InitializeComponent();

            //se le carga los datos para mostrar
            txtUsuarioConectado.Text = usuario;
            txtNombre.Text = nombre;
            
            txtTotalPagar.Text = totalPagar.ToString();

        }
    }
}