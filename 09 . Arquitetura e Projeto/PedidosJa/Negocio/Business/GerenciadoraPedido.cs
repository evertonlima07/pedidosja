using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadoraPedido
    {
        RepositorioPedido repositorioPedido;

        public GerenciadoraPedido()
        {
            repositorioPedido = new RepositorioPedido();
        }

        public Pedido Adicionar(Pedido pedido)
        {
            return repositorioPedido.Adicionar(pedido);
        }

        public void Editar(Pedido pedido)
        {
            repositorioPedido.Editar(pedido);
        }

        public void Remover(Pedido pedido)
        {
            repositorioPedido.Remover(pedido);
        }

        public Pedido Obter(Func<Pedido, bool> where)
        {
            return repositorioPedido.Obter(where);
        }

        public List<Pedido> ObterPorEmpresa(Func<Pedido, bool> where)
        {
            return repositorioPedido.ObterPorEmpresa(where);
        }

        public List<Pedido> ObterTodos()
        {
            return repositorioPedido.ObterTodos();
        }

    }
}
