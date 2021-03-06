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
            else if (UsuarioModel.id_rol==2)
            {
                MostrarPapeletaUsuario(UsuarioModel.id_departamento);
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
                radioButton1.Checked = false;
               

            }
            else if(UsuarioModel.id_rol==2)
            {
                frmAddPapeleta frm = new frmAddPapeleta();
                frm.ShowDialog();
                frm.Update = false;
                MostrarPapeletaUsuario(UsuarioModel.id_departamento);
                

            }

           
        }

        public void MostrarPapeleta(/*int id_dpto*/)
        {
            PapeletaNegocio papeleta = new PapeletaNegocio();
            dataGridViewPapeleta.DataSource = papeleta.ListarPapeletas();
           dataGridViewPapeleta.Columns[0].Visible = false;
            dataGridViewPapeleta.Columns[1].Visible = false;
            dataGridViewPapeleta.Columns[2].Visible = false;
            dataGridViewPapeleta.Columns[5].Visible = false;




        }

        public void MostrarPapeletaUsuario(int id_departamento)
        {
            PapeletaNegocio papeleta = new PapeletaNegocio();
            dataGridViewPapeleta.DataSource = papeleta.ListarPapeletasUsuario(id_departamento);
        }

        public void FiltrarPapeleta(string filtro)
        {
            if (UsuarioModel.id_rol==1)
            {
                if (txtBuscar.Text == "")
                {
                    MostrarPapeleta();
                }
                else
                {
                    PapeletaNegocio papeleta = new PapeletaNegocio();
                    dataGridViewPapeleta.DataSource = papeleta.BuscarPapeletas(filtro);
                }
            }
          

        }
        public void FiltrarPapeletaUsuario(string filtro)
        {
            if (UsuarioModel.id_rol == 2)
            {
                if (txtBuscar.Text == "")
                {
                    MostrarPapeletaUsuario(UsuarioModel.id_departamento);
                }
                else
                {
                    PapeletaNegocio papeleta = new PapeletaNegocio();
                    dataGridViewPapeleta.DataSource = papeleta.BuscarPapeletaUsuario(filtro, UsuarioModel.id_departamento);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //if (UsuarioModel.id_rol==1)
            
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
                    frm.lblIdSolicitud.Text = dataGridViewPapeleta.CurrentRow.Cells["id_solicitud"].Value.ToString();
                    frm.lblRDia.Text= dataGridViewPapeleta.CurrentRow.Cells["remuneracion_dia"].Value.ToString();
                    frm.lblRmin.Text= dataGridViewPapeleta.CurrentRow.Cells["remuneracion_minuto"].Value.ToString();

                frm.ShowDialog();


                if (UsuarioModel.id_rol==1)
                {
                    MostrarPapeleta();
                }
                else if (UsuarioModel.id_rol==2)
                {
                    MostrarPapeletaUsuario(UsuarioModel.id_departamento);
                }
                

                }
                else MessageBox.Show("Seleccione la fila de la papeleta");

            
            //else if(UsuarioModel.id_rol==2)
            //{
            //    //codigo
            //}
            
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

            if (UsuarioModel.id_rol==1)
            {
                FiltrarPapeleta(txtBuscar.Text);
            }
            else if(UsuarioModel.id_rol==2)
            {
                FiltrarPapeletaUsuario(txtBuscar.Text);
            }
           
        }

        private void dataGridViewPapeleta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //foreach (DataGridViewColumn column in dataGridViewPapeleta.Columns)
            //{

            //    if (column[e.ColumnIndex])
            //    {
            //        dataGridViewPapeleta.DefaultCellStyle.BackColor = Color.Yellow;
            //    }
            //    else
            //        dataGridViewPapeleta.DefaultCellStyle.BackColor = Color.White;
            //}



            //if (this.dataGridViewPapeleta.Columns[e.ColumnIndex].Name == "id")
            //{
            //    //int id_solicitud = Convert.ToInt32(this.dataGridViewPapeleta.Rows[e.RowIndex].Cells[1].Value);
            //    if (Convert.ToInt32(e.Value) == 1)
            //    {
            //        dataGridViewPapeleta.BackColor = Color.Yellow;
            //        //e.CellStyle.BackColor = Color.Yellow;
            //    }

            //}









        }

        private void frmPapeleta_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewPapeleta_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
        }

        public void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewPapeleta.Rows)
            {

                int id_solicitud = Convert.ToInt32(row.Cells[21].Value);

                if (id_solicitud == 2)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }


            }
        }

       
    }
}
