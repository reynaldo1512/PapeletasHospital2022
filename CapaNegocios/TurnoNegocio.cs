using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
     public class TurnoNegocio
    {

        TurnoDao data = new TurnoDao();
        public List<TurnoModel> ListandoTurno(string descripcion)
        {
            return data.ListarTurno(descripcion);
        }

    }
}
