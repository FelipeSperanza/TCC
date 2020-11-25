using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckPat.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CheckPat.Controllers
{
    public class EquipamentosController : Controller
    {
        DataContext db = new DataContext();

        public IActionResult Index()
        {

            var lista = db.Equipamento.OrderBy(x => x.Id).ToList();
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
        public IActionResult Adicionar(Equipamento equipamento)
        {
            try
            {
                db.Equipamento.Add(equipamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Erro");
            }
        }

        //---------------------------------------------------------------------------------------

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



        //---------------------------------------------------------------------------------------

        //METODOS DELETAR

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            try
            {
                db.Equipamento.Remove(db.Equipamento.Find(id));
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
            return View(db.Equipamento.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Equipamento equipamento)
        {
            db.Update(equipamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------------------

        //METODOS Detalhes

        public IActionResult Detalhes(int id)
        {
            var obj = db.Equipamento.Find(id);
            if (obj == null)
            {
                return View("ErroDetalhes");
            }
            else
            {
                return View(obj);
            }
        }

        //METODO Buscar
        [HttpPost]
        public IActionResult Buscar(string nome)
        {
            if (nome == null)
            {
                List<Equipamento> equipamentos = db.Equipamento.OrderBy(x => x.Nome).OrderBy(obj => obj.Id).ToList();
                return View("Index", equipamentos);

            }
            else
            {
                List<Equipamento> equipamentos = db.Equipamento.Where(obj => obj.Nome.Contains(nome)).OrderBy(obj => obj.Id).ToList();
                return View("Index", equipamentos);
            }
        }
    }
}
