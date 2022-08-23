using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadePizzaria.Models.ViewModels.RequestDTO
{
    public class PostPizzaVM
    {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é necessariamente obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O Preço é necessariamente obrigatório")]
        public decimal Preco { get; set; }

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "A imagem é necessariamente obrigatóra")]
        public string FotoURL { get; set; }

        [Display(Name = "Informe os Sabores")]
        [Required(ErrorMessage = "Sabores é necessariamente obrigatório")]
        public List<int> SaboresId { get; set; }


        [Display(Name = "Informe o Tamanho")]
        [Required(ErrorMessage = "Tamanho é necessariamente obrigatório")]
        public int TamanhoId { get; set; }

    }
}
