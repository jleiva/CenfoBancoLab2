using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    class Credito : BaseEntity
    {
        public int Monto { get; set; }
        public double Tasa { get; set; }
        public string Nombre { get; set; }
        public double Cuota { get; set; }
        public string FechaInicio { get; set; }
        public string Estado { get; set; }
        public double Saldo { get; set; }

        public Credito()
        {
        }

        public Credito(int monto, double tasa, string nombre, double cuota, string fechaInicio, string estado)
        {
            Monto = monto;
            Tasa = tasa;
            Nombre = nombre;
            Cuota = cuota;
            FechaInicio = fechaInicio;
            Estado = estado;
        }
    }
}
