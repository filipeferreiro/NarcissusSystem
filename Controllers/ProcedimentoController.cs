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
    public class ProcedimentoController : Controller
    {
        // GET: Procedimento
        // GET: Funcionario
        public ActionResult Procedimento()
        {
            var procedimento = new Procedimento();
            return View(procedimento);
        }
        Acoes ac = new Acoes();

        [HttpPost]
        public ActionResult CadProcedimento(Procedimento procedimento)
        {
            ac.CadastrarProcedimento(procedimento);
            return View(procedimento);
        }

        public ActionResult ListarProcedimento()
        {
            var ExibirProc = new Acoes();
            var TodosProc = ExibirProc.ListarProcedimento();
            return View(TodosProc);
        }
    }
}