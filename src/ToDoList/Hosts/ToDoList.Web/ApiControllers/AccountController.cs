﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Core.Services.DefaultCategoryCreator;
using ToDoList.Security.Core.Dto;
using ToDoList.Security.Core.Services.User;
using ToDoList.Web.Extensions;
using ToDoList.Web.ViewModels.Account;

namespace ToDoList.Web.ApiControllers
{
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDefaultCategoryCreator _defaultCategoryCreator;
        private readonly IMapper _mapper;

        public AccountController(
            IUserService userService,
            IDefaultCategoryCreator defaultCategoryCreator,
            IMapper mapper)
        {
            _userService = userService;
            _defaultCategoryCreator = defaultCategoryCreator;
            _mapper = mapper;
        }

        [Route("api/account/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = _userService.FindUser(
                _mapper.Map<FindUserByPasswordDto>(loginViewModel));

            var resultVm = new UserViewModel();

            if (user != null)
            {
                await HttpContext.Authenticate(user);

                _mapper.Map(user, resultVm);

                resultVm.IsLoggedIn = true;
            }
            else
            {
                resultVm.IsLoggedIn = false;
            }

            return Ok(resultVm);
        }

        [Route("api/account/register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var user = _userService.FindUser(
                _mapper.Map<FindUserDto>(registerViewModel));

            var resultVm = new UserViewModel();

            if (user == null)
            {
                user = _userService.CreateUser(
                    _mapper.Map<CreateUserDto>(registerViewModel));

                await HttpContext.Authenticate(user);

                _mapper.Map(user, resultVm);

                resultVm.IsLoggedIn = true;

                _defaultCategoryCreator.CreateDefaultCategories(user.Id);
            }
            else
            {
                resultVm.IsLoggedIn = false;
            }

            return Ok(resultVm);
        }

        [Route("api/account/logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOut();

            return Ok();
        }
    }
}