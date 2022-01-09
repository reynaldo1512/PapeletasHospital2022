using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
     public class HorarioPruebaNegocio
    {
        HorarioPruebaDao data = new HorarioPruebaDao();
        public List<HorarioPruebaModel> ListandoHorarioPrueba(string descripcion)
        {
            return data.ListarHorarioPruebaModel(descripcion);
        }
    }
}
