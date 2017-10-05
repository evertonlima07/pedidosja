using Model.Models;
using Negocio.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PedidosJa.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult ListaDeProdutos()
        {
            //LIMPAR SEÇÃO DE PRODUTO
            Util.SessionHelper.Set(Util.SessionKeys.PRODUTO, null);

            GerenciadoraProduto gp = new GerenciadoraProduto();
            Empresa empresa = (Empresa) Util.SessionHelper.Get(Util.SessionKeys.EMPRESA);
            List<Produto> listaProdutos = gp.ObterPorEmpresa(e => e.Empresa.Id == empresa.Id);
            return View(listaProdutos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto novoProduto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    novoProduto.ListaComplemento = new List<Complemento>();
                    novoProduto.Empresa = (Empresa)Util.SessionHelper.Get(Util.SessionKeys.EMPRESA);

                    GerenciadoraProduto gp = new GerenciadoraProduto();
                    novoProduto = gp.Adicionar(novoProduto);
                    Util.SessionHelper.Set(Util.SessionKeys.PRODUTO,novoProduto);
                    
                    return RedirectToAction("SelecionarComplementosNovoProduto","Complemento");
                }
            }
            catch
            {

            }
            
            return View();
        }

        public ActionResult Remover(int id)
        {
            GerenciadoraProduto gp = new GerenciadoraProduto();
            Produto prod = gp.Obter(p => p.Id == id);
            gp.Remover(prod);
            return RedirectToAction("ListaDeProdutos", "Produto");
        }

        public ActionResult Alterar(int id)
        {
            GerenciadoraProduto gp = new GerenciadoraProduto();
            Produto prod = gp.Obter(p => p.Id == id);
            return View(prod);
        }
        
        [HttpPost]
        public ActionResult Alterar(Produto prod)
        {
            // Retrieve existing dinner
            GerenciadoraProduto gp = new GerenciadoraProduto();
            Produto prodAlt = gp.Obter(p => p.Id == prod.Id);
            prodAlt.Nome = prod.Nome;
            prodAlt.Preco = prod.Preco;
            gp.Editar(prodAlt);

            Util.SessionHelper.Set(Util.SessionKeys.PRODUTO, prodAlt);
            return RedirectToAction("SelecionarComplementosAlterarProduto", "Complemento");
        }

        public void FormatarComplementos(Produto produto)
        {
            string linha = "";
            foreach (var comp in produto.ListaComplemento)
            {
                linha = comp.Descricao + " | ";
            }
            produto.ComplementosFormatados = linha;
        }
        /*
        public ActionResult SelecionarProdutoPedido()
        {
            GerenciadoraProduto gp = new GerenciadoraProduto();
            Pedido pedido = (Pedido)Util.SessionHelper.Get(Util.SessionKeys.PEDIDO);
            Empresa empresa = pedido.Empresa;
            //List<Produto> listaProdutos = gp.ObterTodosDaEmpresa(p => p.Empresa.Id == empresa.Id);
            return View(listaProdutos);
        }
        */
    }
}