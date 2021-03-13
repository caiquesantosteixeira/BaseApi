using Base.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Commands
{
    public class ClienteCadastrarCommand: Notifiable, ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Saldo { get; set; }

        public void Validate()
        {
           // AddNotifications(
           //  new Contract()
           //    .Requires()
           //    .IsGreaterThan(IdCliente, 0, "IdEmpresa", "Id Empresa Inválido")
           //    .HasMinLen(IdUsuario, 20, "IdUsuario", "Id do Usuario inválido.")
           //);
        }

    }
}
