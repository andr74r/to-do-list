using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Security.Core.Dto;
using ToDoList.Security.Core.Services.User;
using ToDoList.Web.Extensions;
using ToDoList.Web.ViewModels.Account;

namespace ToDoList.Web.ApiControllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            var user = _userService.FindUser(
                _mapper.Map<FindUserByPasswordDto>(viewModel));

            if (user != null)
            {
                await HttpContext.Authenticate(user);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            var user = _userService.FindUser(
                _mapper.Map<FindUserDto>(viewModel));

            if (user == null)
            {
                user = _userService.CreateUser(
                    _mapper.Map<UserDto>(viewModel));

                await HttpContext.Authenticate(user);

                return Redirect("/");
            }
            else
            {
                return Ok();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOut();
            return Redirect("/Account/Login");
        }
    }
}