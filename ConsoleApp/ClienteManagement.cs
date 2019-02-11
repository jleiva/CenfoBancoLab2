using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ClienteManagement
    {
        private ClienteCrudFactory crudCliente;

        public ClienteManagement()
        {
            crudCliente = new ClienteCrudFactory();
        }

        public void Create(Cliente customer)
        {
            
            crudCliente.Create(customer);

        }

        public List<Cliente> RetrieveAll()
        {
            return crudCliente.RetrieveAll<Cliente>();
        }

        public Cliente RetrieveById(Cliente customer)
        {
            return crudCliente.Retrieve<Cliente>(customer);
        }

        internal void Update(Cliente customer)
        {
            crudCliente.Update(customer);
        }

        internal void Delete(Cliente customer)
        {
            crudCliente.Delete(customer);
        }
    }
}
