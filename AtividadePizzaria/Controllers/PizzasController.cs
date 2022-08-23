using AtividadePizzaria.Data;
using AtividadePizzaria.Models;
using AtividadePizzaria.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AtividadePizzaria.Controllers
{




    public class PizzasController : Controller
    {
        private PizzariaDbContext _context;




        public PizzasController(PizzariaDbContext context)
        {
            _context = context;
        }





        public IActionResult Index() => View(_context.Pizzas);




        public IActionResult Criar()
        {
            DadosDropdown();

            return View();
        }







        [HttpPost]
        public IActionResult Criar(PostPizzaVM pizzaVM)
        {
            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View();
            }

            Pizza pizza = new Pizza
                (
                    pizzaVM.Nome,
                    pizzaVM.Preco,
                    pizzaVM.FotoURL,
                    pizzaVM.TamanhoId
               

           

                ) ; 

            _context.Add(pizza);
            _context.SaveChanges();

            foreach (var saborId in pizzaVM.SaboresId)
            {
                var novoSabor = new PizzaSabor(pizza.Id, saborId);
                _context.PizzasSabores.Add(novoSabor);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }








        public IActionResult Atualizar(int id)
        {
            var result = _context.Pizzas
                .Include(x => x.PizzasSabores).ThenInclude(x => x.Sabor)
                .FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            var response = new PostPizzaVM()
            {
                Nome = result.Nome,
                Preco = result.Preco,
                FotoURL = result.FotoURL,
                TamanhoId = result.TamanhoId,
                SaboresId = result.PizzasSabores.Select(x => x.SaborId).ToList(),
      
            };

            DadosDropdown();
            return View(response);
        }

        [HttpPost, ActionName("Atualizar")]







        public IActionResult Atualizar(int id, PostPizzaVM pizzaVM)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View(result);
            }

            result.AtualizarDados
                (
                pizzaVM.Nome,
                pizzaVM.Preco,
                pizzaVM.FotoURL,
                pizzaVM.TamanhoId
               
                );

            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), result);
        }







        public IActionResult Deletar(int id)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }






        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }







        public IActionResult Detalhes(int id)
        {
            var result = _context.Pizzas
                .Include(t => t.Tamanho)
                .Include(fc => fc.PizzasSabores).ThenInclude(c => c.Sabor)
                .FirstOrDefault(f => f.Id == id);

            return View(result);
        }









        public void DadosDropdown()
        {
            var resp = new PostPizzaDropdownVM()
            {
                Sabores = _context.Sabores.OrderBy(x => x.Nome).ToList(),
                Tamanhos = _context.Tamanhos.OrderBy(x => x.Nome).ToList(),
                
            };

            ViewBag.Tamanhos = new SelectList(resp.Tamanhos, "Id", "Nome");
            ViewBag.Sabores = new SelectList(resp.Sabores, "Id", "Nome");
   
        }

        
    }
}
