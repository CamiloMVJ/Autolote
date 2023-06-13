using Microsoft.Data.SqlClient;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //Primeramente instanciamos una conexión con SQL
        SqlConnection Conexion = new SqlConnection("Server=LAPTOP-NJV1F4HF;database=UsuarioAutolote;Trusted_Connection = True;TrustServerCertificate = True");

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Abrimos la conexión
            Conexion.Open();
            //Instanciamos de "SqlCommand" para crear nuestro query
            SqlCommand Comando = new SqlCommand("SELECT UsuarioNombre, UsuarioContraseña FROM UsuariosAutolote WHERE UsuarioNombre = @vusuarionombre AND " +
                "UsuarioContraseña=@vusuariocontraseña", Conexion);

            Comando.Parameters.AddWithValue("@vusuarionombre", txtUsuario.Text);
            Comando.Parameters.AddWithValue("@vusuariocontraseña", txtContraseña.Text);

            SqlDataReader Lector = Comando.ExecuteReader();

            if (Lector.Read())
            {
                //Finalizamos cerrando la conexión
                Conexion.Close();
                //Abrimos el formulario principal
                Form1 FormularioPrincipal = new Form1();
                FormularioPrincipal.ShowDialog();
            }
        }
    }
}
