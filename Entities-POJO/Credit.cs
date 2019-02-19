using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Credit : BaseEntity
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public double Tasa { get; set; }
        public string ClienteId { get; set; }
        public double Cuota { get; set; }
        public string FechaInicio { get; set; }
        public string Estado { get; set; }
        public double Saldo { get; set; }
        public string Moneda { get; set; }

        public Credit()
        {
        }

        public Credit(double monto, double tasa, string clienteId, double cuota, string fechaInicio, string estado, double saldo, string moneda)
        {
            Monto = monto;
            Tasa = tasa;
            ClienteId = clienteId;
            Cuota = cuota;
            FechaInicio = fechaInicio;
            Estado = estado;
            Saldo = saldo;
            Moneda = moneda;
        }

        public Credit(int id, double monto, double tasa, string clienteId, double cuota, string fechaInicio, string estado, double saldo, string moneda)
        {
            Id = id;
            Monto = monto;
            Tasa = tasa;
            ClienteId = clienteId;
            Cuota = cuota;
            FechaInicio = fechaInicio;
            Estado = estado;
            Saldo = saldo;
            Moneda = moneda;
        }
    }
}
