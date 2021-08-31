using AutoMapper;
using Manager.Domain.Entities;
using Manager.Domain.Exceptions;
using Manager.Infra.Data.Repository;
using Manager.Services.DTO;
using Manager.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _repository;

        public UserService(IMapper mapper, UserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserDTO> Create(UserDTO obj)
        {
            var userExist = _repository.GetByEmail(obj.Name);

            if (userExist != null)
            {
                throw new DomainException("Usuário ja cadastrado com o email");
            }

            var userMap = _mapper.Map<User>(obj);
            userMap.Validate();

            var userCreated = await _repository.Create(userMap);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task Remove(long id)
        {
            var userExist = await _repository.Get(id);

            if (userExist != null)
                throw new DomainException("Usuário não existe na base de dados");

            await _repository.Remove(id);
        }

        public async Task<UserDTO> Update(UserDTO obj)
        {
            var userExist = await _repository.Get(obj.Id);

            if (userExist != null)
                throw new DomainException("Usuário não existe na base de dados");

            var userMap = _mapper.Map<User>(obj);
            userMap.Validate();

            var UserUpdated = await _repository.Update(userMap);

            return _mapper.Map<UserDTO>(UserUpdated);
        }
        public async Task<UserDTO> Get(long id)
        {
            var user = await _repository.Get(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get()
        {
            var allUser = await _repository.Get();
            return _mapper.Map<List<UserDTO>>(allUser);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _repository.GetByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUser = await _repository.SearchByEmail(email);
            return _mapper.Map<List<UserDTO>>(allUser);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUser = await _repository.SearchByName(name);
            return _mapper.Map<List<UserDTO>>(allUser);

        }
      
    }
}
