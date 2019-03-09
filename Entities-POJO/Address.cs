using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Address : BaseEntity
    {
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string ClienteId { get; set; }

        public Address()
        {
        }

        public Address(string provincia, string canton, string distrito, string clienteId)
        {
            Provincia = provincia;
            Canton = canton;
            Distrito = distrito;
            ClienteId = clienteId;
        }

        public Address(int id, string provincia, string canton, string distrito, string clienteId)
        {
            Id = id;
            Provincia = provincia;
            Canton = canton;
            Distrito = distrito;
            ClienteId = clienteId;
        }
    }
}
