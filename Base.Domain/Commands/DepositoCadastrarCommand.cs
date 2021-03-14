using Base.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Commands.Cliente
{
    public class DepositoCadastrarCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NomeRemetente { get; set; }

        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
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
