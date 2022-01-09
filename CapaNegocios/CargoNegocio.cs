using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class CargoNegocio
    {
        CargoDao  data = new CargoDao();
        public List<CargoModel>ListandoCargo(string descripcion)
        {
            return data.ListarCargo(descripcion);
        }
    }

}
