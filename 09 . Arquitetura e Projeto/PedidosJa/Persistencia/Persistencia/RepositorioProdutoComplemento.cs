using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistencia
{
    public class RepositorioProdutoComplemento
    {
        private static List<ProdutoComplemento> listaProdutoComplemento;

        static RepositorioProdutoComplemento()
        {
            listaProdutoComplemento = new List<ProdutoComplemento>();
        }

        public ProdutoComplemento Adicionar(ProdutoComplemento produtoComplemento)
        {
            //produtoComplemento.MatriculaUsuario = listaComplementoPedido.Count + 1;
            listaProdutoComplemento.Add(produtoComplemento);
            return produtoComplemento;
        }

        public void Editar(ProdutoComplemento produtoComplemento)
        {
            //int posicao = listaProdutoComplemento.FindIndex((e => e.Produto == produtoComplemento.Produto) && (e => e.Complemento == produtoComplemento.Complemento));
            //listaProdutoComplemento[posicao] = produtoComplemento;
        }

        public void Remover(ProdutoComplemento produtoComplemento)
        {
            //int posicao = listaProdutoComplemento.FindIndex((e => e.Produto == produtoComplemento.Produto) && (e => e.Complemento == produtoComplemento.Complemento));
            //listaProdutoComplemento.RemoveAt(posicao);
        }

        public ProdutoComplemento Obter(Func<ProdutoComplemento, bool> where)
        {
            return listaProdutoComplemento.Where(where).FirstOrDefault();
        }

        public List<ProdutoComplemento> ObterTodos()
        {
            return listaProdutoComplemento;
        }
    }
}
