using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class CustomerManager
    {
        private CustomerCrudFactory crudCustomer;

        public CustomerManager()
        {
            crudCustomer = new CustomerCrudFactory();
        }

        public void Create(Customer customer)
        {
            
            crudCustomer.Create(customer);

        }

        public List<Customer> RetrieveAll()
        {
            return crudCustomer.RetrieveAll<Customer>();
        }

        public Customer RetrieveById(Customer customer)
        {
            return crudCustomer.Retrieve<Customer>(customer);
        }

        internal void Update(Customer customer)
        {
            crudCustomer.Update(customer);
        }

        internal void Delete(Customer customer)
        {
            crudCustomer.Delete(customer);
        }
    }
}
