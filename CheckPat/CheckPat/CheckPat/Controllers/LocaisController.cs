using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckPat.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckPat.Controllers
{
    public class LocaisController : Controller
    {
        DataContext db = new DataContext();

        public IActionResult Index()
        {

            var lista = db.Local.OrderBy(x => x.Id).ToList();
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
        public IActionResult Adicionar(Local local)
        {
            try
            {
                db.Local.Add(local);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Erro");
            }
        }

        //---------------------------------------------------------------------------------------

        //METODO DE ERRO

        public IActionResult Erro()
        {
            return View("Erro");
        }

        public IActionResult ErroDeletar()
        {
            return View("ErroDeletar");
        }

        //---------------------------------------------------------------------------------------

        //METODOS DELETAR

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            try
            {
                db.Local.Remove(db.Local.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
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
            return View(db.Local.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Local local)
        {
            db.Update(local);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------------------

        //METODOS Detalhes

        public IActionResult Detalhes(int id)
        {

            var obj = db.Local.Find(id);
            if (obj == null)
            {
                return View("ErroDetalhes");
            }
            else
            {
                return View(obj);
            }
        }

        //-------------------------------------------------------------------------------------
        //METODO Buscar

        [HttpPost]
        public IActionResult Buscar(string nome)
        {
            if (nome == null)
            {
                List<Local> locais = db.Local.OrderBy(x => x.Nome).OrderBy(obj => obj.Id).ToList();
                return View("Index", locais);

            }
            else
            {
                List<Local> locais = db.Local.Where(obj => obj.Nome.Contains(nome)).ToList();
                return View("Index", locais);
            }
        }
    }
}
