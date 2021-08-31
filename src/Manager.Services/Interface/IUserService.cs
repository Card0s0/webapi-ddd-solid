using Manager.Domain.Entities;
using Manager.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services.Interface
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO obj);
        Task<UserDTO> Update(UserDTO obj);
        Task Remove(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> Get();
        Task<UserDTO> GetByEmail(string email);
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<List<UserDTO>> SearchByName(string name);
    }
}
