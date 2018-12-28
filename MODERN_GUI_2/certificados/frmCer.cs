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
    public partial class frmCer : Form
    {
        conexion datos = new conexion();
        public frmCer()
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
                //frm.txtid.Text = dtgResu.CurrentRow.Cells[0].Value.ToString();
                //frm.txtcategoria.Text = dtgResu.CurrentRow.Cells[1].Value.ToString();
                //frm.txtdescrip.Text = dtgResu.CurrentRow.Cells[2].Value.ToString();
                //frm.txtprecio.Text = dtgResu.CurrentRow.Cells[3].Value.ToString();
                //frm.txtstock.Text = dtgResu.CurrentRow.Cells[4].Value.ToString();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("debe seleccionar fila");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           
        }

        private void InsertarFilas()
        {
            //dataGridView1.Rows.Insert(0, "E00000", "Grupo Sierra", "Sierra hermanos", "PEMEX", "Cliente");
            try
            {
                datos.consulta("SELECT idest AS ID, cerEnvIn AS ENVOLINICIO, cerEnvFn AS ENVOLFIN, cerEtrIn AS E3000INI, cerEtrFn AS E3000FIN FROM certificados", "certificados");
                this.dtgResu.DataSource = datos.ds.Tables["certificados"];
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
            //frm.txtcategoria.Text = dtgResu.CurrentRow.Cells[1].Value.ToString();
            //frm.txtdescrip.Text = dtgResu.CurrentRow.Cells[2].Value.ToString();
            //frm.txtprecio.Text = dtgResu.CurrentRow.Cells[3].Value.ToString();
            //frm.txtstock.Text = dtgResu.CurrentRow.Cells[4].Value.ToString();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            regCer frm = new regCer();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
