using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using System.Data;
using CapaEntidad;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CategoriaDao
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public List<CategoriaModel>ListarCategoria(string descripcion)
        {
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CATEGORIA",connection);
            cmd.CommandType = CommandType.StoredProcedure; 
            connection.Open();
            cmd.Parameters.AddWithValue("@descripcion",descripcion);
            leer=cmd.ExecuteReader();
            List<CategoriaModel> ListandoCategoria = new List<CategoriaModel>();
            while (leer.Read())
            {
                ListandoCategoria.Add(new CategoriaModel
                {
                    id_categoria=leer.GetInt32(0),
                    descripcion=leer.GetString(1)
                });
            }
            connection.Close();
            leer.Close();
            return ListandoCategoria;
        }
    }
}
