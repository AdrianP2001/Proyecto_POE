using System;

namespace Proyecto_POE.Entidades
{
    public class ImagenGaleria
    {
        public int IdImagen { get; set; }
        public int? IdActividad { get; set; }
        public string Titulo { get; set; }
        public string RutaLocal { get; set; }
        public DateTime FechaSubida { get; set; }
        public bool Activo { get; set; }

        public ImagenGaleria()
        {
            FechaSubida = DateTime.Now;
            Activo = true;
        }
    }
}
