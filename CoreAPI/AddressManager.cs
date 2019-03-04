using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class AddressManager : BaseManager
    {
        AddressCrudFactory crudAddress;

        public AddressManager()
        {
            crudAddress = new AddressCrudFactory();
        }

        public void Create(Address address)
        {

            crudAddress.Create(address);

        }

        public List<Address> RetrieveAll()
        {
            return crudAddress.RetrieveAll<Address>();
        }

        public Address RetrieveById(Address address)
        {
            return crudAddress.Retrieve<Address>(address);
        }

        public void Update(Address address)
        {
            crudAddress.Update(address);
        }

        public void Delete(Address address)
        {
            crudAddress.Delete(address);
        }
    }
}
