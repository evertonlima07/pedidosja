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

            RepositorioUsuario ru = new RepositorioUsuario();

            Endereco endereco = new Endereco();
            endereco.Id = 1;
            endereco.Nome = "Rua Francisco Oliveira";
            endereco.Numero = "2723";
            endereco.Cep = "49500000";
            endereco.Complemento = "";
            endereco.Apelido = "Minha casa";
            endereco.Usuario = ru.ObterTodos()[0];
            listaEndereco.Add(endereco);
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

        public List<Endereco> ObterTodos()
        {
            return listaEndereco;
        }
    }
}
