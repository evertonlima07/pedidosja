using System.Web.Mvc;
using PedidosJa.Util;
using Model.Models;
using Negocio.Business;
using System.Collections.Generic;

namespace PedidosJa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //LOGIN AQUI
            //ESSE CÓDIGO SERÁ USADO NO LOGOFF
            SessionHelper.Set(SessionKeys.USUARIO, null);
            SessionHelper.Set(SessionKeys.EMPRESA, null);
            SessionHelper.Set(SessionKeys.TIPO_USER, null);

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
            GerenciadoraEmpresa ge = new GerenciadoraEmpresa();
            List<Empresa> empresas = ge.ObterTodos();

            Empresa empresa = empresas[0];

            SessionHelper.Set(SessionKeys.TIPO_USER, "Empresa");
            SessionHelper.Set(SessionKeys.EMPRESA, empresa);
            //

            return RedirectToAction("ListaDePedidos", "Pedido");
        }
        
    }
}