using MySqlX.XDevAPI;
using NarcissusSystem.Models;
using NarcissusSystem.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace NarcissusSystem.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Cliente()
        {
            var cliente = new Cliente(); // aqui criamos o projeto
            return View(cliente); // Retornamos para a view dados
        }
        Acoes ac = new Acoes();

        [HttpPost]
        public ActionResult CadCliente(Cliente cliente)
        {
            ac.CadastrarClientes(cliente);
            return View(cliente);
        }

        public ActionResult ListarCliente()
        {
            var ExibirClie = new Acoes();
            var TodosClie = ExibirClie.ListarCliente();
            return View(TodosClie);
        }
    }
}