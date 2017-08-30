using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;

namespace Persistencia.Persistencia
{
    class RepositorioComplementoPedido
    {
        private static List<ComplementoPedido> listaComplementoPedido;

        static RepositorioComplementoPedido()
        {
            listaComplementoPedido = new List<ComplementoPedido>();
        }

        public ComplementoPedido Adicionar(ComplementoPedido complementoPedido)
        {
            //complementoPedido.MatriculaUsuario = listaComplementoPedido.Count + 1;
            listaComplementoPedido.Add(complementoPedido);
            return complementoPedido;
        }

        public void Editar(ComplementoPedido complementoPedido)
        {
            //int posicao = listaComplementoPedido.FindIndex((e => e.IdProdutoPedido == complementoPedido.IdProdutoPedido) && (e => e.IdComplemento == complementoPedido.IdComplemento));
            //listaComplementoPedido[posicao] = complementoPedido;
        }

        public void Remover(ComplementoPedido complementoPedido)
        {
            //int posicao = listaComplementoPedido.FindIndex((e => e.IdProdutoPedido == complementoPedido.IdProdutoPedido) && (e => e.IdComplemento == complementoPedido.IdComplemento));
            //listaComplementoPedido.RemoveAt(posicao);
        }

        public ComplementoPedido Obter(Func<ComplementoPedido, bool> where)
        {
            return listaComplementoPedido.Where(where).FirstOrDefault();
        }

        public List<ComplementoPedido> ObterTodos()
        {
            return listaComplementoPedido;
        }
    }
}
