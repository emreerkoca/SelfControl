using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Self.Core.Entities;
using Self.Core.Interfaces;
using Self.Service;
using Self.WebSpaReact.Models;

namespace Self.WebSpaReact.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RegisterUserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);

            try
            {
                _unitOfWork.UserRepository.AddNewUser(user);
                _unitOfWork.CommitAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); ;
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel authenticateModel)
        {
            try
            {
                if (authenticateModel == null)
                {
                    return BadRequest("Sample Error");
                }

                var user = _userService.Authenticate(authenticateModel.EMail, authenticateModel.Password);

                if (user == null)
                {
                    return BadRequest(new { message = "User name and/or password are incorrect!" });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}