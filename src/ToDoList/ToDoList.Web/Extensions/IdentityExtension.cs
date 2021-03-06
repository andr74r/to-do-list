﻿using System;
using System.Security.Claims;
using System.Security.Principal;
using ToDoList.Web.Extensions.Consts;

namespace ToDoList.Web.Extensions
{
    public static class IdentityExtension
    {
        public static int UserId(this IIdentity identity)
        {
            var value = identity.GetClaimValue(ClaimsIdentityConsts.UserId);

            return int.Parse(value);
        }

        public static string Email(this IIdentity identity)
        {
            return identity.GetClaimValue(ClaimsIdentityConsts.UserEmail);
        }

        public static string Phone(this IIdentity identity)
        {
            return identity.GetClaimValue(ClaimsIdentityConsts.UserPhone);
        }

        private static string GetClaimValue(this IIdentity identity, string type)
        {
            if (identity is ClaimsIdentity claimsIdentity)
            {
                var claim = claimsIdentity.FindFirst(type);

                return claim.Value;
            }

            throw new ArgumentException("Not supported identity type.");
        }
    }
}
