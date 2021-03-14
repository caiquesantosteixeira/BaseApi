using Base.Domain.Shared.DTOs.Usuario;
using Microsoft.AspNetCore.Identity;


namespace Base.Domain.Shared.Entidades.Usuarios
{
    public class Usuario : IdentityUser
    {

        public UsersDTO GetDTO()
        {
            var user = new UsersDTO();
            user.Id = Id;
            user.Login = UserName;
            user.Senha = PasswordHash;
            user.Email = Email;
            return user;
        }
    }
}
