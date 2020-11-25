using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CheckPat.Models;
using CheckPat.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckPat.Controllers
{
    public class ManutencoesController : Controller
    {
        DataContext db = new DataContext();

        public IActionResult Index()
        {
            var lista = db.Patrimonio.Include(obj => obj.Equipamento).Include(obj => obj.Local).Where(obj => obj.Manutencao == true).OrderBy(obj => obj.Local).ToList();
            return View(lista);
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

            List<Local> locais = db.Local.OrderBy(x => x.Nome).OrderBy(obj => obj.Id).ToList();
            List<Equipamento> equipamentos = db.Equipamento.OrderBy(x => x.Nome).OrderBy(obj => obj.Id).ToList();
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

        //METODOS LOGIN

        [HttpGet]
        public IActionResult Login()
        {

            return View("login");
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            ViewBag.login = db.Usuario.Where(x => x.Login.Equals(login) && x.Senha.Equals(senha)).FirstOrDefault();

            if (ViewBag.login != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = "Dados incorretos!!";
                return View("login");
            }
        }

        //-------------------------------------------------------------------------------------
        //METODO Buscar

        [HttpPost]
        public IActionResult Buscar(int? numero)
        {
            if (numero == null)
            {
                List<Patrimonio> patrimonios = db.Patrimonio.Include(obj => obj.Equipamento).Include(obj => obj.Local).OrderBy(x => x.NumeroPatrimonio).Where(obj => obj.Manutencao == true).OrderBy(obj => obj.Id).ToList();
                return View("Index", patrimonios);
            }
            else
            {
                List<Patrimonio> patrimonios = db.Patrimonio.Include(obj => obj.Equipamento).Include(obj => obj.Local).Where(obj => obj.NumeroPatrimonio.Equals(numero) && obj.Manutencao == true).ToList();
                return View("Index", patrimonios);
            }
        }
    }
}



