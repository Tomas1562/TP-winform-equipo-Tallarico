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
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo ultimo = new Articulo();
            ultimo.Nombre = art.Nombre;
            ultimo.Precio = art.Precio;
            ultimo.Codigo = art.Codigo;
            //ultimo.Imagenes = art.Urlimagen;
            ultimo.Marca = new Marca { IdMarca = art.Idmarca };
            ultimo.Categoria = new Categoria { IdCategoria = art.IdCategoria };

            negocio.agregar(ultimo);




        }

        // PUT: api/Articulo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
        }
    }
}
