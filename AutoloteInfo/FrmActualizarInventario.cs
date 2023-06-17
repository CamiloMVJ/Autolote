﻿using Autolote.Models;
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
        private static string NumeroChasis;
        public FrmActualizarInventario()
        {
            InitializeComponent();
        }
        private void FrmActualizarInventario_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

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
                Descripcion = txtDescripción.Text,
                Color = txtColor.Text
            };
            using(var vehiculo = new HttpClient())
            {
                var VehiculoSerializado = JsonConvert.SerializeObject(Vehiculo);
                var Datos = new StringContent(VehiculoSerializado, Encoding.UTF8, "application/json");
                var Respuesta = await vehiculo.PostAsync("https://localhost:7166/api/Vehiculo\r\n", Datos);
                if (Respuesta.IsSuccessStatusCode)
                {
                    MessageBox.Show("El vehículo ha sido agregado correctamente");
                }else
                    MessageBox.Show($"Ha ocurrido un error: {Respuesta.Content.ReadAsStringAsync().Result.ToString()}");

            }
        }

        private void btnActualizarVehiculo_Click(object sender, EventArgs e)
        {

        }

        //Obtenemos los vehículos para visualizarlo en el datagridview
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
                    NumeroChasis = row.Cells[7].Value.ToString();
                    ObtenerVehiculoxChasis(NumeroChasis);
                }
            }
        }

        private async void ObtenerVehiculoxChasis(string? numeroChasis)
        {
            using (var client =new HttpClient())
            {
                var Respuesta = await client.GetAsync(string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", "https://localhost:7166/api/Vehiculo", numeroChasis));
                //Comprobamos que la respuesta HTTP se realizó correctamente
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
                }
                else
                    MessageBox.Show("No se han podido obtener los dato del vehículo: {0}", Respuesta.StatusCode.ToString());
            }
        }

        private void btnMostrarInventario_Click(object sender, EventArgs e)
        {
            GetAllCars();
        }
    }
}
