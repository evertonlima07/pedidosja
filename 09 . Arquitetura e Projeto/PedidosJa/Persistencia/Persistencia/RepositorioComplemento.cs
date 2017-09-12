using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;

namespace Persistencia.Persistencia
{
    public class RepositorioComplemento
    {
        private static List<Complemento> listaComplemento;

        static RepositorioComplemento()
        {
            RepositorioEmpresa re = new RepositorioEmpresa();
            listaComplemento = new List<Complemento>();

            Complemento c1 = new Complemento();
            c1.Id = 1;
            c1.Descricao = "Milho";
            c1.Empresa = re.ObterTodos()[0];
            listaComplemento.Add(c1);

            Complemento c2 = new Complemento();
            c2.Id = 2;
            c2.Descricao = "Katchup";
            c2.Empresa = re.ObterTodos()[0];
            listaComplemento.Add(c2);

            Complemento c3 = new Complemento();
            c3.Id = 3;
            c3.Descricao = "Guardanapo";
            c3.Empresa = re.ObterTodos()[1];
            listaComplemento.Add(c3);

        }

        public Complemento Adicionar(Complemento complemento)
        {
            complemento.Id = listaComplemento.Count + 1;
            listaComplemento.Add(complemento);
            return complemento;
        }

        public void Editar(Complemento complemento)
        {
            int posicao = listaComplemento.FindIndex(e => e.Id == complemento.Id);
            listaComplemento[posicao] = complemento;
        }

        public void Remover(Complemento complemento)
        {
            int posicao = listaComplemento.FindIndex(e => e.Id == complemento.Id);
            listaComplemento.RemoveAt(posicao);
        }

        public Complemento Obter(Func<Complemento, bool> where)
        {
            return listaComplemento.Where(where).FirstOrDefault();
        }

        public List<Complemento> ObterPorEmpresa(Func<Complemento, bool> where)
        {
            return listaComplemento.Where(where).ToList();
        }

        public List<Complemento> ObterTodos()
        {
            return listaComplemento;
        }
    }
}
