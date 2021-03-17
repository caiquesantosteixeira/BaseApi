﻿using Base.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Commands.Cliente
{
    public class DepositoAtualizarCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NomeRemetente { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public void Validate()
        {
            AddNotifications(
              new Contract()
                .Requires()
                .IsGreaterThan(Valor, 0, "Valor", "Valor precisa ser maior que 0")
            );
        }

    }
}
