using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;

namespace CapaDatos
{
   public class PersonalDao
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public List<PersonalModel>ListarPersonal(string descripcion)
        {
            SqlDataReader leer;

            SqlCommand cmd = new SqlCommand("SP_LISTAR_PERSONAL", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            leer = cmd.ExecuteReader();
            List<PersonalModel> ListandoPersonal = new List<PersonalModel>();
            while (leer.Read())
            {
                ListandoPersonal.Add(new PersonalModel
                {
                    id_personal = leer.GetInt32(0),
                    descripcion = leer.GetString(1)
                });
            }
            connection.Close();
            leer.Close();
            return ListandoPersonal;
                
        }
    }
}
