using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Api.ViewModel
{
    public class UserViewModel : CreateUserViewModel
    {
        [Required(ErrorMessage ="ID Não pode ser nulo")]
        [MinLength(1,ErrorMessage = "ID tem que ser maior que 0")]
        public long Id { get; set; }
    }
}
