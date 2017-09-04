using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Usuario
    {
        private int id;
        private string nome;
        private string endereco;
        private string email;
        private string login;
        private string senha;
        private string telefone;

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

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Senha
        {
            get { return senha; }
            set { senha= value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
    }
}
