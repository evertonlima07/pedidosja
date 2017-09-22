using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace PedidosJa.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Alterar()
        {
            Usuario user = (Usuario) Util.SessionHelper.Get(Util.SessionKeys.USUARIO);

            return View(user);
        }

        [HttpPost]
        public ActionResult Alterar(Usuario user)
        {
            // Retrieve existing dinner
            GerenciadoraUsuario gu = new GerenciadoraUsuario();
            Usuario usuario = gu.Obter(u => u.Id == user.Id);
            usuario.Nome = user.Nome;
            usuario.Email = user.Email;
            usuario.Telefone = user.Telefone;
            gu.Editar(usuario);

            return RedirectToAction("Index", "Home");
        }
    }
}