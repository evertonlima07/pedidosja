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

            RepositorioEmpresa re = new RepositorioEmpresa();
            RepositorioUsuario ru = new RepositorioUsuario();

            Pedido pedido1 = new Pedido();
            pedido1.Id = 1;
            pedido1.Empresa = re.ObterTodos()[0];
            pedido1.EnderecoUsuario = "Rua Francisco Oliveira";
            pedido1.DescricaoPagamento = "A vista, troco para 50";
            pedido1.TelefoneUsuario = "79 998397106";
            pedido1.NomeUsuario = "Daniel Lima";
            pedido1.Situacao = "A fazer";
            pedido1.ListaProdutos = new List<Produto>();
            pedido1.Usuario = ru.ObterTodos()[0];
            RepositorioProduto rp = new RepositorioProduto();
            pedido1.ListaProdutos.Add(rp.ObterTodos()[0]);
            pedido1.Data = DateTime.Now;
            listaPedido.Add(pedido1);
            
            Pedido pedido2 = new Pedido();
            pedido2.Id = 2;
            pedido2.Empresa = re.ObterTodos()[0];
            pedido2.EnderecoUsuario = "Rua Quintino de Lacerda";
            pedido2.DescricaoPagamento = "Cartão";
            pedido2.TelefoneUsuario = "79 998397106";
            pedido2.NomeUsuario = "Daniel Lima";
            pedido2.Situacao = "A fazer";
            pedido2.ListaProdutos = new List<Produto>();
            pedido2.Usuario = ru.ObterTodos()[0];
            RepositorioProduto rp2 = new RepositorioProduto();
            pedido2.Usuario = ru.ObterTodos()[0];
            pedido2.Data = DateTime.Now;

            listaPedido.Add(pedido2);
            
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

        public List<Pedido> ObterPorEmpresa(Func<Pedido, bool> where)
        {
            return listaPedido.Where(where).ToList();
        }

        public List<Pedido> ObterTodos()
        {
            return listaPedido;
        }
    }
}
