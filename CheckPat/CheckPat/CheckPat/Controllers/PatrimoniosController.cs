using System.Collections.Generic;
using CheckPat.Models;
using CheckPat.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CheckPat.Controllers
{
    public class PatrimoniosController : Controller
    {
        DataContext db = new DataContext();

        public IActionResult Index()
        {

            var lista = db.Patrimonio.Include(obj => obj.Equipamento).Include(obj => obj.Local).OrderBy(obj => obj.Id).ToList();
            return View(lista);

        }

        //METODOS ADICIONAR

        //Retornará a página de adicionar
        [HttpGet]
        public IActionResult Adicionar()
        {
            var locais = db.Local.ToList();
            var equipamentos = db.Equipamento.ToList();
            var patrimonio = new PatrimonioViewModel { Locais = locais, Equipamentos = equipamentos };
            return View(patrimonio);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Patrimonio patrimonio)
        {
            try
            {
                db.Patrimonio.Add(patrimonio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
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


        // -------------------------------------------------------------------------------

        //METODOS DELETAR

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            try
            {
                db.Patrimonio.Remove(db.Patrimonio.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("ErroDeletar");
            }
        }


        //-------------------------------------------------------------------------------

        //METODOS EDITAR

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objeto = db.Patrimonio.Include(obj => obj.Local).Include(obj => obj.Equipamento).FirstOrDefault(obj => obj.Id == id);
            if (objeto == null)
            {
                return NotFound();
            }

            List<Local> locais = db.Local.OrderBy(x => x.Nome).ToList();
            List<Equipamento> equipamentos = db.Equipamento.OrderBy(x => x.Nome).ToList();
            PatrimonioViewModel viewModel = new PatrimonioViewModel { Patrimonio = objeto, Locais = locais, Equipamentos = equipamentos };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int? id, Patrimonio patrimonio)
        {
            if (id != patrimonio.Id)
            {
                return BadRequest();
            }

            db.Patrimonio.Update(patrimonio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------------------

        //METODOS DETALHES

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return View("ErroDetalhes");
            }

            var objeto = db.Patrimonio.Include(obj => obj.Local).Include(obj => obj.Equipamento).FirstOrDefault(obj => obj.Id == id);
            if (objeto == null)
            {
                return NotFound();
            }
            else
            {
                return View(objeto);
            }
        }

        //-------------------------------------------------------------------------------------
        //METODO Buscar

        [HttpPost]
        public IActionResult Buscar(int? numero)
        {
            if (numero == null)
            {
                List<Patrimonio> patrimonios = db.Patrimonio.Include(obj => obj.Equipamento).Include(obj => obj.Local).OrderBy(x => x.NumeroPatrimonio).OrderBy(obj => obj.Id).ToList();
                return View("Index", patrimonios);
            }
            else
            {
                List<Patrimonio> patrimonios = db.Patrimonio.Include(obj => obj.Equipamento).Include(obj => obj.Local).Where(obj => obj.NumeroPatrimonio.Equals(numero)).ToList();
                return View("Index", patrimonios);
            }
        }
    }
}