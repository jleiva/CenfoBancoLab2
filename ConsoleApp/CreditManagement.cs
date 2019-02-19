using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class CreditManagement
    {
        private CreditCrudFactory crudCredit;

        public CreditManagement()
        {
            crudCredit = new CreditCrudFactory();
        }

        public void Create(Credit credit)
        {

            crudCredit.Create(credit);

        }

        public List<Credit> RetrieveAll()
        {
            return crudCredit.RetrieveAll<Credit>();
        }

        public Credit RetrieveById(Credit credit)
        {
            return crudCredit.Retrieve<Credit>(credit);
        }

        internal void Update(Credit credit)
        {
            crudCredit.Update(credit);
        }

        internal void Delete(Credit credit)
        {
            crudCredit.Delete(credit);
        }
    }
}
