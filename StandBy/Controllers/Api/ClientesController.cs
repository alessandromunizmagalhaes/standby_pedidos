using AutoMapper;
using StandBy.DTOs;
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
        public IEnumerable<ClientesDTO> GetClientes() {
            return _context.Clientes.ToList().Select(Mapper.Map<Clientes, ClientesDTO>);
        }

        //GET /api/clientes/1
        public IHttpActionResult getCliente(int id) {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                NotFound();

            return Ok(Mapper.Map<Clientes, ClientesDTO>(cliente));
        }

        //POST /api/clientes
        [HttpPost]
        public IHttpActionResult postCliente(ClientesDTO clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente = Mapper.Map<ClientesDTO, Clientes>(clienteDto);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            clienteDto.Id = cliente.Id;

            return Created(new Uri(Request.RequestUri + "/" + cliente.Id), clienteDto);
        }

        //PUT /api/clientes/1
        public void updateCliente(int id, ClientesDTO clienteDto) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var clienteInDb = _context.Clientes.SingleOrDefault(c => c.Id == id);
            if (clienteInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(clienteDto, clienteInDb); 

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
