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
    public class MotivoDao
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public List<MotivoModel> ListarMotivo(string descripcion)
        {
            SqlDataReader leer; 
            SqlCommand cmd = new SqlCommand("SP_LISTAR_MOTIVO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            leer = cmd.ExecuteReader();
            List<MotivoModel> ListandoMotivo = new List<MotivoModel>();
            while (leer.Read())
            {
                ListandoMotivo.Add(new MotivoModel
                {
                    id_motivo = leer.GetInt32(0),
                    descripcion = leer.GetString(1)
                });
            }

            connection.Close();
            leer.Close();
            return ListandoMotivo;
        }   
    }
}
