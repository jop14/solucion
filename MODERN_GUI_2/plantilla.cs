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
    public partial class pla : Form
    {
        public pla()
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //frm.txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //frm.txtcategoria.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //frm.txtdescrip.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //frm.txtprecio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //frm.txtstock.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
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
            dataGridView1.Rows.Insert(0, "E00000", "Grupo Sierra", "Sierra hermanos", "PEMEX", "Cliente");
  
          
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
    }
}
