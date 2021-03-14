using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Base.Domain.Repositorios.Usuarios
{
    public interface IUserIdentity
    {
        string Nome { get; }
        string Email { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
