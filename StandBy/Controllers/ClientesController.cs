using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StandBy.Models;

namespace StandBy.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext _context;

        public ClientesController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }
        
        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        public ActionResult New() {
            var cliente = new Clientes();
            return View("ClientesForm", cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Clientes cliente) {

            if (!ModelState.IsValid)
            {
                return View("ClientesForm", cliente);
            }

            if(cliente.Id == 0) {
                _context.Clientes.Add(cliente);
            } else {
                var clienteInDb = _context.Clientes.Single(c => c.Id == cliente.Id);
                clienteInDb.Nome = cliente.Nome;
                clienteInDb.CpfCnpj = cliente.CpfCnpj;
                clienteInDb.Ativo = cliente.Ativo;
            }

            
            _context.SaveChanges();

            return RedirectToAction("Index", "Clientes");
        }

        public ActionResult Edit(int id) {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null) {
                return HttpNotFound();
            }

            return View("ClientesForm", cliente);
        }
    }
}