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
    public class DepartamentoDao
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);


        public  List<DepartamentoModel>ListarDepartamento(string descripcion)
        {
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_DEPARTAMENTO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            leer = cmd.ExecuteReader();
            List<DepartamentoModel> ListandoDepartamento = new List<DepartamentoModel>();
            while (leer.Read())
            {
                ListandoDepartamento.Add(new DepartamentoModel
                {
                    id_departamento=leer.GetInt32(0),
                    descripcion=leer.GetString(1)
                });

            }
            connection.Close();
            leer.Close();
            return ListandoDepartamento;
        }
    }
}
