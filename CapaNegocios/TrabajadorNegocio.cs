using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
   public class TrabajadorNegocio

    {
        TrabajadorDao data = new TrabajadorDao();
        TrabajadorModel trabajador = new TrabajadorModel();

        public DataTable ListarTrabajadores ()
        {
            TrabajadorNegocio trabajador = new TrabajadorNegocio();
            return data.ListarTrabajador();
        }



        public DataTable Buscartrabajador(string filtro)
        {

            trabajador.primer_nombre = filtro;
            return data.BuscarTrabajador(trabajador);
        }


        public void AgregarTrabajador(TrabajadorModel trabajador)
        {
            data.AgregarTrabajador(trabajador);
        }

        public void EditarTrabajador(TrabajadorModel trabajador)
        {
            data.EditarTrabajador(trabajador);
        }



    }
}
