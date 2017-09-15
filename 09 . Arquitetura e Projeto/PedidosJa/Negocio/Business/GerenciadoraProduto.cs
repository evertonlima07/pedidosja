using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadoraProduto
    {
        RepositorioProduto repositorioProduto;

        public GerenciadoraProduto()
        {
           repositorioProduto = new RepositorioProduto();
        }

        public Produto Adicionar(Produto produto)
        {
            return repositorioProduto.Adicionar(produto);
        }

        public void Editar(Produto produto)
        {
            repositorioProduto.Editar(produto);
        }

        public void Remover(Produto produto)
        {
            repositorioProduto.Remover(produto);
        }

        public Produto Obter(Func<Produto, bool> where)
        {
            return repositorioProduto.Obter(where);
        }

        public List<Produto> ObterTodosDaEmpresa(Func<Produto, bool> where)
        {
            return repositorioProduto.ObterTodosDaEmpresa(where);
        }

        public List<Produto> ObterTodos()
        {
            return repositorioProduto.ObterTodos();
        }
    }
}
