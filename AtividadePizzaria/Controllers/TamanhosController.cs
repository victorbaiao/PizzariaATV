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







    public class TamanhosController : Controller
    {
        private PizzariaDbContext _context;

        public TamanhosController(PizzariaDbContext context)
        {
            _context = context;
        }







        public IActionResult Index()
        {
            return View(_context.Tamanhos);
        }









        public IActionResult Detalhes(int id)
        {
            var resultado = _context.Tamanhos
                .Include(af => af.Pizzas)
                .FirstOrDefault(tamanho => tamanho.Id == id);

            if (resultado == null)
                return View("NotFound");

            return View(resultado);
        }








        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(PostTamanhoVM tamanhoVM)
        {
            if (!ModelState.IsValid)
                return View(tamanhoVM);

            Tamanho tamanho = new Tamanho (tamanhoVM.Nome);
            _context.Tamanhos.Add(tamanho);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }







        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return NotFound();

            var result = _context.Tamanhos.FirstOrDefault(a => a.Id == id);

            if (result == null)
                return View();

            return View(result);
        }










        [HttpPost]
        public IActionResult Atualizar(int id, PostTamanhoVM tamanhoVM)
        {
            var tamanho = _context.Tamanhos.FirstOrDefault(a => a.Id == id);

            if (!ModelState.IsValid)
                return View(tamanho);

            tamanho.AtualizarDados(tamanhoVM.Nome);

            _context.Update(tamanho);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }









        public IActionResult Deletar(int id)
        {
            var result = _context.Tamanhos.FirstOrDefault(a => a.Id == id);

            if (result == null) return View();

            return View(result);
        }









        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Tamanhos.FirstOrDefault(a => a.Id == id);
            _context.Tamanhos.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
