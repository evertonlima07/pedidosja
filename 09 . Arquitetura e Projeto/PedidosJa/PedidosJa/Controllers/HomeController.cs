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
            
            return View();
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
            empresa1.Nome = "Itatech Jr.";
            empresa1.Telefone = "79998397106";
            empresa1.Login = "itatechjr";
            empresa1.Senha = "ita";
            empresa1.Funcionamento = "ABERTO";
            
            gEmp.Adicionar(empresa1);

            Empresa empresa2 = new Empresa();
            empresa2.Nome = "Daniel Tech";
            empresa2.Telefone = "79998397106";
            empresa2.Login = "daniel";
            empresa2.Senha = "daniel";
            empresa2.Funcionamento = "ABERTO";

            gEmp.Adicionar(empresa2);

            //CRIANDO USUARIOS
            Usuario usuario1 = new Usuario();
            usuario1.Nome = "Daniel Lima";
            usuario1.Email = "daniel102510@hotmail.com";
            usuario1.Login = "daniellima";
            usuario1.Senha = "daniellima";
            usuario1.Telefone = "79 998397106";

            gUser.Adicionar(usuario1);

            //CRIANDO ENDERECOS
            Endereco endereco = new Endereco();
            endereco.Nome = "Rua Francisco Oliveira";
            endereco.Numero = "2723";
            endereco.Cep = "49500000";
            endereco.Complemento = "";
            endereco.Apelido = "Minha casa";
            endereco.Usuario = gUser.Obter(u => u.Id == 1);

            gEnd.Adicionar(endereco);

            //CRIANDO COMPLEMENTOS
            Complemento c1 = new Complemento();
            c1.Descricao = "Milho";
            c1.Empresa = gEmp.Obter(e => e.Id == 1);
            gComp.Adicionar(c1);


            Complemento c2 = new Complemento();
            c2.Descricao = "Katchup";
            c2.Empresa = gEmp.Obter(e => e.Id == 1);
            gComp.Adicionar(c2);

            Complemento c3 = new Complemento();
            c3.Descricao = "Guardanapo";
            c3.Empresa = gEmp.Obter(e => e.Id == 2);
            gComp.Adicionar(c3);

            //CRIANDO PRODUTOS
            Produto produto1 = new Produto();
            produto1.Nome = "Coca Cola 1L";
            produto1.Preco = 5.20f;
            produto1.Empresa = gEmp.Obter(e => e.Id == 1);
            produto1.ListaComplemento = new List<Complemento>();
            produto1.ListaComplemento.Add(gComp.Obter(c => c.Id == 1));

            gProd.Adicionar(produto1);

            Produto produto2 = new Produto();
            produto2.Nome = "X Frango";
            produto2.Preco = 8.00f;
            produto1.Empresa = gEmp.Obter(e => e.Id == 1);
            produto2.ListaComplemento = new List<Complemento>();

            gProd.Adicionar(produto2);


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

            Pedido pedido2 = new Pedido();
            pedido2.Empresa = gEmp.Obter(e => e.Id == 1);
            pedido2.EnderecoUsuario = "Rua Quintino de Lacerda";
            pedido2.DescricaoPagamento = "Cartão";
            pedido2.TelefoneUsuario = "79 998397106";
            pedido2.NomeUsuario = "Daniel Lima";
            pedido2.Situacao = "A fazer";
            pedido2.Usuario = gUser.Obter(u => u.Id == 1);
            pedido2.Data = DateTime.Now;

            gPed.Adicionar(pedido2);

        }

    }
}