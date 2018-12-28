using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODERN_GUI_2
{
    public partial class formGaso : Form
    {
        conexion datos = new conexion();
        public formGaso()
        {
            InitializeComponent();
        }
        private void FormProductos_Load(object sender, EventArgs e)
        {
            InsertarFilas();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            regGaso frm = new regGaso();
            if (dtgResu.SelectedRows.Count > 0)
            {
                frm.txtId.Text = dtgResu.CurrentRow.Cells[0].Value.ToString();
                frm.txtNombre.Text = dtgResu.CurrentRow.Cells[1].Value.ToString();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("debe seleccionar fila");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            regGaso frm = new regGaso();
            frm.ShowDialog();
        }

        private void InsertarFilas()
        {
            //dataGridView1.Rows.Insert(0, "E00000", "Grupo Sierra", "Sierra hermanos", "PEMEX", "Cliente");
            try
            {
                datos.consulta("SELECT idGas AS Identificador, nombre AS 'Nombre de grupo gasolinero' FROM gasolinera", "gasolinera");
                this.dtgResu.DataSource = datos.ds.Tables["gasolinera"];
                this.dtgResu.Refresh();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            regGaso frm = Owner as regGaso;
            //frm.txtcategoria.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //frm.txtdescrip.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //frm.txtprecio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //frm.txtstock.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
