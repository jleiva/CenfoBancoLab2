using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class CustomerManager : BaseManager
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

        public void Update(Customer customer)
        {
            crudCustomer.Update(customer);
        }

        public void Delete(Customer customer)
        {
            crudCustomer.Delete(customer);
        }
    }
}
