using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    class Produto
    {
        private int id;
        private string nome;
        private float preco;
        private Empresa empresa;
        private List<ProdutoComplemento> listaComplemento;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public float Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public Empresa empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public List<ProdutoComplemento> ListaComplemento
        {
            get { return listaComplemento; }
            set { listaComplemento = value; }
        }
    }
}
