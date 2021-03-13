using System;
using System.Collections.Generic;

#nullable disable

namespace Base.Domain.Entidades
{
    public partial class Transferencia
    {
        public int Id { get; set; }
        public int IdClienteRemetente { get; set; }
        public int IdClienteDestinatario { get; set; }
        public decimal Valor { get; set; }

        public virtual Cliente IdClienteDestinatarioNavigation { get; set; }
        public virtual Cliente IdClienteRemetenteNavigation { get; set; }
    }
}
