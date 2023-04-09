using StandBy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StandBy.Controllers.Api
{
    public class ClientesController : ApiController
    {
        private ApplicationDbContext _context;

        //GET /api/clientes
        public IEnumerable<Clientes> GetClientes() {
            return _context.Clientes.ToList();
        }

        //GET /api/clientes/1
        public Clientes getCliente(int id) {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if(cliente == null) 
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return cliente;
        }

        //POST /api/clientes
        [HttpPost]
        public Clientes postCliente(Clientes cliente)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        //PUT /api/clientes/1
        public void updateCliente(int id, Clientes cliente) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var clienteInDb = _context.Clientes.SingleOrDefault(c => c.Id == id);
            if (clienteInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //
            //use auto mapper
            //
            //

            _context.SaveChanges();
        }

        //DELETE /api/clientes/1
        [HttpDelete]
        public void deleteCliente(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var clienteInDb = _context.Clientes.SingleOrDefault(c => c.Id == id);
            if (clienteInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Clientes.Remove(clienteInDb);
            _context.SaveChanges();
        }

        public ClientesController() {
            _context = new ApplicationDbContext();
        }
    }
}
