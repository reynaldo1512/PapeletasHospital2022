using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;
namespace CapaDatos
{
    public class TrabajadorDao
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public DataTable ListarTrabajador()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TRABAJADORES_ADMINISTRADOR", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            connection.Open();
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            connection.Close();

            return tabla;
        }
        
        public DataTable BuscarTrabajador(TrabajadorModel trabajador)
        {
            DataTable tabla = new DataTable();
            
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_TRABAJADOR_ADMINISTRADOR", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@filtro",trabajador.primer_nombre);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            connection.Close();
            return tabla;

        }
        
        public void AgregarTrabajador(TrabajadorModel trabajador)
        {
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_TRABAJADOR", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@DNI",trabajador.DNI);
            cmd.Parameters.AddWithValue("@primer_nombre",trabajador.primer_nombre);
            cmd.Parameters.AddWithValue("@segundo_nombre",trabajador.segundo_nombre);
            cmd.Parameters.AddWithValue("@apellido_paterno",trabajador.apellido_paterno);
            cmd.Parameters.AddWithValue("@apellido_materno",trabajador.apellido_materno);
            cmd.Parameters.AddWithValue("@plaza",trabajador.plaza);
            cmd.Parameters.AddWithValue("@estado",trabajador.estado);
            cmd.Parameters.AddWithValue("@remuneracion", trabajador.remuneracion);
            cmd.Parameters.AddWithValue("@nivel", trabajador.nivel);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", trabajador.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@id_cargo", trabajador.id_cargo);
            cmd.Parameters.AddWithValue("@id_categoria", trabajador.id_categoria);
            cmd.Parameters.AddWithValue("@id_personal", trabajador.id_personal);
            cmd.Parameters.AddWithValue("@id_departamento", trabajador.id_departamento);
            cmd.Parameters.AddWithValue("@F_Ingreso",trabajador.F_Ingreso);
            cmd.Parameters.AddWithValue("@id_horario", trabajador.id_horario);
            cmd.ExecuteNonQuery();
            connection.Close();
          
        }
        public void EditarTrabajador(TrabajadorModel trabajador)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_TRABAJADOR", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("id_trabajador", trabajador.id_trabajador);
            cmd.Parameters.AddWithValue("@DNI", trabajador.DNI);
            cmd.Parameters.AddWithValue("@primer_nombre", trabajador.primer_nombre);
            cmd.Parameters.AddWithValue("@segundo_nombre", trabajador.segundo_nombre);
            cmd.Parameters.AddWithValue("@apellido_paterno", trabajador.apellido_paterno);
            cmd.Parameters.AddWithValue("@apellido_materno", trabajador.apellido_materno);
            cmd.Parameters.AddWithValue("@plaza", trabajador.plaza);
            cmd.Parameters.AddWithValue("@estado", trabajador.estado);
            cmd.Parameters.AddWithValue("@remuneracion", trabajador.remuneracion);
            cmd.Parameters.AddWithValue("@nivel", trabajador.nivel);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", trabajador.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@id_cargo", trabajador.id_cargo);
            cmd.Parameters.AddWithValue("@id_categoria", trabajador.id_categoria);
            cmd.Parameters.AddWithValue("@id_personal", trabajador.id_personal);
            cmd.Parameters.AddWithValue("@id_departamento", trabajador.id_departamento);
            cmd.Parameters.AddWithValue("@F_Ingreso", trabajador.F_Ingreso);
            cmd.Parameters.AddWithValue("@id_horario", trabajador.id_horario);
            cmd.ExecuteNonQuery();
            connection.Close();

        }
           

        
    }
}
