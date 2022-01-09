using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class UsuarioNegocio
    {
        UsuarioDao Usuario = new UsuarioDao();
        public bool Loginusuario (string user, string pass)
        {
            return Usuario.login(user, pass);
        }
    }
}
