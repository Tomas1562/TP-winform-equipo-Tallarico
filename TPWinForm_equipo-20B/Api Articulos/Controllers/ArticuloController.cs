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
        public HttpResponseMessage Post([FromBody] ArticuloDTO art)
        {
            var negocio = new ArticuloNegocio();
            var marcaNegocio = new MarcaNegocio();
            var categoriaNegocio = new CategoriaNegocio();

            // no viene nulo
            if (art == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Debe enviar un producto válido.");

            // que ingrese los campos
            if (string.IsNullOrEmpty(art.Nombre))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "El nombre es obligatorio.");

            if (art.precio <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "El precio debe ser mayor a 0.");

            // ver que exista marca y categoria
            Marca marca = marcaNegocio.listar().Find(x => x.IdMarca == art.Idmarca);
            Categoria categoria = categoriaNegocio.listar().Find(x => x.IdCategoria == art.IdCategoria);

            if (marca == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "La marca no existe.");

            if (categoria == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "La categoría no existe.");

            
            var nuevo = new Articulo
            {
                Codigo = art.Codigo,
                Nombre = art.Nombre,
                Descripcion = art.Descripcion,
                Marca = marca,
                Categoria = categoria,
                Precio = art.precio
            };

            try
            {
                negocio.agregar(nuevo);
                return Request.CreateResponse(HttpStatusCode.OK, "Artículo agregado correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Articulo/AgregarImagenes")]
        public void AgregarImagenes([FromBody] ImagenDTO dto)
        {

            ImagenNegocio negocio = new ImagenNegocio();
            Imagen ultimo = new Imagen();

            ultimo.IdArticulo = dto.IdArticulo;
            ultimo.UrlImagen = dto.UrlImagen;
            
            negocio.agregar(ultimo);

        }



        // PUT: api/Articulo/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] ArticuloDTO art)
        {
            var negocio = new ArticuloNegocio();
            var marcaNegocio = new MarcaNegocio();
            var categoriaNegocio = new CategoriaNegocio();

            // no viene nulo
            if (art == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Debe enviar un producto válido.");

            // que ingrese los campos
            if (string.IsNullOrEmpty(art.Nombre))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "El nombre es obligatorio.");

            if (art.precio <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "El precio debe ser mayor a 0.");

            // ver que exista marca y categoria
            Marca marca = marcaNegocio.listar().Find(x => x.IdMarca == art.Idmarca);
            Categoria categoria = categoriaNegocio.listar().Find(x => x.IdCategoria == art.IdCategoria);

            if (marca == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "La marca no existe.");

            if (categoria == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "La categoría no existe.");
           
            var actualizado = new Articulo
            {
                idArticulo = id,
                Codigo = art.Codigo,
                Nombre = art.Nombre,
                Descripcion = art.Descripcion,
                Marca = marca,
                Categoria = categoria,
                Precio = art.precio
            };

            try
            {
                negocio.modificar(actualizado);
                return Request.CreateResponse(HttpStatusCode.OK, "Artículo modificado correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error al modificar: " + ex.Message);
            }
        }


        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.eliminar(id);
        }
    }
}
