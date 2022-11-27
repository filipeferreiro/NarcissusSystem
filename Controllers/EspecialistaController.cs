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
    public class EspecialistaController : Controller
    {
        // GET: Especialista
        public ActionResult Especialista()
        {
            var especialista = new Especialista();
            return View(especialista);
        }
        Acoes ac = new Acoes();

        [HttpPost]
        public ActionResult CadEspecialista(Especialista especialista)
        {
            ac.CadastrarEspecialista(especialista);
            return View(especialista);
        }

        public ActionResult ListarEspecialista()
        {
            var ExibirEspec = new Acoes();
            var TodosEspec = ExibirEspec.ListarEspecialista();
            return View(TodosEspec);
        }
    }
}