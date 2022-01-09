using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class PapeletaNegocio
    {
        PapeletaDao data = new PapeletaDao();
        PapeletaModel papeleta = new PapeletaModel();

        public DataTable ListarPapeletas()
        {
            PapeletaNegocio papeleta = new PapeletaNegocio();
            return data.ListarPapeleta();
        }

        public void AgregarPapeleta (PapeletaModel papeleta)
        {
            data.AgregarPapeleta(papeleta);
        }
    }
}
