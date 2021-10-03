using System;
using System.Collections.Generic;

namespace BlazorCRUDApp.Data
{
    interface IClienteService
    {
        List<Cliente> GetClientes();

        Cliente GetCliente(Guid id);

        void UpdateCliente(Cliente cliente);

        void AddCliente(Cliente cliente);

        void DeleteCliente(Guid id);
    }
}
