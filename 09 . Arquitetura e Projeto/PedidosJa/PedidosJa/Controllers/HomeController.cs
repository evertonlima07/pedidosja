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
            GerenciadoraUsuario gu = new GerenciadoraUsuario();
            
            //ESSE CÓDIGO SERÁ USADO NO LOGIN
            Usuario user = gu.ObterTodos()[0];
            SessionHelper.Set(SessionKeys.TIPO_USER, "Usuario");
            SessionHelper.Set(SessionKeys.USUARIO, user);
            
            return RedirectToAction("ListaDeEmpresas", "Empresa");
        }

        public ActionResult Empresa()
        {
            GerenciadoraEmpresa ge = new GerenciadoraEmpresa();
            List<Empresa> empresas = ge.ObterTodos();

            Empresa empresa = empresas[0];

            SessionHelper.Set(SessionKeys.TIPO_USER, "Empresa");
            SessionHelper.Set(SessionKeys.EMPRESA, empresa);

            return RedirectToAction("ListaDePedidos", "Pedido");
        }
        
    }
}