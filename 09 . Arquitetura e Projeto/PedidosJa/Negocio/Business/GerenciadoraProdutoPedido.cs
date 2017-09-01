using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadoraProdutoPedido
    {
        RepositorioProdutoPedido repositorioProdutoPedido;

        GerenciadoraProdutoPedido()
        {
            repositorioProdutoPedido = new RepositorioProdutoPedido();
        }

        public ProdutoPedido Adicionar(ProdutoPedido produtoPedido)
        {
            return repositorioProdutoPedido.Adicionar(produtoPedido);
        }

        public void Editar(ProdutoPedido produtoPedido)
        {
            repositorioProdutoPedido.Editar(produtoPedido);
        }

        public void Remover(ProdutoPedido produtoPedido)
        {
            repositorioProdutoPedido.Remover(produtoPedido);
        }

        public ProdutoPedido Obter(Func<ProdutoPedido, bool> where)
        {
            return repositorioProdutoPedido.Obter(where);
        }

        public List<ProdutoPedido> ObterTodos()
        {
            return repositorioProdutoPedido.ObterTodos();
        }
    }
}
