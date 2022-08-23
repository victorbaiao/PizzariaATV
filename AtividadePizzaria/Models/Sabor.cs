using System.Collections.Generic;
using System;
using AtividadePizzaria.Models.Intefaces;

namespace AtividadePizzaria.Models
{
    public class Sabor : IEntidade
    {


        public Sabor(string nome, string fotoURL)
        {

            Nome = nome;
            FotoURL = fotoURL;


            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string FotoURL { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }


        public List<PizzaSabor> PizzasSabores { get; set; }

        public void AtualizarDados(string nome, string novaFoto)
        {
            if (Nome.Length < 1 )
                return;

            Nome = nome;
            FotoURL = novaFoto;

            DataAlteracao = DateTime.Now;


        }


    }
}
