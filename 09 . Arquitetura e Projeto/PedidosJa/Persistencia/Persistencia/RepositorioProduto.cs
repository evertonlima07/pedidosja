using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistencia
{
    public class RepositorioProduto
    {
        private static List<Produto> listaProduto;

        static RepositorioProduto()
        {
            listaProduto = new List<Produto>();
        }

        public Produto Adicionar(Produto produto)
        {
            produto.Id = listaProduto.Count + 1;
            listaProduto.Add(produto);
            return produto;
        }

        public void Editar(Produto produto)
        {
            int i = listaProduto.FindIndex(e => e.Id == produto.Id);
            listaProduto[i] = produto;
        }

        public void Remover(Produto produto)
        {
            int posicao = listaProduto.FindIndex(e => e.Id == produto.Id);
            listaProduto.RemoveAt(posicao);
        }

        public Produto Obter(Func<Produto, bool> where)
        {
            return listaProduto.Where(where).FirstOrDefault();
        }

        public List<Produto> ObterTodosDaEmpresa(Func<Produto, bool> where)
        {
            return listaProduto.Where(where).ToList();
        }

        public List<Produto> ObterTodos()
        {
            return listaProduto;
        }
    }
}
