using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Inspecoes.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        string GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}