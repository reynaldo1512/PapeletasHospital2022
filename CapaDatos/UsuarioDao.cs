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
    public class UsuarioDao
        
    {
      SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

       public bool login (string user , string pass)
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE nombre_usuario=@user and contraseña=@pass",connection);
            cmd.CommandType = CommandType.Text;
            
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            
           
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    UsuarioModel.id_usuario = reader.GetInt32(0);
                    UsuarioModel.nombre = reader.GetString(1);
                    UsuarioModel.nombre_usuario = reader.GetString(2);
                    UsuarioModel.contraseña = reader.GetString(3);
                    UsuarioModel.fecha = reader.GetDateTime(4);
                    UsuarioModel.estado = reader.GetBoolean(5);
                    UsuarioModel.id_departamento = reader.GetInt32(6);
                    UsuarioModel.id_rol = reader.GetInt32(7);


                }
                connection.Close();
                return true;
            }
            else
            {
                return false;
            }
           

                
            
        }
       
    }
}
