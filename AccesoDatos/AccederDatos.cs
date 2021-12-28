using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoDatos
{
    public partial class AccederDatos : Form
    {
        public AccederDatos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //1. crear la conexion
            SqlConnection conexion = new SqlConnection(@"server=DESKTOP-GIBA0R2\SQLEXPRESS; database=TI2021; Integrated Security=true");
            //2. Definir la operacion
            string sql = "insert into personas(cedula, apellido, nombre, fechadenacimiento, peso)";
            sql+= "values(@cedula, @apellido, @nombre, @fechadenacimiento, @peso)";
            //3. ejecutar la operacion
            SqlCommand comando = new SqlCommand(sql, conexion);
            //3.1 configurar los parametros @cedula, @apellidos, @nombres, @fechadenacimiento, @peso
            comando.Parameters.Add(new SqlParameter("@cedula",this.txtCedula.Text));
            comando.Parameters.Add(new SqlParameter("@apellido", this.txtApellido.Text));
            comando.Parameters.Add(new SqlParameter("@nombre", this.txtNombres.Text));
            comando.Parameters.Add(new SqlParameter("@fechadenacimiento", this.txtFechaNaci.Text));
            comando.Parameters.Add(new SqlParameter("@peso", this.txtPeso.Text));
            //3.2 abrir la conexion 
            conexion.Open();
            //3.3 Insertar el registro en la Base de datos
            int res = comando.ExecuteNonQuery();
            //4 Cerrar la conexion
            conexion.Close();
            MessageBox.Show("Filas Insertadas: " + res.ToString());
        }
    }
}
