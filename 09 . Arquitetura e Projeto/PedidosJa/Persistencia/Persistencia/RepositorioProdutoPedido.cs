using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistencia
{
    class RepositorioProdutoPedido
    {
        private static List<ProdutoPedido> listaProdutoPedido;

        static RepositorioProdutoPedido()
        {
            listaProdutoPedido = new List<ProdutoPedido>();
        }

        public ProdutoPedido Adicionar(ProdutoPedido produtoPedido)
        {
            produtoPedido.IdProdutoPedido = listaProdutoPedido.Count + 1;
            listaProdutoPedido.Add(produtoPedido);
            return produtoPedido;
        }

        public void Editar(ProdutoPedido produtoPedido)
        {
            int posicao = listaProdutoPedido.FindIndex(e => e.IdProdutoPedido == produtoPedido.IdProdutoPedido);
            listaProdutoPedido[posicao] = produtoPedido;
        }

        public void Remover(ProdutoPedido produtoPedido)
        {
            int posicao = listaProdutoPedido.FindIndex(e => e.IdProdutoPedido == produtoPedido.IdProdutoPedido);
            listaProdutoPedido.RemoveAt(posicao);
        }

        public ProdutoPedido Obter(Func<ProdutoPedido, bool> where)
        {
            return listaProdutoPedido.Where(where).FirstOrDefault();
        }

        public List<ProdutoPedido> ObterTodos()
        {
            return listaProdutoPedido;
        }
    }
}
