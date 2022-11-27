using System;
using NarcissusSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using NarcissusSystem.ViewModel;
using Hash = NarcissusSystem.Utils.Hash;

namespace NarcissusSystem.Controllers
{
    public class AutenticacaoController : Controller
    {
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Usuario usuario = new Usuario
            {
                Nome = viewModel.UsuarioNome,
                Login = viewModel.Login,
                Senha = Hash.GerarHash(viewModel.Senha)
            };

            usuario.InsertUsuario(usuario);

            TempData["MensagemLogin"] = "Cadastro realizado com sucesso! Faça seu login.";
            return RedirectToAction("Login", "Autenticacao");
        }

        public ActionResult SelectLogin(string vLogin)
        {
            bool LoginExists;
            string login = new Usuario().SelectLogin(vLogin);

            if (login.Length == 0)
                LoginExists = false;
            else
                LoginExists = true;

            return Json(!LoginExists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                urlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }
            Usuario usuario = new Usuario();
            usuario = usuario.SelectUsuario(viewmodel.Login);

            if (usuario == null | usuario.Login != viewmodel.Login)
            {
                ModelState.AddModelError("Login", "Login incorreto");
                return View(viewmodel);
            }

            if (usuario.Senha != Hash.GerarHash(viewmodel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewmodel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Login),
                new Claim("Login", usuario.Login)
            }, "AppAplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewmodel.urlRetorno) || Url.IsLocalUrl(viewmodel.urlRetorno))
            {
                return Redirect(viewmodel.urlRetorno);

            }
            else
            {
                TempData["MensagemLogin"] = "Login realizado com sucesso";
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("pagAdm", "Administrativo");

            }

        }



        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppAplicationCookie");
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return View();

            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;

            Usuario usuario = new Usuario();
            usuario = usuario.SelectUsuario(login);

            if (Hash.GerarHash(viewmodel.SenhaAtual) != usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha não corresponde");
                return View();
            }


            if (Hash.GerarHash(viewmodel.NovaSenha) == usuario.Senha)
            {
                ModelState.AddModelError("NovaSenha", "Senha não pode ser igual a anterior");
                return View();
            }

            usuario.Senha = Hash.GerarHash(viewmodel.NovaSenha);
            usuario.UpdateSenha(usuario);
            Request.GetOwinContext().Authentication.SignOut("AppAplicationCookie");


            TempData["MensagemLogin"] = "Senha alterada com sucesso!";
            return RedirectToAction("Login", "Autenticacao");
        }
    }
}