using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace PedidosJa.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            
            // TODO: Add insert logic here
            string login = collection["Login"];
            string senha = collection["Senha"];

            GerenciadoraUsuario gu = new GerenciadoraUsuario();
            Usuario usuario = gu.Obter(user => String.Compare(user.Login,login) == 0 && String.Compare(user.Senha,senha) == 0);
            if (usuario != null)
            {
                Util.SessionHelper.Set(Util.SessionKeys.USUARIO, usuario);
                Util.SessionHelper.Set(Util.SessionKeys.TIPO_USER, "Usuario");
                return RedirectToAction("Usuario", "Home");
            } else
            {
                GerenciadoraEmpresa ge = new GerenciadoraEmpresa();
                Empresa empresa = ge.Obter(emp => String.Compare(emp.Login,login) == 0 && String.Compare(emp.Senha,senha) == 0);
                if (empresa != null)
                {
                    Util.SessionHelper.Set(Util.SessionKeys.EMPRESA, empresa);
                    Util.SessionHelper.Set(Util.SessionKeys.TIPO_USER, "Empresa");
                    return RedirectToAction("Empresa", "Home");
                }

                return RedirectToAction("Login");
            }
        }

    }
}
