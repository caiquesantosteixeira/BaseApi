using Flunt.Notifications;
using Flunt.Validations;
using Base.Domain.Commands.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Commands.Usuario
{
    public class UsuarioCommand : Notifiable, ICommand
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Senha { get; set; }
        public string Email { get; set; }

        public UsuarioCommand()
        {
            
        }       

        public void Validate()
        {
            AddNotifications(
             new Contract()
               .Requires()
               .HasMinLen(UserName, 3, "UserName", "Preencha o Usuario com no mínimo 3 caracteres.")
           
           );
        }

        public void ValidAtualizarExcluir()
        {
            AddNotifications(
             new Contract()
               .Requires()
               .HasMinLen(Id, 30, "Id", "Id Inválido.")              
           );
        }

        public void ValidateCadastrar()
        {
            AddNotifications(
             new Contract()
               .Requires()
               .HasMinLen(Senha, 4, "Senha", "Preencha a senha com no mínimo 4 caracteres.")
           );
        }
    }
}
