using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class HorarioPruebaModel
    {
        public int id_horario{ get; set; }
        public DateTime Hora_inicio { get; set; }
        public DateTime hora_fin { get; set; }
        public string descripcion { get; set; }
    }
}
