using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
   
    public class CargoDao
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public List<CargoModel> ListarCargo(string descripcion)
        {
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CARGO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            leer = cmd.ExecuteReader();
            List<CargoModel> ListandoCargos = new List<CargoModel>();
            while (leer.Read())
            {
                ListandoCargos.Add(new CargoModel
                {
                    id_cargo = leer.GetInt32(0),
                    descripcion = leer.GetString(1)
                }); 

            }
            connection.Close();
            leer.Close();
            return ListandoCargos;



        }

    }
}
