using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistencia
{
    public class RepositorioEndereco
    {
        private static List<Endereco> listaEndereco;

        static RepositorioEndereco()
        {
            listaEndereco = new List<Endereco>();
        }

        public Endereco Adicionar(Endereco endereco)
        {
            endereco.Id = listaEndereco.Count + 1;
            listaEndereco.Add(endereco);
            return endereco;
        }

        public void Editar(Endereco endereco)
        {
            int posicao = listaEndereco.FindIndex(e => e.Id == endereco.Id);
            listaEndereco[posicao] = endereco;
        }

        public void Remover(Endereco endereco)
        {
            int posicao = listaEndereco.FindIndex(e => e.Id == endereco.Id);
            listaEndereco.RemoveAt(posicao);
        }

        public Endereco Obter(Func<Endereco, bool> where)
        {
            return listaEndereco.Where(where).FirstOrDefault();
        }

        public List<Endereco> ObterPorUsuario(Func<Endereco, bool> where)
        {
            return listaEndereco.Where(where).ToList();
        }

        public List<Endereco> ObterTodos()
        {
            return listaEndereco;
        }
    }
}
