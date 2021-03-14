using Base.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Commands.Cliente
{
    public class SaqueAtualizarCommand: Notifiable, ICommand
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }

        public decimal Valor { get; set; }
        public void Validate()
        {
            AddNotifications(
             new Contract()
               .Requires()
               .IsGreaterThan(Id, 0, "Id", "Id Inválido.")
           );
        }
    }
}
