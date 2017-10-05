using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace PedidosJa.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult ListaDeEmpresas()
        {
            GerenciadoraEmpresa re = new GerenciadoraEmpresa();
            Usuario usuario = (Usuario)Util.SessionHelper.Get(Util.SessionKeys.USUARIO);
            List<Empresa> listaEmpresas = re.ObterTodos();

            return View(listaEmpresas);
        }

        public ActionResult ListaDeProdutosEmpresa()
        {
            GerenciadoraProduto rp = new GerenciadoraProduto();
            Empresa empresa = (Empresa)Util.SessionHelper.Get(Util.SessionKeys.EMPRESA);
            List<Produto> listaProdutoEmpresa = rp.ObterTodos();

            return View(listaProdutoEmpresa);
        }

        public ActionResult IniciarPedido(int id)
        {
            int idEmpresa = id;
            return RedirectToAction("IniciarPedido","Pedido", new { id = idEmpresa });
        }
    }
}