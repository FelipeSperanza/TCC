using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using CheckPat.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckPat.Controllers
{
    public class UsuariosController : Controller
    {

        DataContext db = new DataContext();

        public IActionResult Index()
        {

            var lista = db.Usuario.OrderBy(x => x.Id).ToList();
            return View(lista);

        }

        //-------------------------------------------------------------------------------

        //METODOS ADICIONAR

        //Retornará a página de adicionar
        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Usuario usuario)
        {
            try
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index", "Manutencoes");
            }
            catch(Exception)
            {
                return RedirectToAction("Erro");

            }
        }

        // ---------------------------------------------------------------------------

        //METODOS DE ERROS

        public IActionResult Erro()
        {
            return View("Erro");
        }

        public IActionResult ErroDeletar()
        {
            return View("ErroDeletar");
        }
        public IActionResult ErroDetalhes()
        {
            return View("ErroDetalhes");
        }



        //METODOS DELETAR

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            try { 
            db.Usuario.Remove(db.Usuario.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("ErroDeletar");
            }
        }
    

        //-------------------------------------------------------------------------------

        //METODOS EDITAR

        //Retornara a página de edição
        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(db.Usuario.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Usuario usuario)
        {
            db.Update(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------------------

        //METODOS Detalhes

        public IActionResult Detalhes(int id)
        {

            var obj = db.Usuario.Find(id);
            if (obj == null)
            {
                return View("ErroDetalhes");
            }
            else
            {
                return View(obj);
            }
        }

        //-------------------------------------------------------------------------------

        //METODO Buscar
        [HttpPost]
        public IActionResult Buscar(string nome)
        {
            if(nome == null)
            {
                List<Usuario> usuarios = db.Usuario.OrderBy(x => x.Nome).OrderBy(obj => obj.Id).ToList();
                return View("Index", usuarios);

            }
            else
            {
                List<Usuario> usuarios = db.Usuario.Where(obj => obj.Nome.Contains(nome)).ToList();
                return View("Index", usuarios);
            }
        }
    }
}
