using Autolote.Models.DTO;
using Newtonsoft.Json;

namespace AutoloteInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private async void GetAllCars()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7166/api/Autolote/Lista/vehiculo"))
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

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void btnVerCarros_Click(object sender, EventArgs e)
        {
            GetAllCars();
        }

        private void btnAñadirCarro_Click(object sender, EventArgs e)
        {
            Form FormularioActualizarInventario = new FrmActualizarInventario();
            FormularioActualizarInventario.Show();
        }
    }
}