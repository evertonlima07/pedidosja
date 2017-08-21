using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    class ComplementoPedido
    {
        private int idComplemento;
        private int idProdutoPedido;

        public int IdProdutoPedido
        {
            get { return idProdutoPedido; }
            set { idProdutoPedido = value; }
        }

        public int IdComplemento
        {
            get { return idComplemento; }
            set { idComplemento = value; }
        }
    }
}
