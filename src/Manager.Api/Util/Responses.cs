using Manager.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Api.Util
{
    public static class Responses
    {

        public static ResultViewModel AppErrorMessage()
        {
            return new ResultViewModel
            {
                Sucess = false,
                Message = "Ocorreu um erro interno na aplicação",
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Sucess = false,
                Message = message,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Sucess = false,
                Message = message,
                Data = errors
            };
        }

        public static ResultViewModel UnauthorizedErrorMessage()
        {
            return new ResultViewModel
            {
                Sucess = false,
                Message = "Combinação de Login incorreta",
                Data = null
            };
        }

    }
}
