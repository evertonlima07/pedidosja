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

            RepositorioEmpresa re = new RepositorioEmpresa();
            RepositorioComplemento rc = new RepositorioComplemento();

            Produto produto1 = new Produto();
            produto1.Id = 1;
            produto1.Nome = "Coca Cola 1L";
            produto1.Preco = 5.20f;
            produto1.Empresa = re.ObterTodos()[0];
            produto1.ListaComplemento = new List<ProdutoComplemento>();
            ProdutoComplemento pc = new ProdutoComplemento();
            pc.Produto = produto1;
            pc.Complemento = rc.ObterTodos()[1];
            produto1.ListaComplemento.Add(pc);
            listaProduto.Add(produto1);

            Produto produto2 = new Produto();
            produto2.Id = 2;
            produto2.Nome = "X Frango";
            produto2.Preco = 8.00f;
            produto2.Empresa = re.ObterTodos()[0];
            produto2.ListaComplemento = new List<ProdutoComplemento>();
            listaProduto.Add(produto2);
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
