using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api_Articulos.Models
{
    public class ArticuloDTO
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Idmarca { get; set; }
        public int IdCategoria { get; set; }
        public decimal precio { get; set; }
    }
}