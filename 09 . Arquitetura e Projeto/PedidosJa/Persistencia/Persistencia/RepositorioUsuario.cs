using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistencia
{
    public class RepositorioUsuario
    {
        private static List<Usuario> listaUsuario;

        static RepositorioUsuario()
        {
            listaUsuario = new List<Usuario>();

            Usuario usuario1 = new Usuario();
            usuario1.Id = 1;
            usuario1.Nome = "Daniel Lima";            
            usuario1.Email = "daniel102510@hotmail.com";
            usuario1.Login = "daniellima";
            usuario1.Senha = "daniellima";
            usuario1.Telefone = "79 998397106";

            listaUsuario.Add(usuario1);
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuario.Id = listaUsuario.Count + 1;
            listaUsuario.Add(usuario);
            return usuario;
        }

        public void Editar(Usuario usuario)
        {
            int posicao = listaUsuario.FindIndex(e => e.Id == usuario.Id);
            listaUsuario[posicao] = usuario;
        }

        public void Remover(Usuario usuario)
        {
            int posicao = listaUsuario.FindIndex(e => e.Id == usuario.Id);
            listaUsuario.RemoveAt(posicao);
        }

        public Usuario Obter(Func<Usuario, bool> where)
        {
            return listaUsuario.Where(where).FirstOrDefault();
        }

        public List<Usuario> ObterTodos()
        {
            return listaUsuario;
        }
    }
}
