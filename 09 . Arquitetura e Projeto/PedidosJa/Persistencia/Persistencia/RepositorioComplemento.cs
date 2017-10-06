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
            listaComplemento = new List<Complemento>();
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

        public List<Complemento> ObterWhere(Func<Complemento, bool> where)
        {
            return listaComplemento.Where(where).ToList();
        }

        public List<Complemento> ObterTodos()
        {
            return listaComplemento;
        }
    }
}
