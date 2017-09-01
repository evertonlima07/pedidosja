using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistencia;

namespace Negocio.Business
{
    public class GerenciadoraComplemento
    {
        RepositorioComplemento repositorioComplemento;

        GerenciadoraComplemento()
        {
            repositorioComplemento = new RepositorioComplemento();
        }

        public Complemento Adicionar(Complemento complemento)
        {
            return repositorioComplemento.Adicionar(complemento);
        }

        public void Editar(Complemento complemento)
        {
            repositorioComplemento.Editar(complemento);
        }

        public void Remover(Complemento complemento)
        {
            repositorioComplemento.Remover(complemento);
        }

        public Complemento Obter(Func<Complemento, bool> where)
        {
            return repositorioComplemento.Obter(where); ;
        }

        public List<Complemento> ObterTodos()
        {
            return repositorioComplemento.ObterTodos();
        }
    }
}
