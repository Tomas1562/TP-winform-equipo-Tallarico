using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dominio;
using negocio;
using Api_Articulos.Models;

namespace Api_Articulos.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo
        public IEnumerable<Articulo> Get()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            return negocio.listar();
        }

        // GET: api/Articulo/5
        public Articulo Get(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista = negocio.listar();

            return lista.Find(x=> x.idArticulo == id);
        }

        // POST: api/Articulo
        public void Post([FromBody]ArticuloDTO art)
        {
            /*if (art is null)
            {
                throw new ArgumentNullException(nameof(art));
            }*/

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo ultimo = new Articulo();
          
            ultimo.Codigo = art.Codigo;
            ultimo.Nombre = art.Nombre;
            ultimo.Descripcion = art.Descripcion
            //ultimo.Imagenes = art.Urlimagen;
            ultimo.Marca = new Marca { IdMarca = art.Idmarca };
            ultimo.Categoria = new Categoria { IdCategoria = art.IdCategoria };
            ultimo.Precio = art.precio;

            negocio.agregar(ultimo);




        }

        // PUT: api/Articulo/5
        public void Put(int id, [FromBody] ArticuloDTO art)
        {
        }

        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
        }
    }
}
