using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Articulos.Models
{
    public class ArticuloDTO
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int Idmarca { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public string Urlimagen { get; set; }
    }
}