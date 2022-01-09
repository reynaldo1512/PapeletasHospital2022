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
using System.Configuration;
using System.Data.SqlClient;

namespace HospitalRegionalIca.frm
{
    public partial class frmPapeleta : Form
    {
        public frmPapeleta()
        {
            InitializeComponent();
            HideWidthColumns();


            if (UsuarioModel.id_rol==1)
            {
                MostrarPapeleta(/*UsuarioModel.id_departamento*/);
            }
            
        }
        public void HideWidthColumns()
        {







        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (UsuarioModel.id_rol==1)
            {
               
                frmAddPapeleta frm = new frmAddPapeleta();
                frm.ShowDialog();
                frm.Update = false;
                MostrarPapeleta(/*UsuarioModel.id_departamento*/);
            }
            else if(UsuarioModel.id_rol==2)
            {
                //codigo

            }

           
        }

        public void MostrarPapeleta(/*int id_dpto*/)
        {
            PapeletaNegocio papeleta = new PapeletaNegocio();
            dataGridViewPapeleta.DataSource = papeleta.ListarPapeletas();
        }

        public void FiltrarPapeleta(string filtro)
        {

            if (txtBuscar.Text=="")
            {
                MostrarPapeleta();
            }
            else
            {
                PapeletaNegocio papeleta = new PapeletaNegocio();
                dataGridViewPapeleta.DataSource = papeleta.BuscarPapeletas(filtro);
            }

           




        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (UsuarioModel.id_rol==1)
            {
                if (dataGridViewPapeleta.SelectedRows.Count > 0)
                {

                    frmAddPapeleta frm = new frmAddPapeleta();
                    frm.Update = true;
                    frm.groupBox1.Enabled = false;
                    frm.dtpFechaRegistro.Enabled = false;
                    frm.txtIdPapeleta.Text = dataGridViewPapeleta.CurrentRow.Cells["id_papeleta"].Value.ToString();
                    string IdTipoPapeleta = dataGridViewPapeleta.CurrentRow.Cells["id_tipoPapeleta"].Value.ToString();
                    frm.txtCodigo.Text = dataGridViewPapeleta.CurrentRow.Cells["numero_documento"].Value.ToString();
                    if (Convert.ToInt32(IdTipoPapeleta) == 1)
                    {

                        frm.rbtnDia.Checked = true;
                        if (frm.rbtnDia.Checked == true)
                        {
                            frm.gpDia.Enabled = true;
                            frm.gpHora.Enabled = false;


                        }
                        frm.dtpFechaInicial.Text = dataGridViewPapeleta.CurrentRow.Cells["fecha_inicio"].Value.ToString();
                        frm.dtpFechaFinal.Text = dataGridViewPapeleta.CurrentRow.Cells["fecha_fin"].Value.ToString();

                    }
                    else if (Convert.ToInt32(IdTipoPapeleta) == 2)
                    {

                        frm.rbtnHora.Checked = true;
                        if (frm.rbtnHora.Checked == true)
                        {
                            frm.gpHora.Enabled = true;
                            frm.gpDia.Enabled = false;

                        }
                        frm.dtpFechaPermiso.Text = dataGridViewPapeleta.CurrentRow.Cells["fecha_inicio"].Value.ToString();
                        frm.txtHoraInicio.Text = dataGridViewPapeleta.CurrentRow.Cells["hora_inicio"].Value.ToString();
                        frm.txtMinInicio.Text = dataGridViewPapeleta.CurrentRow.Cells["minuto_inicio"].Value.ToString();
                        frm.txtHoraFin.Text = dataGridViewPapeleta.CurrentRow.Cells["hora_fin"].Value.ToString();
                        frm.txtMinFin.Text = dataGridViewPapeleta.CurrentRow.Cells["minuto_fin"].Value.ToString();
                    }
                    frm.dtpFechaRegistro.Text = dataGridViewPapeleta.CurrentRow.Cells["fecha_registro"].Value.ToString();
                    frm.txtnombre.Text = dataGridViewPapeleta.CurrentRow.Cells["Trabajador"].Value.ToString();
                    frm.cmbTurno.Text = dataGridViewPapeleta.CurrentRow.Cells["turno"].Value.ToString();
                    frm.cmbMotivo.Text = dataGridViewPapeleta.CurrentRow.Cells["motivo"].Value.ToString();
                    frm.txtDescuento.Text = dataGridViewPapeleta.CurrentRow.Cells["descuento"].Value.ToString();
                    frm.txtSustento.Text= dataGridViewPapeleta.CurrentRow.Cells["sustento"].Value.ToString();

                    frm.ShowDialog();
                    MostrarPapeleta();

                }
                else MessageBox.Show("Seleccione la fila de la papeleta");

            }
            else if(UsuarioModel.id_rol==2)
            {
                //codigo
            }
            
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPapeleta.SelectedRows.Count > 0)
            {

                PapeletaNegocio papeleta = new PapeletaNegocio();

               int id_papeleta =Convert.ToInt32(dataGridViewPapeleta.CurrentRow.Cells["id_papeleta"].Value);
                

                papeleta.EliminarPapeleta(id_papeleta);
                MostrarPapeleta();

            }
            else MessageBox.Show("Seleccione la fila del trabajador");
        }


     
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            txtBuscar.Visible = true;
            


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            FiltrarPapeleta(txtBuscar.Text);
        }
    }
}
