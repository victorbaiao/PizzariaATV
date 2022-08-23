using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadePizzaria.Models.ViewModels.RequestDTO
{
    public class PostTamanhoVM
    {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é necessariamente obrigatório")]
        public string Nome { get; set; }
    }
}
