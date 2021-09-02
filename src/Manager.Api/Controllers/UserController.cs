using AutoMapper;
using Manager.Api.Util;
using Manager.Api.ViewModel;
using Manager.Domain.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Sucess = true,
                    Message = "Cadastrado com Sucesso",
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message,ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.AppErrorMessage());
            }

        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UserViewModel user)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(user);
                var userUpdated = await _userService.Update(userDTO);

                var userViewModel = _mapper.Map<UserViewModel>(userUpdated);

                return Ok(new ResultViewModel
                {
                    Sucess = true,
                    Message = "Usuário Alterado",
                    Data = userViewModel
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AppErrorMessage());
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _userService.Remove(id);
                return Ok(new ResultViewModel
                {
                    Sucess = true,
                    Message = "Usuário Excluído",
                    Data = null
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {

                return StatusCode(500, Responses.AppErrorMessage());
            }
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usersGetAll = await _userService.Get();
                var usersResult = _mapper.Map<List<UserViewModel>>(usersGetAll);

                if (usersResult.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Sucess = true,
                        Message = "Nenhum Usuário Retornado",
                        Data = null
                    });
                }
                
                return Ok(new ResultViewModel
                {
                    Sucess = true,
                    Message = "Usuários Retornados",
                    Data = usersResult
                });

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AppErrorMessage());
            }
            
            

        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult>Get(long id)
        {
            try
            {
                var userGet = await _userService.Get(id);
                var userReturn = _mapper.Map<UserViewModel>(userGet);

                if (userReturn == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Sucess = true,
                        Message = "Nenhum Usuário Retornado",
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Sucess = true,
                    Message = "Usuário Retornado",
                    Data = userReturn
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.AppErrorMessage());
            }
        }

        

    }
}
