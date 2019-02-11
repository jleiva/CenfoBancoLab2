using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class CuentaManagement
    {
        private CuentaCrudFactory crudCuenta;

        public CuentaManagement()
        {
            crudCuenta = new CuentaCrudFactory();
        }

        public void Create(Cuenta cuenta)
        {

            crudCuenta.Create(cuenta);

        }

        public List<Cuenta> RetrieveAll()
        {
            return crudCuenta.RetrieveAll<Cuenta>();
        }

        public Cuenta RetrieveById(Cuenta cuenta)
        {
            return crudCuenta.Retrieve<Cuenta>(cuenta);
        }

        internal void Update(Cuenta cuenta)
        {
            crudCuenta.Update(cuenta);
        }

        internal void Delete(Cuenta cuenta)
        {
            crudCuenta.Delete(cuenta);
        }
    }
}
