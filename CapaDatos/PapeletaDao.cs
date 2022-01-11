using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class PapeletaDao
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public DataTable ListarPapeleta()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_PAPELETA_ADMINISTRADOR", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            connection.Open();
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            connection.Close();
            return tabla;
        }

        public DataTable ListarPapeletaUsuario(int id_departamento)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_PAPELETA_USUARIO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_departamento",id_departamento);
            connection.Open();
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            connection.Close();
            return tabla;

        }

        public DataTable BuscarPapeleta(string filtro)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
           
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_PAPELETA_ADMINISTRADOR", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@filtro", filtro);
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            connection.Close();
            return tabla;
        }
        public DataTable BuscarPapeletaUsuario(string filtro, int id_departamento)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;

            SqlCommand cmd = new SqlCommand("SP_BUSCAR_PAPELETA_USUARIO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@filtro", filtro);
            cmd.Parameters.AddWithValue("@id_departamento", id_departamento);

            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            connection.Close();
            return tabla;
        }


        public void AgregarPapeleta(PapeletaModel papeleta)
        {
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_PAPELETA2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@id_tipoPapeleta",papeleta.id_tipoPapeleta);
            cmd.Parameters.AddWithValue("@id_trabajador",papeleta.id_trabajador);
            cmd.Parameters.AddWithValue("@id_motivo",papeleta.id_motivo);
            cmd.Parameters.AddWithValue("@turno",papeleta.turno);
            cmd.Parameters.AddWithValue("@id_usuario",papeleta.id_usuario);
            cmd.Parameters.AddWithValue("@numero_documento",papeleta.numero_documento );
            cmd.Parameters.AddWithValue("@fecha_inicio",papeleta.fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin",papeleta.fecha_fin);
            cmd.Parameters.AddWithValue("@hora_inicio",papeleta.hora_inicio);
            cmd.Parameters.AddWithValue("@minuto_inicio",papeleta.minuto_inicio);
            cmd.Parameters.AddWithValue("@hora_fin",papeleta.hora_fin);
            cmd.Parameters.AddWithValue("@minuto_fin",papeleta.minuto_fin);
            cmd.Parameters.AddWithValue("@remuneracion_dia",papeleta.remuneracion_dia);
            cmd.Parameters.AddWithValue("@remuneracion_minuto",papeleta.remuneracion_minuto);
            cmd.Parameters.AddWithValue("@descuento",papeleta.descuento);
            cmd.Parameters.AddWithValue("@sustento",papeleta.sustento);
            cmd.Parameters.AddWithValue("@fecha_registro",papeleta.fecha_registro);
            cmd.Parameters.AddWithValue("@estado",papeleta.estado);
            cmd.Parameters.AddWithValue("@id_turno", papeleta.id_turno);
            cmd.Parameters.AddWithValue("@id_solicitud", papeleta.id_solicitud);
            cmd.ExecuteNonQuery();
            connection.Close();
            
        }


        public void EditarPapeleta(PapeletaModel papeleta)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_PAPELETA ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@id_papeleta", papeleta.id_papeleta);
            cmd.Parameters.AddWithValue("@id_tipoPapeleta", papeleta.id_tipoPapeleta);
            cmd.Parameters.AddWithValue("@id_trabajador", papeleta.id_trabajador);
            cmd.Parameters.AddWithValue("@id_motivo", papeleta.id_motivo);
            cmd.Parameters.AddWithValue("@turno", papeleta.turno);
            cmd.Parameters.AddWithValue("@id_usuario", papeleta.id_usuario);
            cmd.Parameters.AddWithValue("@numero_documento", papeleta.numero_documento);
            cmd.Parameters.AddWithValue("@fecha_inicio", papeleta.fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", papeleta.fecha_fin);
            cmd.Parameters.AddWithValue("@hora_inicio", papeleta.hora_inicio);
            cmd.Parameters.AddWithValue("@minuto_inicio", papeleta.minuto_inicio);
            cmd.Parameters.AddWithValue("@hora_fin", papeleta.hora_fin);
            cmd.Parameters.AddWithValue("@minuto_fin", papeleta.minuto_fin);
            cmd.Parameters.AddWithValue("@remuneracion_dia", papeleta.remuneracion_dia);
            cmd.Parameters.AddWithValue("@remuneracion_minuto", papeleta.remuneracion_minuto);
            cmd.Parameters.AddWithValue("@descuento", papeleta.descuento);
            cmd.Parameters.AddWithValue("@sustento", papeleta.sustento);
            cmd.Parameters.AddWithValue("@fecha_registro", papeleta.fecha_registro);
            cmd.Parameters.AddWithValue("@estado", papeleta.estado);
            cmd.Parameters.AddWithValue("@id_turno", papeleta.id_turno);
            cmd.Parameters.AddWithValue("@id_solicitud", papeleta.id_solicitud);
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        

        public void EliminarPapeleta(int id_papeleta)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_PAPELETA", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@id_papeleta",id_papeleta);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        
    }
}
