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
using CapaEntidad;
using HospitalRegionalIca.frm;

namespace HospitalRegionalIca
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cerra la aplicacion ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
            
            
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            pSubMenuReportes.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pSubMenuReportes.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pSubMenuReportes.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pSubMenuReportes.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta cerrando la aplicacion ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();

        }


        //METODO PARA ABRIR FORMULARIOS DENTRO DEL PANEL
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = pContenedor.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                pContenedor.Controls.Add(formulario);
                pContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            //if (Application.OpenForms["frmDashboard"] == null)
               // button1.BackColor = Color.FromArgb(4, 41, 68);
            //if (Application.OpenForms["Form2"] == null)
            //    button2.BackColor = Color.FromArgb(4, 41, 68);
            //if (Application.OpenForms["Form3"] == null)
            //    button3.BackColor = Color.FromArgb(4, 41, 68);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            btnInicio_Click(null, e);
            timer1.Enabled = true;
            ObtenerDatosUsuario();
       

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //AbrirFormFUA(new frmFUA());
            AbriFormTrabajador(new frmTrabajador());

        }
        private void AbriFormTrabajador(object formTrabajador)
        {
            if (this.pContenedor.Controls.Count > 0)
                this.pContenedor.Controls.RemoveAt(0);
            Form trabajador = formTrabajador as Form;
            trabajador.TopLevel = false;
            trabajador.Dock = DockStyle.Fill; //esto hace que el formulario que estamos llamando se acople al panel
            this.pContenedor.Controls.Add(trabajador);
            this.pContenedor.Tag = trabajador;
            trabajador.Show();
        }
        private void AbriFormPapeleta(object formPapeleta)
        {
            if (this.pContenedor.Controls.Count > 0)
                this.pContenedor.Controls.RemoveAt(0);
            Form papeleta = formPapeleta as Form;
            papeleta.TopLevel = false;
            papeleta.Dock = DockStyle.Fill; //esto hace que el formulario que estamos llamando se acople al panel
            this.pContenedor.Controls.Add(papeleta);
            this.pContenedor.Tag = papeleta;
            papeleta.Show();
        }
        //private void AbrirFormFUA(object formFua)
        //{
        //    if (this.pContenedor.Controls.Count > 0)

        //        this.pContenedor.Controls.RemoveAt(0);
        //    Form Fua = formFua as Form;
        //    Fua.TopLevel = false;
        //    Fua.Dock = DockStyle.Fill; //esto hace que el formulario que estamos llamando se acople al panel
        //    this.pContenedor.Controls.Add(Fua);
        //    this.pContenedor.Tag = Fua;                                                                                                 
        //    Fua.Show();

        //}

        private void ObtenerDatosUsuario()
        {
            
            lblUsuario.Text = UsuarioModel.nombre_usuario;
            lblDepartamento.Text = UsuarioModel.id_departamento.ToString();
        }
        private void pBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDepartamento_Click(object sender, EventArgs e)
        {

        }

        private void pContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void lblBuscarIdDpto_lblChanged(object sender, EventArgs e)
        {


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
           AbriFormPapeleta(new frmPapeleta());
        }
    }
}
