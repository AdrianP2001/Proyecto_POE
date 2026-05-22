using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Datos;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Negocio
{
    public class GestorGaleria
    {
        private GaleriaDAO _galeriaDAO = new GaleriaDAO();

        public List<ImagenGaleria> ObtenerFotos()
        {
            return _galeriaDAO.ObtenerTodas();
        }
    }
}
