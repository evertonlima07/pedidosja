using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadoraProdutoComplemento
    {
        RepositorioProdutoComplemento repositorioProdutoComplemento;

        GerenciadoraProdutoComplemento()
        {
            repositorioProdutoComplemento = new RepositorioProdutoComplemento();
        }

        public ProdutoComplemento Adicionar(ProdutoComplemento produtoComplemento)
        {
            return repositorioProdutoComplemento.Adicionar(produtoComplemento);
        }

        public void Editar(ProdutoComplemento produtoComplemento)
        {
            
        }

        public void Remover(ProdutoComplemento produtoComplemento)
        {
         
        }

        public ProdutoComplemento Obter(Func<ProdutoComplemento, bool> where)
        {
            return repositorioProdutoComplemento.Obter(where);
        }

        public List<ProdutoComplemento> ObterTodos()
        {
            return repositorioProdutoComplemento.ObterTodos();
        }
    }
}
