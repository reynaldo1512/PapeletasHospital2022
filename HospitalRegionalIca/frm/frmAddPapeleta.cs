using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using CapaNegocios;


namespace HospitalRegionalIca.frm
{
    public partial class frmAddPapeleta : Form
    {
        frmMenuPrincipal frm = new frmMenuPrincipal();
        PapeletaModel papeletaModel = new PapeletaModel();
        PapeletaNegocio papeletaNegocio = new PapeletaNegocio();
        TrabajadorModel trabajadorModel = new TrabajadorModel();
        TrabajadorNegocio trabajadorNegocio = new TrabajadorNegocio();


        public new bool Update = false;
        string codigo_papeleta;
        
        private void validar_textbox(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control is TextBox & control.Text==string.Empty)
                {
                    MessageBox.Show("Porfavor Llenar todos los campos");

                }

            }
        }




        public frmAddPapeleta()
        {
            InitializeComponent();

            ListarTrabajadores();


            //CargarDatos();
            ListarMotivo();
            ListarTurno();

            IdMaximo();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
            



        public static class AutoCompleClass
        {


  
            public static DataTable Trabajador()
            {
                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                string sqlquery = "SELECT id_trabajador,primer_nombre+' '+segundo_nombre+' '+ apellido_paterno+' '+apellido_materno as Nombres_Apellidos FROM Trabajador";
                SqlCommand cmd = new SqlCommand(sqlquery, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;

            }
            public static AutoCompleteStringCollection Autocomplete()
            {
                DataTable dt = Trabajador();
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                foreach (DataRow row in dt.Rows)
                {

                    coleccion.Add(Convert.ToString(row["Nombres_Apellidos"]));




                }
                return coleccion;
            }

        }
        public bool IdMaximo()
        {
           
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT MAX(id_papeleta) AS id_maximo FROM Papeleta", connection);
            cmd.CommandType = CommandType.Text;
            connection.Open();
           
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblIdMaximo.Text =Convert.ToString(dr.GetInt32(0));
                }
            }
            
            connection.Close();
            return true;

        }
        public void ListarMotivo()
        {
            MotivoNegocios motivoNegocios = new MotivoNegocios();
            cmbMotivo.DataSource = motivoNegocios.ListandoMotivo("");
            cmbMotivo.ValueMember = "id_motivo";
            cmbMotivo.DisplayMember = "descripcion";
        }

        public void ListarTurno()
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            cmbTurno.DataSource = turnoNegocio.ListandoTurno("");
            cmbTurno.ValueMember = "id_turno";
            cmbTurno.DisplayMember = "descripcion"; 


        }


        public void ListarTrabajadores()
        {

            //comboBox1.DataSource = AutoCompleClass.Trabajador();
            //comboBox1.DisplayMember = "Nombres_Apellidos";

            //comboBox1.ValueMember = "id_trabajador";

            ////carga la lista de items para el autocomplete del combobox 
            //comboBox1.AutoCompleteCustomSource = AutoCompleClass.Autocomplete();
            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            txtnombre.AutoCompleteCustomSource = AutoCompleClass.Autocomplete();
            txtnombre.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtnombre.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }

        private void frmAddPapeleta_Load(object sender, EventArgs e)
        {
            if (rbtnDia.Checked)
            {
                gpHora.Enabled = false;
                gpDia.Enabled = true;
            }
            else if (rbtnHora.Checked)
            {
                gpHora.Enabled = true;
                gpDia.Enabled = false;
            }


            txtDNI.Enabled = false;
            txtCargo.Enabled = false;
            txtPersonal.Enabled = false;
            txtCategoria.Enabled = false;


            if (UsuarioModel.id_rol==2)
            {
                btnCalcular.Enabled = false;
                btnCalcular.Visible = false;
                txtDescuento.Enabled = false;
                txtDescuento.Visible = false;
                lblDescuento.Visible = false;
            }

           



        }

        public void CargarDatos()
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        

        private void rbtnDia_CheckedChanged(object sender, EventArgs e)
        {
            gpHora.Enabled = false;
            gpDia.Enabled =true;
           
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {



        }

        private void rbtnHora_CheckedChanged(object sender, EventArgs e)
        {
            gpHora.Enabled = true;
            
            
            gpDia.Enabled = false;
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            
            if (txtnombre.Text=="")
            {
                txtDNI.Text = "";
                txtPersonal.Text = "";
                txtCargo.Text = "";
                txtCategoria.Text = "";

            }
            else
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SP_LLENAR_TEXTBOX_PAPELETAS2", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@descripcion", Convert.ToString(txtnombre.Text));
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    
                    lblIdTrabajador.Text=sdr["id_trabajador"].ToString();
                    lblIdCategoria.Text = sdr["id_categoria"].ToString();
                    txtDNI.Text = sdr["DNI"].ToString();
                    txtPersonal.Text = sdr["Personal"].ToString();
                    txtCargo.Text = sdr["Cargo"].ToString();
                    txtCategoria.Text = sdr["Categoria"].ToString();
                    lblRemuneracion.Text= sdr["remuneracion"].ToString();
                    lblIdDepTrabajador.Text = sdr["id_departamento"].ToString();
                    
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public bool validarTextBoxs(Form formulario)
        {
            foreach (Control item in Controls)
            {
                try
                {
                    if (item is TextBox)
                    {
                        //Codigo comprobacion  de textbox
                        if (item.Text == "")
                        {
                            MessageBox.Show("Hay campos vacios");
                            item.Focus();
                            return false;
                        }
                    }
                    
                    else if (item is ComboBox)
                    {
                        if (item.Text == "")
                        {
                            MessageBox.Show("Debes seleccionar un item");
                            item.Focus();
                            return false;
                        }
                    }
                }
                catch { }
            }
            return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (UsuarioModel.id_rol==1)
            {
  
                
                    int id_papeleta = papeletaModel.id_papeleta;

                    if (Update == false)

                    {
                        int id_maximo = 1 + Convert.ToInt32(lblIdMaximo.Text);

                        try
                        {
                            if (rbtnDia.Checked)
                            {

                                int idTipoPapeleta = 1;
                                papeletaModel.id_tipoPapeleta = idTipoPapeleta;
                                papeletaModel.id_trabajador = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_motivo = Convert.ToInt32(cmbMotivo.SelectedValue);
                                papeletaModel.turno = "";
                                papeletaModel.id_usuario = UsuarioModel.id_usuario;
                                codigo_papeleta = DateTime.Now.Year + "-" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "D" + id_maximo;
                                papeletaModel.numero_documento = codigo_papeleta;
                                papeletaModel.fecha_inicio = dtpFechaInicial.Value.Date;
                                //DateTime fechaInicio = dtpFechaInicial.Value.Date;
                                papeletaModel.fecha_fin = dtpFechaFinal.Value.Date;
                                //DateTime fechaFin = dtpFechaFinal.Value.Date;
                                papeletaModel.hora_inicio = 0;
                                papeletaModel.minuto_inicio = 0;
                                papeletaModel.hora_fin = 0;
                                papeletaModel.minuto_fin = 0;
                                //TimeSpan timeSpan = fechaFin - fechaInicio;
                                //int dias = timeSpan.Days;
                                //decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                                //papeletaModel.remuneracion_dia = remuneracionDia;
                                //decimal remuneracionHora = (remuneracionDia) / 8;
                                //decimal remuneracionMinuto = remuneracionHora / 60;
                                //papeletaModel.remuneracion_minuto = remuneracionMinuto;
                                //papeletaModel.descuento = dias * remuneracionDia;
                                papeletaModel.sustento = txtSustento.Text;
                                papeletaModel.fecha_registro = dtpFechaRegistro.Value.Date;
                                papeletaModel.estado = true;
                                papeletaModel.id_turno = Convert.ToInt32(cmbTurno.SelectedValue);
                                papeletaModel.id_solicitud = 1;
                                papeletaNegocio.AgregarPapeleta(papeletaModel);
                                MessageBox.Show("Se guardo la papeleta Correctamente");
                                Close();


                            }
                            else if (rbtnHora.Checked)
                            {
                                papeletaModel.id_tipoPapeleta = 2;
                                int id = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_trabajador = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_motivo = Convert.ToInt32(cmbMotivo.SelectedValue);
                                papeletaModel.turno = "";
                                papeletaModel.id_usuario = UsuarioModel.id_usuario;
                                codigo_papeleta = DateTime.Now.Year + "-" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "H" + id_maximo;
                                papeletaModel.numero_documento = codigo_papeleta;
                                papeletaModel.fecha_inicio = dtpFechaPermiso.Value.Date;
                                papeletaModel.fecha_fin = dtpFechaPermiso.Value.Date;
                                papeletaModel.hora_inicio = Convert.ToInt32(txtHoraInicio.Text);
                                papeletaModel.minuto_inicio = Convert.ToInt32(txtMinInicio.Text);
                                papeletaModel.hora_fin = Convert.ToInt32(txtHoraFin.Text);
                                papeletaModel.minuto_fin = Convert.ToInt32(txtMinFin.Text);
                                //decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                                //papeletaModel.remuneracion_dia = remuneracionDia;
                                //decimal remuneracionHora = (remuneracionDia) / 8;
                                //decimal remuneracion_hora = remuneracionHora;
                                //decimal remuneracionMinuto = remuneracionHora / 60;
                                //papeletaModel.remuneracion_minuto = remuneracionMinuto;

                                //int hora_Inicio_enMin = (Convert.ToInt32(txtHoraInicio.Text) * 60) + Convert.ToInt32(txtMinInicio.Text);
                                //int hora_Fin_enMin = (Convert.ToInt32(txtHoraFin.Text) * 60) + Convert.ToInt32(txtMinFin.Text);
                                //papeletaModel.descuento = (hora_Fin_enMin - hora_Inicio_enMin) * remuneracionMinuto;
                                papeletaModel.sustento = txtSustento.Text;
                                papeletaModel.fecha_registro = dtpFechaRegistro.Value.Date;
                                papeletaModel.estado = true;
                                papeletaModel.id_turno = Convert.ToInt32(cmbTurno.SelectedValue);
                                papeletaModel.id_solicitud = 1;

                                papeletaNegocio.AgregarPapeleta(papeletaModel);


                                MessageBox.Show("Se guardo la papeleta Correctamente");
                                Close();


                            }
                            else
                                MessageBox.Show("No se puedo guardar la papeleta");





                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("no se pudo guardar la papeleta" + ex);
                        }

                    }
                    if (Update == true)
                    {
                        int id_maximo = 1 + Convert.ToInt32(lblIdMaximo.Text);

                        try
                        {
                            if (rbtnDia.Checked)
                            {
                                papeletaModel.id_papeleta = Convert.ToInt32(txtIdPapeleta.Text);
                                int idTipoPapeleta = 1;
                                papeletaModel.id_tipoPapeleta = idTipoPapeleta;
                                papeletaModel.id_trabajador = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_motivo = Convert.ToInt32(cmbMotivo.SelectedValue);
                                papeletaModel.turno = "";
                                papeletaModel.id_usuario = UsuarioModel.id_usuario;
                                codigo_papeleta = DateTime.Now.Year + "-" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "D" + id_maximo;
                                papeletaModel.numero_documento = codigo_papeleta;
                                papeletaModel.fecha_inicio = dtpFechaInicial.Value.Date;
                                //DateTime fechaInicio = dtpFechaInicial.Value.Date;
                                papeletaModel.fecha_fin = dtpFechaFinal.Value.Date;
                                //DateTime fechaFin = dtpFechaFinal.Value.Date;
                                papeletaModel.hora_inicio = 0;
                                papeletaModel.minuto_inicio = 0;
                                papeletaModel.hora_fin = 0;
                                papeletaModel.minuto_fin = 0;
                                papeletaModel.remuneracion_dia = Convert.ToDecimal(lblRDia.Text);
                                papeletaModel.remuneracion_minuto = Convert.ToDecimal(lblRmin.Text);
                                papeletaModel.descuento = Convert.ToDecimal(txtDescuento.Text);
                            //TimeSpan timeSpan = fechaFin - fechaInicio;
                            //int dias = timeSpan.Days;
                            //decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                            //papeletaModel.remuneracion_dia = remuneracionDia;
                            //decimal remuneracionHora = (remuneracionDia) / 8;
                            //decimal remuneracionMinuto = remuneracionHora / 60;
                            //papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            //papeletaModel.descuento = dias * remuneracionDia;
                                papeletaModel.sustento = txtSustento.Text;
                                papeletaModel.fecha_registro = dtpFechaRegistro.Value.Date;
                                papeletaModel.estado = true;
                                papeletaModel.id_turno = Convert.ToInt32(cmbTurno.SelectedValue);
                                papeletaModel.id_solicitud = 1;
                                papeletaNegocio.EditarPapeleta(papeletaModel);
                                MessageBox.Show("Se edito la papeleta Correctamente");
                                Close();


                            }
                            else if (rbtnHora.Checked)
                            {
                                papeletaModel.id_papeleta = Convert.ToInt32(txtIdPapeleta.Text);
                                papeletaModel.id_tipoPapeleta = 2;
                                int id = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_trabajador = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_motivo = Convert.ToInt32(cmbMotivo.SelectedValue);
                                papeletaModel.turno = "";
                                papeletaModel.id_usuario = UsuarioModel.id_usuario;
                                codigo_papeleta = DateTime.Now.Year + "-" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "H" + id_maximo;
                                papeletaModel.numero_documento = codigo_papeleta;
                                papeletaModel.fecha_inicio = dtpFechaPermiso.Value.Date;
                                papeletaModel.fecha_fin = dtpFechaPermiso.Value.Date;
                                papeletaModel.hora_inicio = Convert.ToInt32(txtHoraInicio.Text);
                                papeletaModel.minuto_inicio = Convert.ToInt32(txtMinInicio.Text);
                                papeletaModel.hora_fin = Convert.ToInt32(txtHoraFin.Text);
                                papeletaModel.minuto_fin = Convert.ToInt32(txtMinFin.Text);
                                papeletaModel.remuneracion_dia = Convert.ToDecimal(lblRDia.Text);
                                papeletaModel.remuneracion_minuto = Convert.ToDecimal(lblRmin.Text);
                                papeletaModel.descuento = Convert.ToDecimal(txtDescuento.Text);
                            //decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                            //papeletaModel.remuneracion_dia = remuneracionDia;
                            //decimal remuneracionHora = (remuneracionDia) / 8;
                            //decimal remuneracion_hora = remuneracionHora;
                            //decimal remuneracionMinuto = remuneracionHora / 60;
                            //papeletaModel.remuneracion_minuto = remuneracionMinuto;

                            //int hora_Inicio_enMin = (Convert.ToInt32(txtHoraInicio.Text) * 60) + Convert.ToInt32(txtMinInicio.Text);
                            //int hora_Fin_enMin = (Convert.ToInt32(txtHoraFin.Text) * 60) + Convert.ToInt32(txtMinFin.Text);
                            //papeletaModel.descuento = (hora_Fin_enMin - hora_Inicio_enMin) * remuneracionMinuto;
                            papeletaModel.sustento = txtSustento.Text;
                                papeletaModel.fecha_registro = dtpFechaRegistro.Value.Date;
                                papeletaModel.estado = true;
                                papeletaModel.id_turno = Convert.ToInt32(cmbTurno.SelectedValue);
                                papeletaModel.id_solicitud = 1;

                                papeletaNegocio.EditarPapeleta(papeletaModel);


                                MessageBox.Show("Se edito la papeleta Correctamente");
                                Close();
                                Update = false;


                            }
                            else
                                MessageBox.Show("No se pudo editar la papeleta");





                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("no se edito la papeleta" + ex);
                        }
                    }
                }

            
            else if (UsuarioModel.id_rol==2)
            {

                if (UsuarioModel.id_departamento==Convert.ToInt32(lblIdDepTrabajador.Text))
                {

                    int id_papeleta = papeletaModel.id_papeleta;

                    if (Update == false)

                    {
                        int id_maximo = 1 + Convert.ToInt32(lblIdMaximo.Text);

                        try
                        {
                            if (rbtnDia.Checked)
                            {

                                int idTipoPapeleta = 1;
                                papeletaModel.id_tipoPapeleta = idTipoPapeleta;
                                papeletaModel.id_trabajador = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_motivo = Convert.ToInt32(cmbMotivo.SelectedValue);
                                papeletaModel.turno = "";
                                papeletaModel.id_usuario = UsuarioModel.id_usuario;
                                codigo_papeleta = DateTime.Now.Year + "-" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "D" + id_maximo;
                                papeletaModel.numero_documento = codigo_papeleta;
                                papeletaModel.fecha_inicio = dtpFechaInicial.Value.Date;
                                //DateTime fechaInicio = dtpFechaInicial.Value.Date;
                                papeletaModel.fecha_fin = dtpFechaFinal.Value.Date;
                                //DateTime fechaFin = dtpFechaFinal.Value.Date;
                                papeletaModel.hora_inicio = 0;
                                papeletaModel.minuto_inicio = 0;
                                papeletaModel.hora_fin = 0;
                                papeletaModel.minuto_fin = 0;
                                papeletaModel.remuneracion_dia = 0;
                                papeletaModel.remuneracion_minuto = 0;
                                papeletaModel.descuento = 0;
                                //TimeSpan timeSpan = fechaFin - fechaInicio;
                                //int dias = timeSpan.Days;
                                //decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                                //papeletaModel.remuneracion_dia = remuneracionDia;
                                //decimal remuneracionHora = (remuneracionDia) / 8;
                                //decimal remuneracionMinuto = remuneracionHora / 60;
                                //papeletaModel.remuneracion_minuto = remuneracionMinuto;
                                //papeletaModel.descuento = dias * remuneracionDia;
                                papeletaModel.sustento = txtSustento.Text;
                                papeletaModel.fecha_registro = dtpFechaRegistro.Value.Date;
                                papeletaModel.estado = true;
                                papeletaModel.id_turno = Convert.ToInt32(cmbTurno.SelectedValue);
                                papeletaModel.id_solicitud = 2;
                                papeletaNegocio.AgregarPapeleta(papeletaModel);
                                MessageBox.Show("Se guardo la papeleta Correctamente");
                                Close();


                            }
                            else if (rbtnHora.Checked)
                            {
                                papeletaModel.id_tipoPapeleta = 2;
                                int id = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_trabajador = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_motivo = Convert.ToInt32(cmbMotivo.SelectedValue);
                                papeletaModel.turno = "";
                                papeletaModel.id_usuario = UsuarioModel.id_usuario;
                                codigo_papeleta = DateTime.Now.Year + "-" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "H" + id_maximo;
                                papeletaModel.numero_documento = codigo_papeleta;
                                papeletaModel.fecha_inicio = dtpFechaPermiso.Value.Date;
                                papeletaModel.fecha_fin = dtpFechaPermiso.Value.Date;
                                papeletaModel.hora_inicio = Convert.ToInt32(txtHoraInicio.Text);
                                papeletaModel.minuto_inicio = Convert.ToInt32(txtMinInicio.Text);
                                papeletaModel.hora_fin = Convert.ToInt32(txtHoraFin.Text);
                                papeletaModel.minuto_fin = Convert.ToInt32(txtMinFin.Text);
                                papeletaModel.remuneracion_dia = 0;
                                papeletaModel.remuneracion_minuto = 0;
                                papeletaModel.descuento = 0;
                                //decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                                //papeletaModel.remuneracion_dia = remuneracionDia;
                                //decimal remuneracionHora = (remuneracionDia) / 8;
                                //decimal remuneracion_hora = remuneracionHora;
                                //decimal remuneracionMinuto = remuneracionHora / 60;
                                //papeletaModel.remuneracion_minuto = remuneracionMinuto;

                                //int hora_Inicio_enMin = (Convert.ToInt32(txtHoraInicio.Text) * 60) + Convert.ToInt32(txtMinInicio.Text);
                                //int hora_Fin_enMin = (Convert.ToInt32(txtHoraFin.Text) * 60) + Convert.ToInt32(txtMinFin.Text);
                                //papeletaModel.descuento = (hora_Fin_enMin - hora_Inicio_enMin) * remuneracionMinuto;
                                papeletaModel.sustento = txtSustento.Text;
                                papeletaModel.fecha_registro = dtpFechaRegistro.Value.Date;
                                papeletaModel.estado = true;
                                papeletaModel.id_turno = Convert.ToInt32(cmbTurno.SelectedValue);
                                papeletaModel.id_solicitud = 2;

                                papeletaNegocio.AgregarPapeleta(papeletaModel);


                                MessageBox.Show("Se guardo la papeleta Correctamente");
                                Close();


                            }
                            else
                                MessageBox.Show("No se puedo guardar la papeleta");





                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("no se pudo guardar la papeleta" + ex);
                        }

                    }
                    if (Update == true)
                    {
                        int id_maximo = 1 + Convert.ToInt32(lblIdMaximo.Text);

                        try
                        {
                            if (rbtnDia.Checked)
                            {
                                papeletaModel.id_papeleta = Convert.ToInt32(txtIdPapeleta.Text);
                                int idTipoPapeleta = 1;
                                papeletaModel.id_tipoPapeleta = idTipoPapeleta;
                                papeletaModel.id_trabajador = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_motivo = Convert.ToInt32(cmbMotivo.SelectedValue);
                                papeletaModel.turno = "";
                                papeletaModel.id_usuario = UsuarioModel.id_usuario;
                                codigo_papeleta = DateTime.Now.Year + "-" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "D" + id_maximo;
                                papeletaModel.numero_documento = codigo_papeleta;
                                papeletaModel.fecha_inicio = dtpFechaInicial.Value.Date;
                                //DateTime fechaInicio = dtpFechaInicial.Value.Date;
                                papeletaModel.fecha_fin = dtpFechaFinal.Value.Date;
                                //DateTime fechaFin = dtpFechaFinal.Value.Date;
                                papeletaModel.hora_inicio = 0;
                                papeletaModel.minuto_inicio = 0;
                                papeletaModel.hora_fin = 0;
                                papeletaModel.minuto_fin = 0;
                                papeletaModel.remuneracion_dia = Convert.ToDecimal(lblRDia.Text);
                                papeletaModel.remuneracion_minuto = Convert.ToDecimal(lblRmin.Text);
                                papeletaModel.descuento = Convert.ToDecimal(txtDescuento.Text);


                                //TimeSpan timeSpan = fechaFin - fechaInicio;
                                //int dias = timeSpan.Days;
                                //decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                                //papeletaModel.remuneracion_dia = remuneracionDia;
                                //decimal remuneracionHora = (remuneracionDia) / 8;
                                //decimal remuneracionMinuto = remuneracionHora / 60;
                                //papeletaModel.remuneracion_minuto = remuneracionMinuto;
                                //papeletaModel.descuento = dias * remuneracionDia;
                                papeletaModel.sustento = txtSustento.Text;
                                papeletaModel.fecha_registro = dtpFechaRegistro.Value.Date;
                                papeletaModel.estado = true;
                                papeletaModel.id_turno = Convert.ToInt32(cmbTurno.SelectedValue);
                                papeletaModel.id_solicitud = Convert.ToInt32(lblIdSolicitud.Text);
                                papeletaNegocio.EditarPapeleta(papeletaModel);
                                MessageBox.Show("Se edito la papeleta Correctamente");
                                Close();


                            }
                            else if (rbtnHora.Checked)
                            {
                                papeletaModel.id_papeleta = Convert.ToInt32(txtIdPapeleta.Text);
                                papeletaModel.id_tipoPapeleta = 2;
                                int id = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_trabajador = Convert.ToInt32(lblIdTrabajador.Text);
                                papeletaModel.id_motivo = Convert.ToInt32(cmbMotivo.SelectedValue);
                                papeletaModel.turno = "";
                                papeletaModel.id_usuario = UsuarioModel.id_usuario;
                                codigo_papeleta = DateTime.Now.Year + "-" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "H" + id_maximo;
                                papeletaModel.numero_documento = codigo_papeleta;
                                papeletaModel.fecha_inicio = dtpFechaPermiso.Value.Date;
                                papeletaModel.fecha_fin = dtpFechaPermiso.Value.Date;
                                papeletaModel.hora_inicio = Convert.ToInt32(txtHoraInicio.Text);
                                papeletaModel.minuto_inicio = Convert.ToInt32(txtMinInicio.Text);
                                papeletaModel.hora_fin = Convert.ToInt32(txtHoraFin.Text);
                                papeletaModel.minuto_fin = Convert.ToInt32(txtMinFin.Text);
                                papeletaModel.remuneracion_dia = Convert.ToDecimal(lblRDia.Text);
                                papeletaModel.remuneracion_minuto = Convert.ToDecimal(lblRmin.Text);
                                papeletaModel.descuento = Convert.ToDecimal(txtDescuento.Text);
                                //decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                                //papeletaModel.remuneracion_dia = remuneracionDia;
                                //decimal remuneracionHora = (remuneracionDia) / 8;
                                //decimal remuneracion_hora = remuneracionHora;
                                //decimal remuneracionMinuto = remuneracionHora / 60;
                                //papeletaModel.remuneracion_minuto = remuneracionMinuto;

                                //int hora_Inicio_enMin = (Convert.ToInt32(txtHoraInicio.Text) * 60) + Convert.ToInt32(txtMinInicio.Text);
                                //int hora_Fin_enMin = (Convert.ToInt32(txtHoraFin.Text) * 60) + Convert.ToInt32(txtMinFin.Text);
                                //papeletaModel.descuento = (hora_Fin_enMin - hora_Inicio_enMin) * remuneracionMinuto;
                                papeletaModel.sustento = txtSustento.Text;
                                papeletaModel.fecha_registro = dtpFechaRegistro.Value.Date;
                                papeletaModel.estado = true;
                                papeletaModel.id_turno = Convert.ToInt32(cmbTurno.SelectedValue);
                                papeletaModel.id_solicitud = Convert.ToInt32(lblIdSolicitud.Text);

                                papeletaNegocio.EditarPapeleta(papeletaModel);


                                MessageBox.Show("Se edito la papeleta Correctamente");
                                Close();
                                Update = false;


                            }
                            else
                                MessageBox.Show("No se pudo editar la papeleta");





                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("no se edito la papeleta" + ex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El trabajador Seleccionado no pertenece a su departamento");
                }
               
                }



            

        }

            
        
            
            

        private void btnCalcular_Click(object sender, EventArgs e)
        {


            //if (txtHoraInicio.Text!="" && txtMinInicio.Text!="" && txtHoraFin.Text!="" && txtMinFin.Text!="")
            //{

            //}


            //CALCULAR PARA EL ROL ADMINISTRADOR 


            if (UsuarioModel.id_rol==1)
            {

                if (lblRemuneracion.Text == "Remuneracion")
                {
                    MessageBox.Show("Ingrese Trabajador");
                }
                else if (gpDia.Enabled == true)

                {

                    if (Convert.ToInt32(lblIdCategoria.Text) == 3)
                    {
                        if ((Convert.ToInt32(cmbTurno.SelectedValue) == 5))
                            
                        {
                            DateTime fechaInicio = dtpFechaInicial.Value.Date;
                            DateTime fechaFin = dtpFechaFinal.Value.Date;
                            TimeSpan timeSpan = fechaFin - fechaInicio;
                            int dias = timeSpan.Days;
                            decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                            papeletaModel.remuneracion_dia = remuneracionDia;
                            decimal remuneracionHora = (remuneracionDia) / 8;
                            decimal remuneracionMinuto = remuneracionHora / 60;
                            lblRDia.Text = remuneracionDia.ToString();
                            lblRmin.Text = remuneracionMinuto.ToString();
                            papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            decimal descuento = dias * remuneracionDia;
                            descuento = decimal.Round(descuento, 2);
                            txtDescuento.Text = (descuento).ToString();
                            papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            papeletaModel.descuento = descuento;
                        }
                        else
                        {
                            MessageBox.Show("Turno incorrecto para su categoria");
                        }
                       

                    }
                    else
                    {
                        if (Convert.ToInt32(cmbTurno.SelectedValue)==1)
                        {
                            DateTime fechaInicio = dtpFechaInicial.Value.Date;
                            DateTime fechaFin = dtpFechaFinal.Value.Date;
                            TimeSpan timeSpan = fechaFin - fechaInicio;
                            int dias = timeSpan.Days;

                            decimal remuneracioHora = Convert.ToDecimal(lblRemuneracion.Text) / 150;
                            decimal remuneracionMinuto = remuneracioHora / 60;
                            decimal remuneracionDia = 12 * (remuneracioHora);
                            lblRDia.Text = remuneracionDia.ToString();
                            lblRmin.Text = remuneracionMinuto.ToString();
                            papeletaModel.remuneracion_dia = remuneracionDia;
                            papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            decimal descuento = dias * remuneracionDia;
                            descuento = decimal.Round(descuento, 2);
                            txtDescuento.Text = (descuento).ToString();
                            papeletaModel.descuento = descuento;

                            //DateTime fechaInicio = dtpFechaInicial.Value.Date;
                            //DateTime fechaFin = dtpFechaFinal.Value.Date;
                            //TimeSpan timeSpan = fechaFin - fechaInicio;
                            //int dias = timeSpan.Days;
                            //decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                            //papeletaModel.remuneracion_dia = remuneracionDia;
                            //decimal remuneracionHora = (remuneracionDia) / 6;
                            //decimal remuneracionMinuto = remuneracionHora / 60;
                            //lblRDia.Text = remuneracionDia.ToString();
                            //lblRmin.Text = remuneracionMinuto.ToString();
                            //papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            //decimal descuento = dias * remuneracionDia;
                            //descuento = decimal.Round(descuento, 2);
                            //txtDescuento.Text = (descuento).ToString();
                            //papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            //papeletaModel.descuento = descuento;
                        }
                        else if (Convert.ToInt32(cmbTurno.SelectedValue) == 2)
                        {
                            DateTime fechaInicio = dtpFechaInicial.Value.Date;
                            DateTime fechaFin = dtpFechaFinal.Value.Date;
                            TimeSpan timeSpan = fechaFin - fechaInicio;
                            int dias = timeSpan.Days;

                            decimal remuneracioHora = Convert.ToDecimal(lblRemuneracion.Text) / 150;
                            decimal remuneracionMinuto = remuneracioHora / 60;
                            decimal remuneracionDia = 12 * (remuneracioHora);
                            lblRDia.Text = remuneracionDia.ToString();
                            lblRmin.Text = remuneracionMinuto.ToString();
                            papeletaModel.remuneracion_dia = remuneracionDia;
                            papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            decimal descuento = dias * remuneracionDia;
                            descuento = decimal.Round(descuento, 2);
                            txtDescuento.Text = (descuento).ToString();
                            papeletaModel.descuento = descuento;

                        }
                        else if (Convert.ToInt32(cmbTurno.SelectedValue) == 3)
                        {
                            DateTime fechaInicio = dtpFechaInicial.Value.Date;
                            DateTime fechaFin = dtpFechaFinal.Value.Date;
                            TimeSpan timeSpan = fechaFin - fechaInicio;
                            int dias = timeSpan.Days;

                            decimal remuneracioHora = Convert.ToDecimal(lblRemuneracion.Text) / 150;
                            decimal remuneracionMinuto = remuneracioHora / 60;
                            decimal remuneracionDia = 6 * (remuneracioHora);
                            lblRDia.Text = remuneracionDia.ToString();
                            lblRmin.Text = remuneracionMinuto.ToString();
                            papeletaModel.remuneracion_dia = remuneracionDia;
                            papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            decimal descuento = dias * remuneracionDia;
                            descuento = decimal.Round(descuento, 2);
                            txtDescuento.Text = (descuento).ToString();
                            papeletaModel.descuento = descuento;
                        }
                        else if (Convert.ToInt32(cmbTurno.SelectedValue) == 4)
                        {
                            DateTime fechaInicio = dtpFechaInicial.Value.Date;
                            DateTime fechaFin = dtpFechaFinal.Value.Date;
                            TimeSpan timeSpan = fechaFin - fechaInicio;
                            int dias = timeSpan.Days;

                            decimal remuneracioHora = Convert.ToDecimal(lblRemuneracion.Text) / 150;
                            decimal remuneracionMinuto = remuneracioHora / 60;
                            decimal remuneracionDia = 6 * (remuneracioHora);
                            lblRDia.Text = remuneracionDia.ToString();
                            lblRmin.Text = remuneracionMinuto.ToString();
                            papeletaModel.remuneracion_dia = remuneracionDia;
                            papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            decimal descuento = dias * remuneracionDia;
                            descuento = decimal.Round(descuento, 2);
                            txtDescuento.Text = (descuento).ToString();
                            papeletaModel.descuento = descuento;
                        }

                        
                        else
                        {
                            MessageBox.Show("Turno incorrecto para su categoria");
                        }

                       
                    }



                }
                else if (gpHora.Enabled == true)
                {
                    if (txtHoraInicio.Text != "" && txtMinInicio.Text != "" && txtHoraFin.Text != "" && txtMinFin.Text != "")
                    {
                        if (Convert.ToInt32(lblIdCategoria.Text) == 3)
                        {
                            decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                            papeletaModel.remuneracion_dia = remuneracionDia;
                            decimal remuneracionHora = (remuneracionDia) / 8;
                            //decimal remuneracion_hora = remuneracionHora;
                            decimal remuneracionMinuto = remuneracionHora / 60;
                            lblRDia.Text = remuneracionDia.ToString();
                            lblRmin.Text = remuneracionMinuto.ToString();
                            papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            int hora_Inicio_enMin = (Convert.ToInt32(txtHoraInicio.Text) * 60) + Convert.ToInt32(txtMinInicio.Text);
                            int hora_Fin_enMin = (Convert.ToInt32(txtHoraFin.Text) * 60) + Convert.ToInt32(txtMinFin.Text);
                            decimal descuento = (hora_Fin_enMin - hora_Inicio_enMin) * remuneracionMinuto;
                            descuento = decimal.Round(descuento, 2);
                            txtDescuento.Text = (descuento).ToString();
                            papeletaModel.descuento = descuento;
                        }
                        else
                        {


                            decimal remuneracionDia = Convert.ToDecimal(lblRemuneracion.Text) / 30;
                            papeletaModel.remuneracion_dia = remuneracionDia;
                            decimal remuneracionHora = (remuneracionDia) / 6;
                            //decimal remuneracion_hora = remuneracionHora;
                            decimal remuneracionMinuto = remuneracionHora / 60;
                            lblRDia.Text = remuneracionDia.ToString();
                            lblRmin.Text = remuneracionMinuto.ToString();
                            papeletaModel.remuneracion_minuto = remuneracionMinuto;
                            int hora_Inicio_enMin = (Convert.ToInt32(txtHoraInicio.Text) * 60) + Convert.ToInt32(txtMinInicio.Text);
                            int hora_Fin_enMin = (Convert.ToInt32(txtHoraFin.Text) * 60) + Convert.ToInt32(txtMinFin.Text);
                            decimal descuento = (hora_Fin_enMin - hora_Inicio_enMin) * remuneracionMinuto;
                            descuento = decimal.Round(descuento, 2);
                            txtDescuento.Text = (descuento).ToString();
                            papeletaModel.descuento = descuento;
                        }



                    }
                    else MessageBox.Show("campos incompletos");
                }



                else
                {
                    MessageBox.Show("Campos Incompletos");
                }

            }

            //CALCULAR PARA EL ROL USUARIO 
            //else if (UsuarioModel.id_rol == 2)
            //{
            //    if (lblRemuneracion.Text == "Remuneracion")
            //    {
            //        MessageBox.Show("Ingrese Trabajador");
            //    }
            //    else if (gpDia.Enabled == true)
            //    {
            //        if (Convert.ToInt32(lblIdCategoria.Text) == 3)
            //        {
            //            //papeletaModel.remuneracion_dia = ;
            //            //papeletaModel.remuneracion_minuto = ;
            //            //papeletaModel.descuento = ;


            //        }
            //        else
            //        {
                        
                        
            //        }



            //    }
            //    else if (gpHora.Enabled == true)
            //    {
            //        if (txtHoraInicio.Text != "" && txtMinInicio.Text != "" && txtHoraFin.Text != "" && txtMinFin.Text != "")
            //        {
            //            if (Convert.ToInt32(lblIdCategoria.Text) == 3)
            //            {
                            
            //            }
            //            else
            //            {

            //            }



            //        }
            //        else MessageBox.Show("campos incompletos");
            //    }



            //    else
            //    {
            //        MessageBox.Show("Campos Incompletos");
            //    }


            //}



        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIdTrabajador_Click(object sender, EventArgs e)
        {

        }
    }
}
