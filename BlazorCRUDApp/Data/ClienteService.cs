using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCRUDApp.Data
{
    public class ClienteService: IClienteService
    {
        private List<Cliente> clientes = new List<Cliente>
        {
            new Cliente
            {
                Id = Guid.NewGuid(),
                Name = "Matheus  ",
                LastName = "Borges",
                CpfCnpj = "700.636.311-74",
                Email = "matheusestrelab@hotmail.com"
            },

            new Cliente
            {
                Id = Guid.NewGuid(),
                Name = "Fausto ",
                LastName = "Manoel",
                CpfCnpj = "036.590.071-02",
                Email = "fasutomanoel@gmail.com"
            }
        };

        public void AddCliente(Cliente cliente)
        {
            var id = Guid.NewGuid();
            cliente.Id = id;
            clientes.Add(cliente);
        }

        public void DeleteCliente(Guid id)
        {
            var cliente = GetCliente(id);
            clientes.Remove(cliente);
        }

        public Cliente GetCliente(Guid id)
        {
            return clientes.SingleOrDefault(x => x.Id == id);
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public void UpdateCliente(Cliente cliente)
        {
            var getOldCliente = GetCliente(cliente.Id);
            getOldCliente.Name = cliente.Name;
            getOldCliente.LastName = cliente.LastName;
            getOldCliente.CpfCnpj = cliente.CpfCnpj;
            getOldCliente.Email = cliente.Email;

        }
    }
}
