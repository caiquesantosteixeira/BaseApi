using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.ValueObject.Basicos
{
    public class RetornoPaginacao<T>
    {
        public int Total { get; set; }
        public List<T> Lista { get; set; }

        public RetornoPaginacao()
        {
            Lista = new List<T>();
        }
    }
}
