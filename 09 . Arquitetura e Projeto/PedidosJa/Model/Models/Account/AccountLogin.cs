using System.ComponentModel.DataAnnotations;

namespace Model.Models.Account
{
    public class AccountLogin
    {
        private string login;

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Deve possuir uma quantidade de caracteres entre 5 e 100.")]
        [DataType(DataType.Password)]
        private string senha;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
    }
}
