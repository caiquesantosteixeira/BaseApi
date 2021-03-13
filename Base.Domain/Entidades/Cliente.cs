using System;
using System.Collections.Generic;

namespace Base.Domain.Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            Deposito = new HashSet<Deposito>();
            Saque = new HashSet<Saque>();
            TransferenciaIdClienteDestinatarioNavigation = new HashSet<Transferencia>();
            TransferenciaIdClienteRemetenteNavigation = new HashSet<Transferencia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Saldo { get; set; }

        public virtual ICollection<Deposito> Deposito { get; set; }
        public virtual ICollection<Saque> Saque { get; set; }
        public virtual ICollection<Transferencia> TransferenciaIdClienteDestinatarioNavigation { get; set; }
        public virtual ICollection<Transferencia> TransferenciaIdClienteRemetenteNavigation { get; set; }
    }
}
