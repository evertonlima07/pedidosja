using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    class ProdutoPedido
    {
        private int idProdutoPedido;
        private Produto produtoEmpresa;
        private Pedido pedido;
        private List<Complemento> listaComplementos;

        public int IdProdutoPedido
        {
            get { return idProdutoPedido; }
            set { idProdutoPedido = value; }
        }

        public Produto ProdutoEmpresa
        {
            get { return produtoEmpresa; }
            set { produtoEmpresa = value; }
        }

        public Pedido Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }

        public List<Complemento> ListaComplementos
        {
            get { return listaComplementos; }
            set { listaComplementos = value; }
        }
    }
}
