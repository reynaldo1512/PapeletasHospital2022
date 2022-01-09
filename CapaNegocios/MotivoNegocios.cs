using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class MotivoNegocios
    {

        MotivoDao data = new MotivoDao();
        public List<MotivoModel> ListandoMotivo(string descripcion)
        {
            return data.ListarMotivo(descripcion);

        }
    }
}
