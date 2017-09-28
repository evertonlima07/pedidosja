using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using System.Linq.Expressions;

namespace Persistencia.Persistencia
{
    public class RepositorioPedido
    {
        private static List<Pedido> listaPedido;

        static RepositorioPedido()
        {
            listaPedido = new List<Pedido>();
        }

        public Pedido Adicionar(Pedido pedido)
        {
            pedido.Id = listaPedido.Count + 1;
            listaPedido.Add(pedido);
            return pedido;
        }

        public void Editar(Pedido pedido)
        {
            int i = listaPedido.FindIndex(e => e.Id == pedido.Id);
            listaPedido[i] = pedido;
        }

        public void Remover(Pedido pedido)
        {
            int posicao = listaPedido.FindIndex(e => e.Id == pedido.Id);
            listaPedido.RemoveAt(posicao);
        }

        public Pedido Obter(Func<Pedido, bool> where)
        {
            return listaPedido.Where(where).FirstOrDefault();
        }

        public List<Pedido> ObterPedidos(Func<Pedido, bool> where)
        {
            return listaPedido.Where(where).ToList();
        }

        public List<Pedido> ObterTodos()
        {
            return listaPedido;
        }
    }
}
