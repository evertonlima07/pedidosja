using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadoraEndereco
    {
        RepositorioEndereco repositorioEndereco;

        GerenciadoraEndereco()
        {
            repositorioEndereco = new RepositorioEndereco();
        }

        public Endereco Adicionar(Endereco endereco)
        {
            return repositorioEndereco.Adicionar(endereco);
        }

        public void Editar(Endereco endereco)
        {
            repositorioEndereco.Editar(endereco);
        }

        public void Remover(Endereco endereco)
        {
            repositorioEndereco.Remover(endereco);
        }

        public Endereco Obter(Func<Endereco, bool> where)
        {
            return repositorioEndereco.Obter(where);
        }

        public List<Endereco> ObterTodos()
        {
            return repositorioEndereco.ObterTodos();
        }
    }
}
