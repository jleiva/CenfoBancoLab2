using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Localization : BaseEntity
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public string ClienteId { get; set; }

        public Localization()
        {
        }

        public Localization(string tipo, string valor, string clienteId)
        {
            Tipo = tipo;
            Valor = valor;
            ClienteId = clienteId;
        }

        public Localization(int id, string tipo, string valor, string clienteId)
        {
            Id = id;
            Tipo = tipo;
            Valor = valor;
            ClienteId = clienteId;
        }
    }
}
