using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Produto
    {
        private int id;
        private string nome;
        private float preco;
        private Empresa empresa;
        private List<Complemento> listaComplemento;

        //ATRIBUTO SERÁ UTILIZADO EM VIEW DE DETALHE DE PEDIDO
        private string complementosFormatados;

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

        public Empresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public List<Complemento> ListaComplemento
        {
            get { return listaComplemento; }
            set { listaComplemento = value; }
        }

        public string ComplementosFormatados
        {
            get { return complementosFormatados; }
            set { complementosFormatados = value; }
        }
    }
}
