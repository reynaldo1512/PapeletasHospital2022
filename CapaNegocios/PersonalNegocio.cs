using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocios
{
    public class PersonalNegocio
    {
        PersonalDao data = new PersonalDao();
        public List<PersonalModel>ListandoPersonal(string descripcion)
        {
            return data.ListarPersonal(descripcion);
        }
    }
}
