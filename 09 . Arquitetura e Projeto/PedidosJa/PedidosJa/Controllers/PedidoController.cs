﻿using Model.Models;
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
            List<Pedido> listaPedidos = rp.ObterPedidos(p => p.Empresa.Id == empresa.Id);
            int t = rp.ObterTodos().Count;
            return View(listaPedidos);
        }
        
        // GET: Pedido
        public ActionResult ListaDePedidosUsuario()
        {
            GerenciadoraPedido rp = new GerenciadoraPedido();
            Usuario usuario = (Usuario)Util.SessionHelper.Get(Util.SessionKeys.USUARIO);
            List<Pedido> listaPedidos = rp.ObterPedidos(p => p.Usuario.Id == usuario.Id);

            return View(listaPedidos);
        }

        public ActionResult AlterarStatusPedido(int id)
        {
            GerenciadoraPedido gp = new GerenciadoraPedido();
            Pedido pedido = gp.Obter(ped => ped.Id == id);
            pedido.Situacao = "Feito";
            gp.Editar(pedido);

            return RedirectToAction("ListaDePedidos");
        }

        //DETALHE PARA EMPRESA
        public ActionResult VerPedidoEmpresa(int id)
        {
            GerenciadoraPedido gp = new GerenciadoraPedido();
            Pedido pedido = gp.Obter(p => p.Id == id);

            MontarResumoDeComplementos(pedido);

            return View(pedido);
        }

        //DETALHE PARA USUARIO
        public ActionResult VerPedidoUsuario(int id)
        {
            GerenciadoraPedido gp = new GerenciadoraPedido();
            Pedido pedido = gp.Obter(p => p.Id == id);

            MontarResumoDeComplementos(pedido);

            return View(pedido);
        }

        public void MontarResumoDeComplementos(Pedido pedido)
        {
            ProdutoController pc = new ProdutoController();
            foreach (var produto in pedido.ListaProdutos)
            {
                pc.FormatarComplementos(produto);
            }
        }
    }
}