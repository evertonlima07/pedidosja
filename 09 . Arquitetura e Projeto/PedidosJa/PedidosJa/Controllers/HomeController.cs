using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PedidosJa.Util;
using Model.Models;

namespace PedidosJa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //LOGIN AQUI
            return View();
        }

        public ActionResult Usuario()
        {
            //ESSE CÓDIGO SERÁ USADO NO LOGIN
            Usuario user = new Usuario();
            user.Id = 1;
            user.Nome = "Daniel Lima Oliveira";
            user.Endereco = "Rua Francisco Oliveira, 2423";
            user.Email = "daniel102510@hotmail.com";
            user.Login = "daniel102510";
            user.Senha = "daniel@123";

            SessionHelper.Set(SessionKeys.TIPO_USER, "Usuario");
            SessionHelper.Set(SessionKeys.USUARIO, user);
            //

            ViewBag.Title = "Home";
            return View();
        }

        public ActionResult Empresa()
        {
            //ESSE CÓDIGO SERÁ USADO NO LOGIN
            Empresa empresa = new Empresa();
            empresa.Id = 1;
            empresa.Nome = "Itatech Jr.";
            empresa.Telefone = "79998397106";
            empresa.Login = "itetech";
            empresa.Senha = "itatech";
            empresa.Funcionamento = "ABERTO";

            SessionHelper.Set(SessionKeys.TIPO_USER, "Empresa");
            SessionHelper.Set(SessionKeys.EMPRESA, empresa);
            //

            ViewBag.Title = "Home";
            return View();
        }
        
    }
}