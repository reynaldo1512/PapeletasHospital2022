using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
   public class TurnoDao
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        public List<TurnoModel> ListarTurno(string descripcion)
        {
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TURNO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@descripcion",descripcion);
            leer = cmd.ExecuteReader();
            List<TurnoModel> ListandoTurno = new List<TurnoModel>();
            while (leer.Read())
            {
                ListandoTurno.Add(new TurnoModel
                {
                    id_turno=leer.GetInt32(0),
                    descripcion=leer.GetString(1)
                });
            }

            connection.Close();
            leer.Close();
            return ListandoTurno;


        }
    }
}
