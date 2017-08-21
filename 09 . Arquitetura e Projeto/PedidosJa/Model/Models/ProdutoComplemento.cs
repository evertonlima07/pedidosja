using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    class ProdutoComplemento
    {
        private Produto produto;
        private Complemento complemento;

        public Produto Produto
        {
            get { return produto; }
            set { produto = value; }
        }

        public Complemento Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }
    }
}
