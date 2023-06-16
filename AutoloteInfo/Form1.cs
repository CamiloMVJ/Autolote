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

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllCars();
        }

        private async void GetAllCars()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7166/api/Autolote"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var cars = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<VehiculoDTO>>(cars);
                        dgvStudents.DataSource = result.ToList();
                    }
                    else
                    {
                        MessageBox.Show($"No se puede obtener la lista de estudiantes: {response.StatusCode}");
                    }
                }
            }
        }
    }
}