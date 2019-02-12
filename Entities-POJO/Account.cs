using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Account : BaseEntity
    {
        public int Id { get; set; }
        public string Moneda { get; set; }
        public string ClienteId { get; set; }
        public double Saldo { get; set; }

        public Account()
        {
        }

        public Account(string moneda, string clienteId, double saldo)
        {
            ClienteId = clienteId;
            Moneda = moneda;
            Saldo = saldo;
        }

        public Account(int id, string moneda, string clienteId, double saldo)
        {
            Id = id;
            Moneda = moneda;
            ClienteId = clienteId;
            Saldo = saldo;
        }
    }
}
