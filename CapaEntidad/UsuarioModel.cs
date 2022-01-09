using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public static class UsuarioModel
    {
        public static int id_usuario { get; set; }
        public static string nombre { get; set; }
        public static string nombre_usuario { get; set; }
        public static string contraseña { get; set; }
        public static DateTime fecha { get; set; }
        public static bool estado { get; set; }
        public  static int id_departamento { get; set; }
        public  static int id_rol { get; set; }
    }
}
