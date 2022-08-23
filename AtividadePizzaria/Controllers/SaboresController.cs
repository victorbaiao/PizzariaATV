using AtividadePizzaria.Data;
using AtividadePizzaria.Models;
using AtividadePizzaria.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadePizzaria.Controllers
{
    public class SaboresController : Controller
    {
        private PizzariaDbContext _context;

        public SaboresController(PizzariaDbContext context)
        {
            _context = context;
        }




        public IActionResult Index()
        {
            return View(_context.Sabores);
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = _context.Sabores
                .Include(af => af.PizzasSabores)
                .ThenInclude(f => f.Pizza)
                .FirstOrDefault(sabor => sabor.Id == id);

            if (resultado == null)
                return View("NotFound");

            return View(resultado);
        }





        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(PostSaborVM saborVM)
        {
            if (!ModelState.IsValid)
                return View(saborVM);

            Sabor sabor = new Sabor (saborVM.Nome, saborVM.FotoURL);
            _context.Sabores.Add(sabor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }




        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return NotFound();

            var result = _context.Sabores.FirstOrDefault(a => a.Id == id);

            if (result == null)
                return View();

            return View(result);
        }






        [HttpPost]
        public IActionResult Atualizar(int id, PostSaborVM saborVM)
        {
            var sabor = _context.Sabores.FirstOrDefault(a => a.Id == id);

            if (!ModelState.IsValid)
                return View(sabor);

            sabor.AtualizarDados(saborVM.Nome, saborVM.FotoURL);

            _context.Update(sabor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }





        public IActionResult Deletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(a => a.Id == id);

            if (result == null) return View();

            return View(result);
        }






        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(a => a.Id == id);
            _context.Sabores.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
