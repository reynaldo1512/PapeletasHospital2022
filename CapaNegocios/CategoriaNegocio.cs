using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using CapaNegocios;

    public class CategoriaNegocio
    {

    CategoriaDao data = new CategoriaDao();
    public List<CategoriaModel>ListandoCategoria(string descripcion)
    {
        return data.ListarCategoria(descripcion);
    }


    }
