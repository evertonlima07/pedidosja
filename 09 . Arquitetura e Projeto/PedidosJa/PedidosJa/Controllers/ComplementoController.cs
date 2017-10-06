using Model.Models;
using Negocio.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PedidosJa.Controllers
{
    public class ComplementoController : Controller
    {

        public ActionResult ListaDeComplementos()
        {
            Empresa empresaAtual = (Empresa) Util.SessionHelper.Get(Util.SessionKeys.EMPRESA);
            GerenciadoraComplemento gc = new GerenciadoraComplemento();
            List<Complemento> listaComp = gc.ObterPorEmpresa(e => e.Empresa.Id == empresaAtual.Id);
            return View(listaComp);
        }
        // Action para selecionar complementos de um novo produto
        public ActionResult SelecionarComplementosNovoProduto()
        {
            Empresa empresaAtual = (Empresa)Util.SessionHelper.Get(Util.SessionKeys.EMPRESA);
            GerenciadoraComplemento gc = new GerenciadoraComplemento();
            Produto produtoAtual = (Produto) Util.SessionHelper.Get(Util.SessionKeys.PRODUTO);
            ViewBag.NomeProduto = produtoAtual.Nome;

            return View(gc.ObterPorEmpresa(e => e.Empresa.Id == empresaAtual.Id));
        }
        
        // Action para selecionar complementos da alteração de um produto
        public ActionResult SelecionarComplementosAlterarProduto()
        {
            Empresa empresaAtual = (Empresa)Util.SessionHelper.Get(Util.SessionKeys.EMPRESA);
            GerenciadoraComplemento gc = new GerenciadoraComplemento();
            Produto produtoAtual = (Produto)Util.SessionHelper.Get(Util.SessionKeys.PRODUTO);
            ViewBag.NomeProduto = produtoAtual.Nome;

            List<Complemento> listaComplementos = new List<Complemento>();
            
            foreach (var pc in produtoAtual.ListaComplemento)
            {
                listaComplementos.Add(pc);
            }
            ViewBag.ListaComplementos = listaComplementos;
            return View(gc.ObterPorEmpresa(e => e.Empresa.Id == empresaAtual.Id));
        }

        [HttpPost]
        public ActionResult SelecionarComplementosNovoProduto(FormCollection form)
        {
            GerenciadoraProduto gp = new GerenciadoraProduto();
            String complementos = form["Complemento"];
            if (complementos != null) { 
                String[] lista = complementos.Split(',');
                Produto produto = (Produto) Util.SessionHelper.Get(Util.SessionKeys.PRODUTO);
                GerenciadoraComplemento gc = new GerenciadoraComplemento();
                if (lista != null) { 
                    foreach (var comp in lista)
                    {
                        Complemento complemento = gc.Obter(c => c.Id == Convert.ToInt32(comp.ToString()));

                        produto.ListaComplemento.Add(complemento);
                    }
                }
                gp.Editar(produto);
            }

            return RedirectToAction("ListaDeProdutos", "Produto");
        }

        [HttpPost]
        public ActionResult SelecionarComplementosAlterarProduto(FormCollection form)
        {
            GerenciadoraProduto gp = new GerenciadoraProduto();
            String[] lista = form["Complemento"].Split(',');
            Produto produto = (Produto)Util.SessionHelper.Get(Util.SessionKeys.PRODUTO);
            GerenciadoraComplemento gc = new GerenciadoraComplemento();
            if (lista != null)
            {
                foreach (var comp in lista)
                {
                    Complemento complemento = gc.Obter(c => c.Id == Convert.ToInt32(comp.ToString()));

                    produto.ListaComplemento.Add(complemento);
                }
            }
            gp.Editar(produto);
            return RedirectToAction("ListaDeProdutos", "Produto");
        }

        public ActionResult Remover(int id)
        {
            GerenciadoraComplemento gc = new GerenciadoraComplemento();
            Complemento complemento = gc.Obter(c => c.Id == id);
            gc.Remover(complemento);
            return RedirectToAction("ListaDeComplementos");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Complemento complemento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    complemento.Empresa = (Empresa) Util.SessionHelper.Get(Util.SessionKeys.EMPRESA);
                    GerenciadoraComplemento gc = new GerenciadoraComplemento();
                    gc.Adicionar(complemento);
                    return RedirectToAction("ListaDeComplementos");
                }
            }
            catch
            {

            }

            return View();
        }

        public ActionResult Alterar(int id)
        {
            GerenciadoraComplemento gc = new GerenciadoraComplemento();
            Complemento complemento = gc.Obter(c => c.Id == id);
            return View(complemento);
        }

        [HttpPost]
        public ActionResult Alterar(Complemento complemento)
        {
            // Retrieve existing dinner
            GerenciadoraComplemento gc = new GerenciadoraComplemento();
            Complemento complementoAlt = gc.Obter(c => c.Id == complemento.Id);
            complementoAlt.Descricao = complemento.Descricao;
            
            gc.Editar(complementoAlt);

            return RedirectToAction("ListaDeComplementos");
        }
        
        public ActionResult SelecionarComplementosPedido()
        {
            GerenciadoraProduto gp = new GerenciadoraProduto();

            Produto produtoAtual = (Produto)Util.SessionHelper.Get(Util.SessionKeys.PRODUTO);
            Produto produtoBanco = gp.Obter(p => p.Id == produtoAtual.Id);

            if (produtoBanco.ListaComplemento.Count == 0) return RedirectToAction("SelecionarProdutoPedido", "Produto");

            return View(produtoBanco.ListaComplemento);
        }

        [HttpPost]
        public ActionResult SelecionarComplementosPedido(FormCollection form)
        {
            if (form["Complemento"] == null) return RedirectToAction("SelecionarProdutoPedido", "Produto");

            GerenciadoraProduto gp = new GerenciadoraProduto();
            String[] lista = form["Complemento"].Split(',');
            Produto atual = (Produto)Util.SessionHelper.Get(Util.SessionKeys.PRODUTO);
            GerenciadoraComplemento gc = new GerenciadoraComplemento();
            if (lista != null)
            {
                foreach (var comp in lista)
                {
                    Complemento complemento = gc.Obter(c => c.Id == Convert.ToInt32(comp.ToString()));

                    atual.ListaComplemento.Add(complemento);
                }
            }
            
            return RedirectToAction("SelecionarProdutoPedido", "Produto");
        }

    }

}