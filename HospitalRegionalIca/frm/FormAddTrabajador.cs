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
    public partial class FormAddTrabajador : Form

    {
        frmMenuPrincipal frm = new frmMenuPrincipal();
        
        TrabajadorModel trabajadorModel = new TrabajadorModel();
        TrabajadorNegocio trabajadorNegocio = new TrabajadorNegocio();
      
        
       

        public new bool Update = false;
        
        public FormAddTrabajador()
        {
            InitializeComponent();
            ListarCargo();
            ListarCategoria();
            ListarPersonal();
            ListarDepartamento();
            ListarHorario();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAddTrabajador_Load(object sender, EventArgs e)
        {
            
           
        }
        
        
        public void ListarCargo()
        {
            CargoNegocio cargoNegocio = new CargoNegocio();
            cmbCargo.DataSource = cargoNegocio.ListandoCargo("");
            cmbCargo.ValueMember = "id_cargo";
            cmbCargo.DisplayMember = "descripcion";
           
           
           
        }
        public void ListarCategoria()
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            cmbCategoria.DataSource = categoriaNegocio.ListandoCategoria("");
            cmbCategoria.ValueMember = "id_categoria";
            cmbCategoria.DisplayMember = "descripcion";
        }
        public void ListarPersonal()
        {
            PersonalNegocio personalNegocio = new PersonalNegocio();
            cmbPersonal.DataSource = personalNegocio.ListandoPersonal("");
            cmbPersonal.ValueMember = "id_personal";
            cmbPersonal.DisplayMember="descripcion";

        }
        public void ListarDepartamento()
        {
            DepartamentoNegocio departamentoNegocio = new DepartamentoNegocio();
            cmbDepartamento.DataSource = departamentoNegocio.ListandoDepartamento("");
            cmbDepartamento.ValueMember = "id_departamento";
            cmbDepartamento.DisplayMember = "descripcion";        
        }
        public void ListarHorario()
        {
            HorarioNegocio horarioNegocio = new HorarioNegocio();
            cmbHorario.DataSource = horarioNegocio.ListandoHorario("");
            cmbHorario.ValueMember = "id_horario";
            cmbHorario.DisplayMember = "descripcion";
            
            
           
        }
        

        private void closeFormCategory_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Update==false)
            {
              
                    try
                {
                    if (UsuarioModel.id_departamento == Convert.ToInt32(cmbDepartamento.SelectedValue))
                    {
                        trabajadorModel.DNI = txtDNI.Text;
                        trabajadorModel.primer_nombre = txtPnombre.Text;
                        trabajadorModel.segundo_nombre = txtSnombre.Text;
                        trabajadorModel.apellido_paterno = txtPapellido.Text;
                        trabajadorModel.apellido_materno = txtSapellido.Text;
                        trabajadorModel.plaza = txtPlaza.Text;
                        trabajadorModel.estado = true;
                        trabajadorModel.remuneracion = Convert.ToDecimal(txtRemuneracion.Text);
                        trabajadorModel.nivel = txtNivel.Text;
                        trabajadorModel.fecha_nacimiento = dtpfechaNacimiento.Value.Date;
                        trabajadorModel.id_cargo = Convert.ToInt32(cmbCargo.SelectedValue);
                        trabajadorModel.id_categoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                        trabajadorModel.id_personal = Convert.ToInt32(cmbPersonal.SelectedValue);
                        trabajadorModel.id_departamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
                        trabajadorModel.F_Ingreso = dtpFechaIngreso.Value.Date;
                        trabajadorModel.id_horario = Convert.ToInt32(cmbHorario.SelectedValue);


                        trabajadorNegocio.AgregarTrabajador(trabajadorModel);
                        MessageBox.Show("se guardo el trabajador correctamente");
                        Close();
                    }
                    else MessageBox.Show("No se pudo guardar al trabajador , Departamento Erroneo");
                       


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("no se pudo guardar el trabajador" + ex);
                    }
                }

            
            if (Update==true)
            {
                

                try
                {
                    
                        trabajadorModel.id_trabajador = Convert.ToInt32(txtId.Text);
                        trabajadorModel.DNI = txtDNI.Text;
                        trabajadorModel.primer_nombre = txtPnombre.Text;
                        trabajadorModel.segundo_nombre = txtSnombre.Text;
                        trabajadorModel.apellido_paterno = txtPapellido.Text;
                        trabajadorModel.apellido_materno = txtSapellido.Text;
                        trabajadorModel.plaza = txtPlaza.Text;
                        trabajadorModel.estado = true;
                        trabajadorModel.remuneracion = Convert.ToDecimal(txtRemuneracion.Text);
                        trabajadorModel.nivel = txtNivel.Text;
                        trabajadorModel.fecha_nacimiento = dtpfechaNacimiento.Value.Date;
                        trabajadorModel.id_cargo = Convert.ToInt32(cmbCargo.SelectedValue);
                        trabajadorModel.id_categoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                        trabajadorModel.id_personal = Convert.ToInt32(cmbPersonal.SelectedValue);
                        trabajadorModel.id_departamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
                        trabajadorModel.F_Ingreso = dtpFechaIngreso.Value.Date;
                        trabajadorModel.id_horario = Convert.ToInt32(cmbHorario.SelectedValue);


                        trabajadorNegocio.EditarTrabajador(trabajadorModel);
                        MessageBox.Show("se edito correctamente el trabajador");
                        Close();
                        Update = false;
                    
                    
                   
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se puedo editar el trabajador"+ex);
                }




            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
