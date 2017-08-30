using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Pedido
    {
        private int id;
        private Empresa empresa;
        private string enderecoUsuario;
        private string descricaoPagamento;
        private string telefoneUsuario;
        private string nomeUsuario;
        private string situacao; //feito / a fazer
        private Usuario usuario;
        private List<ProdutoPedido> listaProdutos;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Empresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public string EnderecoUsuario
        {
            get { return enderecoUsuario; }
            set { enderecoUsuario = value; }
        }

        public string DescricaoPagamento
        {
            get { return descricaoPagamento; }
            set { descricaoPagamento = value; }
        }

        public string TelefoneUsuario
        {
            get { return telefoneUsuario; }
            set { telefoneUsuario = value; }
        }

        public string NomeUsuario
        {
            get { return nomeUsuario; }
            set { nomeUsuario = value; }
        }

        public string Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public List<ProdutoPedido> ListaProdutos
        {
            get { return listaProdutos; }
            set { listaProdutos = value; }
        }
    }
}
