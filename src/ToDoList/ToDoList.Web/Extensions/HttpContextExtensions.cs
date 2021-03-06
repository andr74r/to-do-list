﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoList.Security.Core.Dto;
using ToDoList.Web.Extensions.Consts;

namespace ToDoList.Web.Extensions
{
    public static class HttpContextExtensions
    {
        public static async Task Authenticate(this HttpContext httpContext, UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentityConsts.UserId, user.Id.ToString()),
                new Claim(ClaimsIdentityConsts.UserPhone, user.Phone),
                new Claim(ClaimsIdentityConsts.UserEmail, user.Email),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public static async Task SignOut(this HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
