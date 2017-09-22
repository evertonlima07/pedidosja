using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Endereco
    {

        private int idEndereco;
        private string nomeEndereco;
        private string numeroEndereco;
        private string cepEndereco;
        private string complementoEndereco;
        private string apelidoEndereco;
        private Usuario usuario;

        public int Id
        {
            get { return idEndereco; }
            set { idEndereco = value; }
        }

        public string Nome
        {
            get { return nomeEndereco; }
            set { nomeEndereco = value; }
        }

        public string Numero
        {
            get { return numeroEndereco; }
            set { numeroEndereco = value; }
        }

        public string Cep
        {
            get { return cepEndereco; }
            set { cepEndereco = value; }
        }

        public string Complemento
        {
            get { return complementoEndereco; }
            set { complementoEndereco = value; }
        }

        public string Apelido
        {
            get { return apelidoEndereco; }
            set { apelidoEndereco = value; }
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

    }
}
