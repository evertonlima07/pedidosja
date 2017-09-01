using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadoraUsuario
    {
        RepositorioUsuario repositorioCliente;

        GerenciadoraUsuario()
        {
            repositorioCliente = new RepositorioUsuario();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            return repositorioCliente.Adicionar(usuario);
        }

        public void Editar(Usuario usuario)
        {
            repositorioCliente.Editar(usuario);
        }

        public void Remover(Usuario usuario)
        {
            repositorioCliente.Remover(usuario);
        }

        public Usuario Obter(Func<Usuario, bool> where)
        {
            return repositorioCliente.Obter(where);
        }

        public List<Usuario> ObterTodos()
        {
            return repositorioCliente.ObterTodos();
        }
    }
}
