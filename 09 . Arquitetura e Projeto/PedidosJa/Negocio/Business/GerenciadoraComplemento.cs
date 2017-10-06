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

        public GerenciadoraComplemento()
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

        public List<Complemento> ObterPorEmpresa(Func<Complemento, bool> where)
        {
            return repositorioComplemento.ObterPorEmpresa(where);
        }

        public List<Complemento> ObterWhere(Func<Complemento, bool> where)
        {
            return repositorioComplemento.ObterWhere(where);
        }

        public List<Complemento> ObterTodos()
        {
            return repositorioComplemento.ObterTodos();
        }

        public static bool Existe(Complemento c, List<Complemento> lista)
        {
            foreach (var comp in lista)
            {
                if (c.Id == comp.Id) return true;
            }

            return false;
        }
    }
}
