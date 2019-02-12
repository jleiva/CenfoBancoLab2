using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Address : BaseEntity
    {
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

        public Address()
        {
        }

        public Address(string provincia, string canton, string distrito)
        {
            Provincia = provincia;
            Canton = canton;
            Distrito = distrito;
        }
    }
}
