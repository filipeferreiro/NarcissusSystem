using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NarcissusSystem.Controllers
{
    public class AdministrativoController : Controller
    {
        [Authorize]
        public ActionResult pagAdm()
        {
            return View();
        }
    }
}