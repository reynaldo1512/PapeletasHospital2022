using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class TrabajadorModel
    {
        public int id_trabajador { get; set; }
        public string DNI{ get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string apellido_materno { get; set; }
        public string apellido_paterno { get; set; }
        public string plaza{ get; set; }
        public bool estado { get; set; }
        public decimal  remuneracion { get; set; }
        public string nivel  { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int id_cargo { get; set; }
        public int id_categoria { get; set; }
        public int id_personal { get; set; }
        public int id_departamento { get; set; }
        public DateTime F_Ingreso { get; set; }

        public int id_horario { get; set; }
        
    }
}
