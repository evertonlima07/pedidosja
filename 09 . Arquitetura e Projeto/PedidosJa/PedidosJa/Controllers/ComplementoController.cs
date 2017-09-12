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
                listaComplementos.Add(pc.Complemento);
            }
            ViewBag.ListaComplementos = listaComplementos;
            return View(gc.ObterPorEmpresa(e => e.Empresa.Id == empresaAtual.Id));
        }

        [HttpPost]
        public ActionResult SelecionarComplementosNovoProduto(FormCollection form)
        {
            String[] lista = form["Complemento"].Split(',');
            Produto produto = (Produto) Util.SessionHelper.Get(Util.SessionKeys.PRODUTO);
            GerenciadoraComplemento gc = new GerenciadoraComplemento();
            if (lista != null) { 
                foreach (var comp in lista)
                {
                    Complemento complemento = gc.Obter(c => c.Id == Convert.ToInt32(comp.ToString()));
                    ProdutoComplemento pc = new ProdutoComplemento();
                    pc.Produto = produto;
                    pc.Complemento = complemento;

                    produto.ListaComplemento.Add(pc);
                }
            }

            return RedirectToAction("ProcessaAdicionarProduto", "Produto");
        }
        
    }
}