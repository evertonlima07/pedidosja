using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadoraEmpresa
    {
        RepositorioEmpresa repositorioEmpresa;

        public GerenciadoraEmpresa() {
            repositorioEmpresa = new RepositorioEmpresa();
        }

        public Empresa Adicionar(Empresa empresa)
        {
            return repositorioEmpresa.Adicionar(empresa);
        }

        public void Editar(Empresa empresa)
        {
            repositorioEmpresa.Editar(empresa);
        }

        public void Remover(Empresa empresa)
        {
            repositorioEmpresa.Remover(empresa);
        }

        public Empresa Obter(Func<Empresa, bool> where)
        {
            return repositorioEmpresa.Obter(where);
        }

        public List<Empresa> ObterTodos()
        {
            return repositorioEmpresa.ObterTodos();
        }
    }
}
