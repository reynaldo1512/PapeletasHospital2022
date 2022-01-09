using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class HorarioNegocio
    {
        HorarioDao data = new HorarioDao();
        public List<HorarioModel>ListandoHorario(string descripcion)
        {
            return data.ListarHorario(descripcion);
        }
    }
}
