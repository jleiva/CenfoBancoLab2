using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class LocalizationManager : BaseManager
    {
        LocalizationCrudFactory crudLocalization;

        public LocalizationManager()
        {
            crudLocalization = new LocalizationCrudFactory();
        }

        public void Create(Localization localization)
        {

            crudLocalization.Create(localization);

        }

        public List<Localization> RetrieveAll()
        {
            return crudLocalization.RetrieveAll<Localization>();
        }

        public Localization RetrieveById(Localization localization)
        {
            return crudLocalization.Retrieve<Localization>(localization);
        }

        public void Update(Localization localization)
        {
            crudLocalization.Update(localization);
        }

        public void Delete(Localization localization)
        {
            crudLocalization.Delete(localization);
        }
    }
}
