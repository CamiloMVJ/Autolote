using Autolote.Models;
using Autolote.Models.DTO;
using Azure;
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
    public partial class FrmActualizarInventario : Form
    {
        //Variable que obtiene el ID del vehículo para luego obtenr el vehículo con este
        private static int VehiculoID = 0;
        public FrmActualizarInventario()
        {
            InitializeComponent();
        }
        private void FrmActualizarInventario_Load(object sender, EventArgs e)
        {
            
        }
        //Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AñadirVehiculo();
        }
        private void btnActualizarVehiculo_Click(object sender, EventArgs e)
        {
            if (VehiculoID != 0)
                ActualizarVehiculo(VehiculoID);
            else
                MessageBox.Show("No se ha elegido el carro a eliminar", "Error", MessageBoxButtons.OK);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (VehiculoID != 0)
                EliminarVehiculo(VehiculoID);
            else
                MessageBox.Show("No se ha elegido el carro a actualizar", "Error", MessageBoxButtons.OK);
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnMostrarInventario_Click(object sender, EventArgs e)
        {
            GetAllCars();
        }

        //Métodos
        private async void AñadirVehiculo()
        {
            //Creamos un objeto de la clase "VehiculoDTO" con los parametro indicado en el textbox correspondiente
            try
            {
                VehiculoDTO Vehiculo = new VehiculoDTO()
                {
                    Chasis = txtChasis.Text,
                    Marca = txtMarca.Text,
                    Precio = double.Parse(txtPrecio.Text),
                    Estado = txtEstado.Text,
                    AñoFab = int.Parse(txtAñoFab.Text),
                    Descripcion = txtDescripción.Text,
                    Color = txtColor.Text
                };
                using (var cliente = new HttpClient())
                {
                    var VehiculoSerializado = JsonConvert.SerializeObject(Vehiculo);
                    var Datos = new StringContent(VehiculoSerializado, Encoding.UTF8, "application/json");
                    var Respuesta = await cliente.PostAsync("https://localhost:7166/api/Vehiculo", Datos);
                    if (Respuesta.IsSuccessStatusCode)
                    {
                        MessageBox.Show("El vehículo ha sido agregado correctamente", "!Exito¡", MessageBoxButtons.OK);
                        GetAllCars();
                        Limpiar();
                    }
                    else
                        MessageBox.Show($"Ha ocurrido un error: {Respuesta.Content.ReadAsStringAsync().Result.ToString()}");
                }
            }
            catch (FormatException)
            {
                    MessageBox.Show("No se han llenado los datos del vehículo", "Error", MessageBoxButtons.OK);
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
            vehiculo.Descripcion = txtDescripción.Text;
            vehiculo.Color = txtColor.Text;

            using (var client = new HttpClient())
            {
                var VehiculoSerializado = JsonConvert.SerializeObject(vehiculo);
                var VehiculoContenido = new StringContent(VehiculoSerializado, Encoding.UTF8, "application/json");
                var Respuesta = await client.PutAsync(String.Format("{0}/{1}", "https://localhost:7166/api/Vehiculo", vehiculoID), VehiculoContenido);
                if (Respuesta.IsSuccessStatusCode)
                    MessageBox.Show("El vehículo ha sido actualizado", "!Exito¡", MessageBoxButtons.OK);
                else
                    MessageBox.Show("No se ha podido actualizar el vehículo correctamente", "!Error¡", MessageBoxButtons.OK);
            }
            Limpiar();
            GetAllCars();
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
        private void Limpiar()
        {
            foreach (Control Controles in this.Controls)
            {
                if(Controles is TextBox)
                {
                    Controles.Text = "";
                }
            }
            VehiculoID = 0;
        }
        //Obtenemos los vehículos para visualizarlo en el datagridview
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

        private void dgvCarros_CellClick(object sender, DataGridViewCellEventArgs e)
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
            using (var client =new HttpClient())
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
    }
}
