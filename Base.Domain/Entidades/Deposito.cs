using System;
using System.Collections.Generic;

namespace Base.Domain.Entidades
{
    public partial class Deposito
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NomeRemetente { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
