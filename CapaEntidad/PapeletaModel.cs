using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PapeletaModel
    {
        public int id_papeleta { get; set; }
        public int id_tipoPapeleta { get; set; }
        public int id_trabajador { get; set; }
        public int id_motivo{ get; set; }
        public string turno { get; set; }
        public int id_usuario { get; set; }
        public string numero_documento { get; set; }
        public DateTime fecha_inicio{ get; set; }
        public DateTime fecha_fin { get; set; }
        public int hora_inicio { get; set; }
        public int minuto_inicio{ get; set; }
        public int hora_fin { get; set; }
        public int minuto_fin { get; set; }
        public decimal remuneracion_dia { get; set; }
        public decimal remuneracion_minuto { get; set; }
        public decimal descuento { get; set; }
        public string sustento { get; set; }
        public DateTime fecha_registro { get; set; }
        public bool estado { get; set; }
        public int id_turno { get; set; }
        public int id_solicitud { get; set; }


    }
}
