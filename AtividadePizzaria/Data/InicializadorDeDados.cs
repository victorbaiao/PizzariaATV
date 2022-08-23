using AtividadePizzaria.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace AtividadePizzaria.Data
{
    public class InicializadorDeDados
    {




        public static void Inicializar(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider
                    .GetService<PizzariaDbContext>();

                context.Database.EnsureCreated();

                if(!context.Sabores.Any())
                {
                    context.Sabores.AddRange(new List<Sabor>() 
                    {
                        new Sabor("Calabresa", "https://www.sabornamesa.com.br/receita-pizza/pizza-de-calabresa-com-cebola"),
                        new Sabor("Portuguesa", "https://pizzariameurancho.com.br/cardapio/pizza-portuguesa/"),
                        new Sabor("Quatro queijos", "https://cybercook.com.br/receitas/lanches/pizzas/receita-de-pizza-pan-4-queijos-122550"),
                    });
                    context.SaveChanges();
                }

                if (!context.Tamanhos.Any())
                {
                    context.Tamanhos.AddRange(new List<Tamanho>()
                    {
                        new Tamanho("Pequena"),
                        new Tamanho("Média"),
                        new Tamanho("Grande") 
                    });
                    context.SaveChanges();
                }

                if (!context.Pizzas.Any())
                {
                    context.Pizzas.AddRange(new List<Pizza>()
                    {
                        new Pizza("Calabresa",30,"https://www.sabornamesa.com.br/receita-pizza/pizza-de-calabresa-com-cebola",1),
                        new Pizza("Portuguesa",40,"https://pizzariameurancho.com.br/cardapio/pizza-portuguesa/",2),
                        new Pizza("Quatro queijos",50,"https://cybercook.com.br/receitas/lanches/pizzas/receita-de-pizza-pan-4-queijos-122550",3)
                    });
                    context.SaveChanges();
                }

                if (!context.PizzasSabores.Any())
                {
                    context.PizzasSabores.AddRange(new List<PizzaSabor>()
                    {
                        new PizzaSabor(1,3),
                        new PizzaSabor(2,4),
                        new PizzaSabor(3,2),
                        new PizzaSabor(1,1),
                        new PizzaSabor(2,1),
                        new PizzaSabor(3,1)
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
