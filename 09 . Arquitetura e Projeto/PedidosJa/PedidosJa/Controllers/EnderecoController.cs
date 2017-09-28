using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio.Business;
using Model.Models;

namespace PedidosJa.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: Endereco
        public ActionResult ListaDeEnderecos()
        {
            GerenciadoraEndereco ge = new GerenciadoraEndereco();
            Usuario user = (Usuario) Util.SessionHelper.Get(Util.SessionKeys.USUARIO);
            List<Endereco> enderecos = ge.ObterPorUsuario(end => end.Usuario.Id == user.Id);
            return View(enderecos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Endereco endereco)
        {
            GerenciadoraEndereco ge = new GerenciadoraEndereco();

            endereco.Usuario = (Usuario)Util.SessionHelper.Get(Util.SessionKeys.USUARIO);

            ge.Adicionar(endereco);

            return RedirectToAction("ListaDeEnderecos", "Endereco"); ;
        }

        public ActionResult Remover(int id)
        {
            GerenciadoraEndereco ge = new GerenciadoraEndereco();
            Endereco endereco = ge.Obter(end => end.Id == id);
            ge.Remover(endereco);
            return RedirectToAction("ListaDeEnderecos", "Endereco"); ;
        }

        public ActionResult Alterar(int id)
        {
            GerenciadoraEndereco ge = new GerenciadoraEndereco();
            Endereco endereco = ge.Obter(end => end.Id == id);

            return View(endereco);
        }

        [HttpPost]
        public ActionResult Alterar(Endereco endereco)
        {
            GerenciadoraEndereco ge = new GerenciadoraEndereco();

            endereco.Usuario = (Usuario)Util.SessionHelper.Get(Util.SessionKeys.USUARIO);

            ge.Editar(endereco);

            return RedirectToAction("ListaDeEnderecos", "Endereco"); ;
        }
    }
}