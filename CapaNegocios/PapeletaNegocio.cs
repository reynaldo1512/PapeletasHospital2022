﻿using System;
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
        TrabajadorModel trabajador = new TrabajadorModel();

        public DataTable ListarPapeletas()
        {
            PapeletaNegocio papeleta = new PapeletaNegocio();
            return data.ListarPapeleta();
        }

      
        public DataTable BuscarPapeletas(string filtro)
        {
            PapeletaNegocio papeleta = new PapeletaNegocio();
            return data.BuscarPapeleta(filtro);
        }
        
        public void AgregarPapeleta (PapeletaModel papeleta)
        {
            data.AgregarPapeleta(papeleta);
        }

        public void EditarPapeleta(PapeletaModel papeleta)
        {
            data.EditarPapeleta(papeleta);
        }
        public void EliminarPapeleta(int id_papeleta)
        {
            data.EliminarPapeleta(id_papeleta);
        }
    }
}
