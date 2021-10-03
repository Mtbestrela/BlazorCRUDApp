using System;
using System.Collections.Generic;

namespace BlazorCRUDApp.Data
{
  public class Cliente
    {
        public Guid Id { get; set; }
        public string Name  { get; set; }
        public string LastName { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }


    }
}