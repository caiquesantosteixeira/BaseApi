using System;
using System.Collections.Generic;

#nullable disable

namespace Base.Domain.Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            Depositos = new HashSet<Deposito>();
            Saques = new HashSet<Saque>();
            TransferenciumIdClienteDestinatarioNavigations = new HashSet<Transferencia>();
            TransferenciumIdClienteRemetenteNavigations = new HashSet<Transferencia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Saldo { get; set; }

        public virtual ICollection<Deposito> Depositos { get; set; }
        public virtual ICollection<Saque> Saques { get; set; }
        public virtual ICollection<Transferencia> TransferenciumIdClienteDestinatarioNavigations { get; set; }
        public virtual ICollection<Transferencia> TransferenciumIdClienteRemetenteNavigations { get; set; }
    }
}
