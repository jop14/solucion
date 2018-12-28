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
    public partial class pruebas : Form
    {
        conexion datos = new conexion();
        public pruebas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formGaso frm = new formGaso();
            AddOwnedForm(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.Controls.Add(frm);
            this.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formCerti_Load(object sender, EventArgs e)
        {
            try
            {
                datos.consulta("SELECT * FROM certificados", "certificados");
                this.dtgResu.DataSource = datos.ds.Tables["certificados"];
                this.dtgResu.Refresh();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
