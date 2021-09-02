using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Api.ViewModel
{
    public class UserViewModel : CreateUserViewModel
    {
        [Required(ErrorMessage = "O ID não pode ser vazio")]
        [Range(1,int.MaxValue,ErrorMessage ="O ID Nao pode ser zero")]
        public long Id { get; set; }
    }
}
