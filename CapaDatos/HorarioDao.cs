using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Windows.Forms;

namespace CapaDatos
{
    public class HorarioDao
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        public List<HorarioModel> ListarHorario(string descripcion)
        {
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_HORARIO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("descripcion", descripcion);
            leer = cmd.ExecuteReader();
            List<HorarioModel> ListandoHorario = new List<HorarioModel>();
            while (leer.Read())
            {
                ListandoHorario.Add(new HorarioModel
                {
                    id_horario = leer.GetInt32(0),
                    descripcion = leer.GetString(1)
                });
            }
            connection.Close();
            leer.Close();
            return ListandoHorario;

        }

    }
}
