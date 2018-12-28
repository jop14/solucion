using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Odbc;

namespace MODERN_GUI_2
{
    public partial class regGaso : Form
    {
        conexion datos = new conexion();
        public regGaso()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                datos.cn.Open();
                String id = txtId.Text;
                String nombre = txtNombre.Text;
                OdbcCommand cm = datos.cn.CreateCommand();
                cm.CommandText = "INSERT INTO gasolinera(idGas, nombre) VALUES ('" + id + "','" + nombre + "')";

                int col_afect = cm.ExecuteNonQuery();
                if (col_afect > 0)
                {
                    MessageBox.Show("Gasolinera registrada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtId.Clear();
                    txtNombre.Clear();
                }
                else
                {
                    MessageBox.Show("Fallo al registrar.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                datos.cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
