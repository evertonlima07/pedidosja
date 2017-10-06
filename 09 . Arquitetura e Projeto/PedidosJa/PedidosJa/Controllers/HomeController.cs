using System.Web.Mvc;
using PedidosJa.Util;
using Model.Models;
using Negocio.Business;
using System.Collections.Generic;
using System;

namespace PedidosJa.Controllers
{
    public class HomeController : Controller
    {
        static int vez = 0;

        public ActionResult Index()
        {
            //LOGIN AQUI
            //ESSE CÓDIGO SERÁ USADO NO LOGOFF
            SessionHelper.Set(SessionKeys.USUARIO, null);
            SessionHelper.Set(SessionKeys.EMPRESA, null);
            SessionHelper.Set(SessionKeys.TIPO_USER, null);

            if (vez == 0) buildBanco();

            return RedirectToAction("Login", "Login");
        }

        public ActionResult Usuario()
        {
            return RedirectToAction("ListaDeEmpresas", "Empresa");
        }

        public ActionResult Empresa()
        {
            return RedirectToAction("ListaDePedidos", "Pedido");
        }

        public void buildBanco()
        {
            vez++;

            GerenciadoraEmpresa gEmp = new GerenciadoraEmpresa();
            GerenciadoraUsuario gUser = new GerenciadoraUsuario();
            GerenciadoraEndereco gEnd = new GerenciadoraEndereco();
            GerenciadoraComplemento gComp = new GerenciadoraComplemento();
            GerenciadoraProduto gProd = new GerenciadoraProduto();
            GerenciadoraPedido gPed = new GerenciadoraPedido();

            //CRIANDO EMPRESAS
            Empresa empresa1 = new Empresa();
            empresa1.Nome = "Mamata Lanches";
            empresa1.Telefone = "79998397106";
            empresa1.Login = "mamata";
            empresa1.Senha = "mamata";
            empresa1.Funcionamento = "ABERTO";

            gEmp.Adicionar(empresa1);

            Empresa empresa2 = new Empresa();
            empresa2.Nome = "Marilene";
            empresa2.Telefone = "79998397106";
            empresa2.Login = "marilene";
            empresa2.Senha = "marilene";
            empresa2.Funcionamento = "ABERTO";

            gEmp.Adicionar(empresa2);

            Empresa empresa3 = new Empresa();
            empresa3.Nome = "Ita Lanches tech Jr.";
            empresa3.Telefone = "79998397106";
            empresa3.Login = "itatech";
            empresa3.Senha = "itatech";
            empresa3.Funcionamento = "ABERTO";

            gEmp.Adicionar(empresa3);

            //CRIANDO USUARIOS
            Usuario usuario1 = new Usuario();
            usuario1.Nome = "Daniel Lima";
            usuario1.Email = "daniel102510@hotmail.com";
            usuario1.Login = "daniel";
            usuario1.Senha = "daniel";
            usuario1.Telefone = "79 998397106";

            gUser.Adicionar(usuario1);
        
            
            Usuario usuario2 = new Usuario();
            usuario2.Nome = "Everton Lima";
            usuario2.Email = "everton.lima07@hotmail.com";
            usuario2.Login = "everton";
            usuario2.Senha = "everton";
            usuario2.Telefone = "79 998962288";

            gUser.Adicionar(usuario2);
            
            //CRIANDO ENDERECOS
            Endereco endereco = new Endereco();
            endereco.Nome = "Rua Francisco Oliveira";
            endereco.Numero = "2723";
            endereco.Cep = "49500000";
            endereco.Complemento = "";
            endereco.Apelido = "Minha casa";
            endereco.Usuario = gUser.Obter(u => u.Id == 1);

            gEnd.Adicionar(endereco);
            
            Endereco endereco2 = new Endereco();
            endereco2.Nome = "Av. Antonio Cornelio da Fonseca";
            endereco2.Numero = "205";
            endereco2.Cep = "49500810";
            endereco2.Complemento = "Proximo a UFS";
            endereco2.Apelido = "Casa";
            endereco2.Usuario = gUser.Obter(u => u.Id == 2);

            gEnd.Adicionar(endereco2);
            
            Endereco endereco3 = new Endereco();
            endereco3.Nome = "Av. Vereador Olímpio Grande";
            endereco3.Numero = "S/N";
            endereco3.Cep = "49500810";
            endereco3.Complemento = "UFS, Bloco A, Itatech Jr.";
            endereco3.Apelido = "Itatech";
            endereco3.Usuario = gUser.Obter(u => u.Id == 1);

            gEnd.Adicionar(endereco3);

            //CRIANDO COMPLEMENTOS
            Complemento c1 = new Complemento();
            c1.Descricao = "Milho";
            c1.Empresa = gEmp.Obter(e => e.Id == 1);
            gComp.Adicionar(c1);


            Complemento c2 = new Complemento();
            c2.Descricao = "Ervilha";
            c2.Empresa = gEmp.Obter(e => e.Id == 1);
            gComp.Adicionar(c2);

            Complemento c3 = new Complemento();
            c3.Descricao = "Batata Palha";
            c3.Empresa = gEmp.Obter(e => e.Id == 1);
            gComp.Adicionar(c3);
            
            Complemento c4 = new Complemento();
            c4.Descricao = "Katchup";
            c4.Empresa = gEmp.Obter(e => e.Id == 1);
            gComp.Adicionar(c4);

            Complemento c5 = new Complemento();
            c5.Descricao = "Maionese";
            c5.Empresa = gEmp.Obter(e => e.Id == 1);
            gComp.Adicionar(c4);
            
            //CRIANDO PRODUTOS
            Produto produto1 = new Produto();
            produto1.Nome = "X Mamata";
            produto1.Preco = 5.20f;
            produto1.Empresa = empresa1;
            produto1.ListaComplemento = new List<Complemento>();
            produto1.ListaComplemento.Add(gComp.Obter(c => c.Id == 1));

            gProd.Adicionar(produto1);
            
            Produto produto2 = new Produto();
            produto2.Nome = "Cachorro quente";
            produto2.Preco = 3.50f;
            produto2.Empresa = empresa1;
            produto2.ListaComplemento = new List<Complemento>();

            gProd.Adicionar(produto2);
            
            Produto produto3 = new Produto();
            produto3.Nome = "X Frango";
            produto3.Preco = 8.00f;
            produto3.Empresa = empresa1;
            produto3.ListaComplemento = new List<Complemento>();

            gProd.Adicionar(produto3);

            Produto produto4 = new Produto();
            produto4.Nome = "Lasanha Molho Branco";
            produto4.Preco = 6.00f;
            produto4.Empresa = empresa1;
            produto4.ListaComplemento = new List<Complemento>();

            gProd.Adicionar(produto4);

            Produto produto5 = new Produto();
            produto5.Nome = "Lasanha Molho Tradicional";
            produto5.Preco = 6.00f;
            produto5.Empresa = empresa1;
            produto5.ListaComplemento = new List<Complemento>();

            gProd.Adicionar(produto5);

            Produto produto6 = new Produto();
            produto6.Nome = "Água 500ml";
            produto6.Preco = 2.50f;
            produto6.Empresa = empresa1;
            produto6.ListaComplemento = new List<Complemento>();

            gProd.Adicionar(produto6);
            
            Produto produto7 = new Produto();
            produto7.Nome = "Coca Cola 1L";
            produto7.Preco = 5.50f;
            produto7.Empresa = empresa1;
            produto7.ListaComplemento = new List<Complemento>();

            gProd.Adicionar(produto7);

            //CRIANDO PEDIDOS
            Pedido pedido1 = new Pedido();
            pedido1.Empresa = gEmp.Obter(e => e.Id == 1);
            pedido1.EnderecoUsuario = "Rua Francisco Oliveira";
            pedido1.DescricaoPagamento = "A vista, troco para 50";
            pedido1.TelefoneUsuario = "79 998397106";
            pedido1.NomeUsuario = "Daniel Lima";
            pedido1.Situacao = "A fazer";
            pedido1.ListaProdutos = new List<Produto>();
            pedido1.Usuario = gUser.Obter(u => u.Id == 1);
            pedido1.ListaProdutos.Add(gProd.Obter(p => p.Id == 1));
            pedido1.Data = DateTime.Now;

            gPed.Adicionar(pedido1);
            /*
            Pedido pedido2 = new Pedido();
            pedido2.Empresa = gEmp.Obter(e => e.Id == 1);
            pedido2.EnderecoUsuario = "Rua Quintino de Lacerda";
            pedido2.DescricaoPagamento = "Cartão";
            pedido2.TelefoneUsuario = "79 998397106";
            pedido2.NomeUsuario = "Daniel Lima";
            pedido2.Situacao = "A fazer";
            pedido2.Usuario = gUser.Obter(u => u.Id == 1);
            pedido2.ListaProdutos.Add(gProd.Obter(p => p.Id == 2));
            pedido2.Data = DateTime.Now;

            gPed.Adicionar(pedido2);
            */
        }

    }
}