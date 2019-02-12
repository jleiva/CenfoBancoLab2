using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Customer : BaseEntity
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }

        public Customer()
        {
            
        }

        public Customer(string[] infoArray)
        {
            if(infoArray!=null && infoArray.Length >= 7){
                Cedula = infoArray[0];
                Nombre = infoArray[1];
                Apellido = infoArray[2];
                Genero = infoArray[3];
                EstadoCivil = infoArray[4];
                FechaNacimiento = infoArray[5];

                var edad = 0;
                if (Int32.TryParse(infoArray[6], out edad))
                    Edad = edad;
                else
                    throw new Exception("Edad debe ser un numero");
            }
            else
            {
                throw new Exception("Todos los valores son requeridos [cedula, nombre, apellido, edad, genero, estado civil, fecha nacimiento]");
            }

        }

    }
}
