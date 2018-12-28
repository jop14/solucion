using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MODERN_GUI_2
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        private void iconCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de cerrar?", "Esta a punto de cerrar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //tus codigos
                Application.Exit();
            }
            else { 
            //tus codigos
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        int LX, LY,SW,SH;
        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            LX = this.Location.X;
            LY = this.Location.Y;
            SW = this.Size.Width;
            SH = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            // iconmaximizar.Visible = false;
            // iconrestaurar.Visible = true;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(SW, SH);
            this.Location = new Point(LX,LY);
            // iconmaximizar.Visible = true;
            // iconrestaurar.Visible = false;
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 57)
            {
                MenuVertical.Width = 174;
            }
            else

                MenuVertical.Width = 57;
        }

        private void btnPRODUCTOS_Click(object sender, EventArgs e)
        {

            formGaso frm = new formGaso();
            frm.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(frm);

        }

        public void btnINICIO_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormLogo());
        }
         

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarlogo();
        }
        private void mostrarlogo() {
            AbrirFormInPanel(new FormLogo());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnEMPLEADOS_Click(object sender, EventArgs e)
        {

        }

        private void btnPAGOS_Click(object sender, EventArgs e)
        {
            formCerti frm = new formCerti();
            frm.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(frm);
        }

        private void btnCOMPRAS_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pruebas frm = new pruebas();
            frm.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(frm);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormLogo());
        }

        private void mostrarlogoAlCerrarForm(object sender, FormClosedEventArgs e) {
            mostrarlogo();
        }

        private void btnVENTAS_Click(object sender, EventArgs e)
        {
            frmCer frm = new frmCer();
            frm.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(frm);
        }
        protected override void WndProc(ref Message msj)
        {
            const int CoordenadaWFP = 0x84; //ibicacion de la parte derecha inferior del form
            const int DesIzquierda = 16;
            const int DesDerecha = 17;
            if (msj.Msg == CoordenadaWFP)
            {
                int x = (int)(msj.LParam.ToInt64() & 0xFFFF);
                int y = (int)((msj.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point CoordenadaArea = PointToClient(new Point(x, y));
                Size TamañoAreaForm = ClientSize;
                if (CoordenadaArea.X >= TamañoAreaForm.Width - 16 && CoordenadaArea.Y >= TamañoAreaForm.Height - 16 && TamañoAreaForm.Height >= 16)
                {
                    msj.Result = (IntPtr)(IsMirrored ? DesIzquierda : DesDerecha);
                    return;
                }
            }
            base.WndProc(ref msj);
        }
       

      
    }
}
