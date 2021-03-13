using Base.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Base.Domain.DTOs.Cliente
{
    public class ClientesDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Saldo { get; set; }

        public ClientesDTO GetDTo(Entidades.Cliente entidade)
        {
            if (entidade == null)
                return null;

            ClientesDTO cli = new ClientesDTO();
            cli.Id = entidade.Id;
            cli.Nome = entidade.Nome;
            cli.Cpf = entidade.Cpf;
            cli.Saldo = entidade.Saldo;
           
            return cli;
        }

        public List<ClientesDTO> GetDTo(IEnumerable<Entidades.Cliente> entidades)
        {
            if(entidades == null)
                return null;

            if (entidades.Count() == 0)
                return null;

            List<ClientesDTO> clientes = new List<ClientesDTO>();
            foreach (var entidade in entidades)
            {
                ClientesDTO cli = new ClientesDTO();
                cli.Id = entidade.Id;
                cli.Nome = entidade.Nome;
                cli.Cpf = entidade.Cpf;
                cli.Saldo = entidade.Saldo;
                clientes.Add(cli);
            }

            return clientes;
        }
    }
}
