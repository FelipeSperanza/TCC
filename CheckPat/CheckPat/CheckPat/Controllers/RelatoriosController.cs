using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckPat.Models;
using CheckPat.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckPat.Controllers
{
    public class RelatoriosController : Controller
    {
        DataContext db = new DataContext();

        [HttpGet]
        public IActionResult Index(string local)
        {
            ViewBag.Local = (from p in db.Patrimonio
                             select p.Local.Nome).Distinct();

            var lista = db.Patrimonio.Include(obj => obj.Equipamento).Include(obj => obj.Local).OrderBy(obj => obj.Id).Where(obj => obj.Local.Nome == local).ToList();
            return View(lista);
        }


    }
}
