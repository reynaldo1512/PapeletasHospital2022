using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;
namespace HospitalRegionalIca
{
    public partial class frmTrabajador : Form
    {
      
        TrabajadorNegocio trabajadorNegocio = new TrabajadorNegocio();
        
        public frmTrabajador()
        {
            InitializeComponent();
            mostrarTrabajador();
            HideWidthColumns();




        }
        public void HideWidthColumns()
        {


           





        }
        public void mostrarTrabajador()
        {
            
            
                TrabajadorNegocio trabajador = new TrabajadorNegocio();
                dataGridViewTrabajador.DataSource = trabajador.ListarTrabajadores();

            
            
        }

        public void BuscarTrabajador(string filtro)
        {
            if (txtBuscar.Text == "")
            {
                mostrarTrabajador();

            }
            else
            {
                TrabajadorNegocio trabajador = new TrabajadorNegocio();
                dataGridViewTrabajador.DataSource = trabajador.Buscartrabajador(filtro);

            }
            
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
             //var dni =txtBuscarDNI.TextChanged+= new EventHandler()
            BuscarTrabajador(txtBuscar.Text);
        }
        private void lblTrabajador_changed(object sender, EventArgs e)
        {

           
        }
       

        private void dataGridViewTrabajador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            //ObtenerIdDpto();


        



        }

        //private void ObtenerIdDpto()
        //{
            

        //    txtBuscar.Text = UsuarioModel.id_departamento.ToString();
        //}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtIdDpto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAddTrabajador frm = new FormAddTrabajador();
            frm.ShowDialog();
            frm.Update = false;

            mostrarTrabajador();
           
           
            

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTrabajador.SelectedRows.Count > 0)
            {

                FormAddTrabajador frm = new FormAddTrabajador();
                frm.Update = true;
                frm.txtId.Text = dataGridViewTrabajador.CurrentRow.Cells["id_trabajador"].Value.ToString();
                frm.txtDNI.Text = dataGridViewTrabajador.CurrentRow.Cells["DNI"].Value.ToString();
                frm.txtPnombre.Text = dataGridViewTrabajador.CurrentRow.Cells["primer_nombre"].Value.ToString();
                frm.txtSnombre.Text = dataGridViewTrabajador.CurrentRow.Cells["segundo_nombre"].Value.ToString();
                frm.txtPapellido.Text = dataGridViewTrabajador.CurrentRow.Cells["apellido_paterno"].Value.ToString();
                frm.txtSapellido.Text = dataGridViewTrabajador.CurrentRow.Cells["apellido_materno"].Value.ToString();
                frm.txtPlaza.Text = dataGridViewTrabajador.CurrentRow.Cells["plaza"].Value.ToString();

                frm.txtRemuneracion.Text = dataGridViewTrabajador.CurrentRow.Cells["remuneracion"].Value.ToString();
                frm.txtNivel.Text = dataGridViewTrabajador.CurrentRow.Cells["nivel"].Value.ToString();
                frm.dtpfechaNacimiento.Text = dataGridViewTrabajador.CurrentRow.Cells["fecha_nacimiento"].Value.ToString();
                frm.cmbCargo.Text = dataGridViewTrabajador.CurrentRow.Cells["Cargo"].Value.ToString();
                frm.cmbCategoria.Text = dataGridViewTrabajador.CurrentRow.Cells["Categoria"].Value.ToString();
                frm.cmbPersonal.Text = dataGridViewTrabajador.CurrentRow.Cells["Personal"].Value.ToString();
                frm.cmbDepartamento.Text = dataGridViewTrabajador.CurrentRow.Cells["Departamento"].Value.ToString();
                frm.dtpFechaIngreso.Text = dataGridViewTrabajador.CurrentRow.Cells["F_Ingreso"].Value.ToString();
                frm.cmbHorario.Text = dataGridViewTrabajador.CurrentRow.Cells["Horario"].Value.ToString();


                frm.ShowDialog();
                mostrarTrabajador();




            }
            else MessageBox.Show("Seleccione la fila del trabajador");
        }
    }
}
