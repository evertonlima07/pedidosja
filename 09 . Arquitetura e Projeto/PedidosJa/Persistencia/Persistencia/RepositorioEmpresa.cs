using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistencia
{
    public class RepositorioEmpresa
    {
        private static List<Empresa> listaEmpresa;

        static RepositorioEmpresa()
        {
            listaEmpresa = new List<Empresa>();
            
<<<<<<< .mine






















=======

            Empresa empresa1 = new Empresa();
            empresa1.Id = 1;
            empresa1.Nome = "Itatech Jr.";
            empresa1.Endereco = "Rua A";
            empresa1.Telefone = "79998397106";
            empresa1.Login = "itetech";
            empresa1.Senha = "itatech";
            empresa1.Funcionamento = "ABERTO";

            listaEmpresa.Add(empresa1);

            Empresa empresa2 = new Empresa();
            empresa2.Id = 2;
            empresa2.Nome = "Daniel Tech";
            empresa2.Endereco = "Rua B";
            empresa2.Telefone = "79998397106";
            empresa2.Login = "daniel";
            empresa2.Senha = "daniel";
            empresa2.Funcionamento = "ABERTO";

            listaEmpresa.Add(empresa2);
>>>>>>> .theirs
        }

        public Empresa Adicionar(Empresa empresa)
        {
            empresa.Id = listaEmpresa.Count + 1;
            listaEmpresa.Add(empresa);
            return empresa;
        }

        public void Editar(Empresa empresa)
        {
            int posicao = listaEmpresa.FindIndex(e => e.Id == empresa.Id);
            listaEmpresa[posicao] = empresa;
        }

        public void Remover(Empresa empresa)
        {
            int posicao = listaEmpresa.FindIndex(e => e.Id == empresa.Id);
            listaEmpresa.RemoveAt(posicao);
        }

        public Empresa Obter(Func<Empresa, bool> where)
        {
            return listaEmpresa.Where(where).FirstOrDefault();
        }

        public List<Empresa> ObterTodos()
        {
            return listaEmpresa;
        }
    }
}
