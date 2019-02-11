using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Cuenta : BaseEntity
    {
        public int Id { get; set; }
        public string Moneda { get; set; }
        public double Saldo { get; set; }

        public Cuenta()
        {
        }

        public Cuenta(string moneda, double saldo)
        {
            Moneda = moneda;
            Saldo = saldo;
        }

        public Cuenta(int id, string moneda, double saldo)
        {
            Id = id;
            Moneda = moneda;
            Saldo = saldo;
        }
    }
}
