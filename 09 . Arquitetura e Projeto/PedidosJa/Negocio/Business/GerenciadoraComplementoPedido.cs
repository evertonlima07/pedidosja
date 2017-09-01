using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadoraComplementoPedido
    {
        RepositorioComplementoPedido repositorioComplementoPedido;

        GerenciadoraComplementoPedido()
        {
            repositorioComplementoPedido = new RepositorioComplementoPedido();
        }

        public ComplementoPedido Adicionar(ComplementoPedido complementoPedido)
        {
            return repositorioComplementoPedido.Adicionar(complementoPedido); ;
        }

        public void Editar(ComplementoPedido complementoPedido)
        {
            
        }

        public void Remover(ComplementoPedido complementoPedido)
        {
            
        }

        public ComplementoPedido Obter(Func<ComplementoPedido, bool> where)
        {
            return repositorioComplementoPedido.Obter(where);
        }

        public List<ComplementoPedido> ObterTodos()
        {
            return repositorioComplementoPedido.ObterTodos();
        }
    }
}
