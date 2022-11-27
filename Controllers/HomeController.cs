using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace NarcissusSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProdutoSingle()
        {
            return View();
        }

        public ActionResult Produtos()
        {
            return View();
        }

        public ActionResult Carrinho()
        {
            return View();
        }

        public ActionResult Pesquisa()
        {
            return View();
        }

        public ActionResult Tratamentos()
        {
            return View();
        }
    }
}