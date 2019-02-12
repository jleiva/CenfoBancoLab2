using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class CustomerManagement
    {
        private CustomerCrudFactory crudCliente;

        public CustomerManagement()
        {
            crudCliente = new CustomerCrudFactory();
        }

        public void Create(Customer customer)
        {
            
            crudCliente.Create(customer);

        }

        public List<Customer> RetrieveAll()
        {
            return crudCliente.RetrieveAll<Customer>();
        }

        public Customer RetrieveById(Customer customer)
        {
            return crudCliente.Retrieve<Customer>(customer);
        }

        internal void Update(Customer customer)
        {
            crudCliente.Update(customer);
        }

        internal void Delete(Customer customer)
        {
            crudCliente.Delete(customer);
        }
    }
}
