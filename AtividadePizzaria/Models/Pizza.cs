using AtividadePizzaria.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtividadePizzaria.Models
{
    public class Pizza : IEntidade
    {
        public Pizza(string nome, decimal preco, string fotoURL, int tamanhoId)
        {

            Nome = nome;
            Preco = preco;
            FotoURL = fotoURL;
            TamanhoId = tamanhoId;
            

            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
            
        }

        public int Id { get; set; } 
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string FotoURL { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

 
        public int TamanhoId { get; set; }
        public Tamanho Tamanho { get; set; }


        public List<PizzaSabor> PizzasSabores { get; set; }

        public void AtualizarDados (string nome, decimal novoPreco, string novaFoto, int tamanhoId )
        {
            if (Nome.Length < 1 || novoPreco < 0)
                return;

            Nome = nome;
            Preco = novoPreco;
            FotoURL = novaFoto;
            TamanhoId = tamanhoId;
           

            DataAlteracao = DateTime.Now;


        }


    }
}
