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
    public partial class PruebaConexion : Form
    {
        private int idVehiculo;
        public PruebaConexion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AñadirVehiculo();
        }

        private async void AñadirVehiculo()
        {
            VehiculoDTO Vehiculo = new VehiculoDTO()
            {
                Chasis = txtChasis.Text,
                Marca = txtMarca.Text,
                Precio = double.Parse(txtPrecio.Text),
                Estado = txtEstado.Text,
                AñoFab = int.Parse(txtAñoFab.Text),
                Color = txtColor.Text
            };
            using (var vehiculo = new HttpClient())
            {
                var VehiculoSerializado = JsonConvert.SerializeObject(Vehiculo);
                var Datos = new StringContent(VehiculoSerializado, Encoding.UTF8, "application/json");
                var Respuesta = await vehiculo.PostAsync("https://localhost:7166/api/Autolote/AgregarVehiculo", Datos);
                if (Respuesta.IsSuccessStatusCode)
                {
                    MessageBox.Show("El vehículo ha sido agregado correctamente");
                }
                else
                    MessageBox.Show($"Ha ocurrido un error: {Respuesta.Content.ReadAsStringAsync().Result.ToString()}");
            }
        }
        private async void GetAllCars()
        {
            using (var client = new HttpClient())
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
        }

        private void dgvCarros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCarros.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    idVehiculo = int.Parse(row.Cells[0].Value.ToString());
                    ObtenerVehiculoxChasis(idVehiculo);
                }
            }
        }

        private async void ObtenerVehiculoxChasis(int numeroChasis)
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
                    txtDescripcion.Text = vehiculo.Descripcion.ToString();
                    txtEstado.Text = vehiculo.Estado;
                }
                else
                    MessageBox.Show("No se han podido obtener los dato del vehículo: {0}", Respuesta.StatusCode.ToString());
            }
        }
        private async void EliminarVehiculo(int vehiculoID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7166/api/Vehiculo");
                string VariablePrueba = String.Format("{0}={1}",
                    "https://localhost:7166/api/Vehiculo?id", vehiculoID);
                var Respuesta = await client.DeleteAsync(VariablePrueba);
                if (Respuesta.IsSuccessStatusCode)
                {
                    MessageBox.Show("El vehículo se ha eliminado correctamente", "!Exito¡", MessageBoxButtons.OK);
                    Limpiar();
                    GetAllCars();
                }
                else
                    MessageBox.Show("No se ha podido eliminar el vehículo correctamente", "!Error¡", MessageBoxButtons.OK);

            }
        }
        private async void ActualizarVehiculo(int vehiculoID)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Chasis = txtChasis.Text;
            vehiculo.Marca = txtMarca.Text;
            vehiculo.Precio = decimal.Parse(txtPrecio.Text);
            vehiculo.Estado = txtEstado.Text;
            vehiculo.AñoFab = int.Parse(txtAñoFab.Text);
            vehiculo.Descripcion = txtDescripcion.Text;
            vehiculo.Color = txtColor.Text;
            vehiculo.VehiculoId = idVehiculo;

            using (var client = new HttpClient())
            {
                var VehiculoSerializado = JsonConvert.SerializeObject(vehiculo);
                var VehiculoContenido = new StringContent(VehiculoSerializado, Encoding.UTF8, "application/json");
                var Respuesta = await client.PutAsync(String.Format("{0}={1}", "https://localhost:7166/api/Vehiculo?id", vehiculoID), VehiculoContenido);
                if (Respuesta.IsSuccessStatusCode)
                    MessageBox.Show("El vehículo ha sido actualizado", "!Exito¡", MessageBoxButtons.OK);
                else
                    MessageBox.Show("No se ha podido actualizar el vehículo correctamente", "!Error¡", MessageBoxButtons.OK);
            }
            Limpiar();
            GetAllCars();
        }

        private void Limpiar()
        {
            foreach (Control Controles in this.Controls)
            {
                if (Controles is TextBox)
                {
                    Controles.Text = "";
                }
            }
            idVehiculo = 0;
        }

        private void btnTabla_Click(object sender, EventArgs e)
        {

        }

        private void PruebaConexion_Load(object sender, EventArgs e)
        {
            GetAllCars();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarVehiculo(idVehiculo);
        }

        private void btnActualizarVehiculo_Click(object sender, EventArgs e)
        {
            ActualizarVehiculo(idVehiculo);
        }
    }
}
