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
    public class HorarioPruebaDao
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        public List<HorarioPruebaModel> ListarHorarioPruebaModel(string descripcion)
        {
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_HORARIO_PRUEBA", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("descripcion", descripcion);
            leer = cmd.ExecuteReader();
            List<HorarioPruebaModel> ListandoHorarioPrueba = new List<HorarioPruebaModel>();
            while (leer.Read())
            {
                ListandoHorarioPrueba.Add(new HorarioPruebaModel
                {
                    id_horario = leer.GetInt32(0),
                    descripcion = leer.GetString(1)
                });
            }
            connection.Close();
            leer.Close();
            return ListandoHorarioPrueba;

        }
    }
}
