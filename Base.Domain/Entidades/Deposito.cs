using System;
using System.Collections.Generic;

#nullable disable

namespace Base.Domain.Entidades
{
    public partial class Deposito
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NomeRemetente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
