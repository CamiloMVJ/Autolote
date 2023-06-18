using Autolote.Models;
using Autolote.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoloteInfo
{
    public partial class FrmRegistroVentas : Form
    {
        private static int VehiculoID = 0;
        public FrmRegistroVentas()
        {
            InitializeComponent();
        }

        private void btnMostrarInventario_Click(object sender, EventArgs e)
        {
            GetAllCars();
        }
        private async void GetAllCars()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync("https://localhost:7166/api/Vehiculo"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var cars = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<List<VehiculoDTO>>(cars);
                            dgvCarros.DataSource = result.ToList();
                        }
                        else
                        {
                            MessageBox.Show($"No se ha podido obtener el inventario de carros debido ha: {response.StatusCode}");
                        }
                    }
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    MessageBox.Show("Aún no se ha establecido la conexión con la API", "!Error¡", MessageBoxButtons.OK);
                }
            }
        }

        private void dgvCarros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCarros.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    //Obtenemo el valor de la primer celda
                    VehiculoID = int.Parse(row.Cells[0].Value.ToString());
                    //Se preocede con el método con el que se obtendrá el vehículo por medio de su ID
                    ObtenerVehiculoxChasis(VehiculoID);
                }
            }
        }
        private async void ObtenerVehiculoxChasis(int? idVehiculo)
        {
            using (var client = new HttpClient())
            {
                var Respuesta = await client.GetAsync(String.Format("{0}/{1}", "https://localhost:7166/api/Vehiculo", idVehiculo));
                //Comprobamos que la solicitud HTTP se haya realizado correctamente
                if (Respuesta.IsSuccessStatusCode)
                {
                    //El método "ReadAsStringAsync()" serializa el contenido HTTP en una cadena como una operación asincrónica
                    var Datos = await Respuesta.Content.ReadAsStringAsync();
                    //Se deserializa el contenido HTTP como un objeto de la clase "Vehiculo"
                    Vehiculo vehiculo = JsonConvert.DeserializeObject<Vehiculo>(Datos);
                    //Se reflejan los valores en cada textBox
                    txtChasis.Text = vehiculo.Chasis;
                    txtMarca.Text = vehiculo.Marca;
                    txtAñoFab.Text = vehiculo.AñoFab.ToString();
                    txtColor.Text = vehiculo.Color;
                    txtPrecio.Text = vehiculo.Precio.ToString();
                    txtDescripción.Text = vehiculo.Descripcion.ToString();
                    txtEstado.Text = vehiculo.Estado;
                }
                else
                    MessageBox.Show("No se han podido obtener los dato del vehículo: {0}", Respuesta.StatusCode.ToString());
            }
        }

        private void FrmRegistroVentas_Load(object sender, EventArgs e)
        {

        }
    } 
}
