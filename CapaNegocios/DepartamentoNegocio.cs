using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class DepartamentoNegocio
    {

        DepartamentoDao data = new DepartamentoDao();
        public List<DepartamentoModel>ListandoDepartamento(string descripcion)
        {
            return data.ListarDepartamento(descripcion);
        }
    }
}
