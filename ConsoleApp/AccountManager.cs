using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class AccountManager
    {
        private AccountCrudFactory crudAccount;

        public AccountManager()
        {
            crudAccount = new AccountCrudFactory();
        }

        public void Create(Account account)
        {

            crudAccount.Create(account);

        }

        public List<Account> RetrieveAll()
        {
            return crudAccount.RetrieveAll<Account>();
        }

        public Account RetrieveById(Account account)
        {
            return crudAccount.Retrieve<Account>(account);
        }

        internal void Update(Account account)
        {
            crudAccount.Update(account);
        }

        internal void Delete(Account account)
        {
            crudAccount.Delete(account);
        }
    }
}
