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

        public Credit()
        {
        }

        public Credit(double monto, double tasa, string clienteId, double cuota, string fechaInicio, string estado, double saldo)
        {
            Monto = monto;
            Tasa = tasa;
            ClienteId = clienteId;
            Cuota = cuota;
            FechaInicio = fechaInicio;
            Estado = estado;
            Saldo = saldo;
        }

        public Credit(int id, double monto, double tasa, string clienteId, double cuota, string fechaInicio, string estado, double saldo)
        {
            Id = id;
            Monto = monto;
            Tasa = tasa;
            ClienteId = clienteId;
            Cuota = cuota;
            FechaInicio = fechaInicio;
            Estado = estado;
            Saldo = saldo;
        }
    }
}
