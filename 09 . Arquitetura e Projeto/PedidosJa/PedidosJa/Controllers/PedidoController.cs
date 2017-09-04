using Model.Models;
using Negocio.Business;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace PedidosJa.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult ListaDePedidos()
        {
            GerenciadoraPedido rp = new GerenciadoraPedido();
            Empresa empresa = (Empresa) Util.SessionHelper.Get(Util.SessionKeys.EMPRESA);
            List<Pedido> listaPedidos = rp.ObterPorEmpresa(p => p.Empresa.Id == empresa.Id);

            return View(listaPedidos);
        }

        //DETALHE PARA EMPRESA
        public ActionResult VerPedidoEmpresa()
        {
            return View();
        }
    }
}