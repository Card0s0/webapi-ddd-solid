using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Api.ViewModel
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage ="Nome não pode ser branco")]
        [MinLength(2,ErrorMessage = "O Tamanho mínimo do nome deve ser 2 caracteres")]
        [MaxLength(80,ErrorMessage = "O Tamanho maximo do nome deve ser 80 caracteres")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email não pode ser em branco")]
        [MinLength(6,ErrorMessage = "O Tamanho mínimo do Email são de 6 caracteres")]
        [MaxLength(180, ErrorMessage = "O Tamanho máximo do Email são de 180 caracteres")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage ="Email Invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser em branco")]
        [MinLength(6, ErrorMessage = "O Tamanho mínimo do Password são de 6 caracteres")]
        [MaxLength(12, ErrorMessage = "O Tamanho máximo do Password são de 180 caracteres")]
        public string Password { get; set; }

    }
}
