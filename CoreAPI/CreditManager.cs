using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class CreditManager : BaseManager
    {
        private CreditCrudFactory crudCredit;

        public CreditManager()
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

        public void Update(Credit credit)
        {
            crudCredit.Update(credit);
        }

        public void Delete(Credit credit)
        {
            crudCredit.Delete(credit);
        }
    }
}
