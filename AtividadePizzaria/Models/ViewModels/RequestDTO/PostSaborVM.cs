using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadePizzaria.Models.ViewModels.RequestDTO
{
    public class PostSaborVM
    {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é necessariamente obrigatório")]
        public string Nome { get; set; }



        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "A imagem é necessariamente obrigatória")]
        public string FotoURL { get; set; }




    }
}
