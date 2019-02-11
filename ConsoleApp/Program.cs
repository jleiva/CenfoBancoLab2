using ConsoleTableExt;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
       

        static void Main(string[] args)
        {

            DoIt();

        }

        public static void DoIt() { 
            try
            {
                var mng = new ClienteManagement();
                var customer = new Cliente();

                Console.WriteLine("***************************");
                Console.WriteLine("**** CenfoBanco ****");
                Console.WriteLine("***************************");
                Console.WriteLine("Operaciones de mantenimiento");
                Console.WriteLine("1. Clientes");
                Console.WriteLine("2. Cuentas");
                Console.WriteLine("3. Creditos");

                Console.WriteLine("Seleccione una opcion: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        MantenimientoClientes();

                        break;

                    case "2":
                        MantenimientoCuentas();

                        break;
                    case "3":

                         break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("ERROR: " + ex.Message );
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("***************************");
            }
            finally
            {
                Console.WriteLine("Continue? Y/N");
                var moreActions = Console.ReadLine();

                if (moreActions.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                    DoIt();
            }
        }

        public static void MantenimientoClientes()
        {
            var mng = new ClienteManagement();
            var customer = new Cliente();

            Console.WriteLine("\r\n");
            Console.WriteLine("***************************");
            Console.WriteLine("** Clientes opciones CRUD: **");
            Console.WriteLine("***************************");

            var operacionSeleccionada = SeleccionarOperacionCrud();
            
            switch (operacionSeleccionada)
            {
                case "1":
                    Console.WriteLine("\r\n");
                    Console.WriteLine("*************************************");
                    Console.WriteLine("*****     CREATE - Cliente    *******");
                    Console.WriteLine("*************************************");
                    Console.WriteLine("Digite cedula, nombre y apellido del cliente, separado por coma");
                    var nombreCompleto = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("Digite genero y estado civil, separado por coma");
                    var info = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("Digite fecha de nacimiento en formato MM-DD-YY (ejem. 09-28-1981)");
                    var fechaNacimiento = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("Digite edad");
                    var edad = Console.ReadLine();

                    var infoCliente = $"{nombreCompleto}, {info}, {fechaNacimiento}, {edad}";
                    var infoArray = infoCliente.Split(',');

                    customer = new Cliente(infoArray);
                    mng.Create(customer);

                    Console.WriteLine("Customer was created");

                    break;

                case "2":
                    Console.WriteLine("***************************");
                    Console.WriteLine("*****  RETRIEVE ALL - Cliente   *****");
                    Console.WriteLine("***************************");

                    var lstCustomers = mng.RetrieveAll();
                    var count = 0;
                    DataTable table = new DataTable();

                    table.Columns.Add("#", typeof(string));
                    table.Columns.Add("Cedula", typeof(string));
                    table.Columns.Add("Nombre", typeof(string));
                    table.Columns.Add("Apellido", typeof(string));
                    table.Columns.Add("Edad", typeof(int));

                    foreach (var c in lstCustomers)
                    {
                        count++;
                        table.Rows.Add(count, c.Cedula, c.Nombre, c.Apellido, c.Edad);
                    }

                    //  formatted table
                    // https://github.com/minhhungit/ConsoleTableExt/
                    var tableBuilder = ConsoleTableBuilder.From(table);
                    tableBuilder.ExportAndWriteLine();

                    break;
                case "3":
                    Console.WriteLine("Digite la cedula del cliente:");
                    customer.Cedula = Console.ReadLine();
                    customer = mng.RetrieveById(customer);

                    if (customer != null)
                    {
                        Console.WriteLine(" ==> " + customer.GetEntityInformation());
                    }
                    else
                    {
                        throw new Exception("Cliente no esta registrado");
                    }

                    break;
                case "4":
                    Console.WriteLine("***************************");
                    Console.WriteLine("******  UPDATE  **    *****");
                    Console.WriteLine("***************************");

                    Console.WriteLine("Digite la cedula del cliente:");
                    customer.Cedula = Console.ReadLine();
                    customer = mng.RetrieveById(customer);

                    if (customer != null)
                    {
                        Console.WriteLine(" ==> " + customer.GetEntityInformation());
                        Console.WriteLine("Digite el nombre; el valor actual es: " + customer.Nombre);
                        customer.Nombre = Console.ReadLine();
                        Console.WriteLine("Digite el apellido; el valor actual es: " + customer.Apellido);
                        customer.Apellido = Console.ReadLine();
                        Console.WriteLine("Digite el genero; el valor actual es: " + customer.Genero);
                        customer.Genero = Console.ReadLine();
                        Console.WriteLine("Digite la fecha de nacimiento; el valor actual es: " + customer.FechaNacimiento);
                        customer.FechaNacimiento = Console.ReadLine();
                        Console.WriteLine("Digite la edad; el valor actual es: " + customer.Edad);
                        var textAge = Console.ReadLine();
                        customer.Edad = Int32.TryParse(textAge, out int age) ? age : customer.Edad;
                        Console.WriteLine("Digite el estado civil; el valor actual es: " + customer.EstadoCivil);
                        customer.EstadoCivil = Console.ReadLine();

                        mng.Update(customer);
                        Console.WriteLine("Customer was updated");
                        Console.WriteLine(" ==> " + customer.GetEntityInformation());
                    }
                    else
                    {
                        throw new Exception("Cliente no esta registrado");
                    }

                    break;

                case "5":
                    Console.WriteLine("Digite la cedula del cliente:");
                    customer.Cedula = Console.ReadLine();
                    customer = mng.RetrieveById(customer);

                    if (customer != null)
                    {
                        Console.WriteLine(" ==> " + customer.GetEntityInformation());

                        Console.WriteLine("Desea eliminar al cliente? Y/N");
                        var delete = Console.ReadLine();

                        if (delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                        {
                            mng.Delete(customer);
                            Console.WriteLine("Cliente fue eliminado de manera exitosa.");
                        }
                    }
                    else
                    {
                        throw new Exception("Cliente no esta registrado");
                    }

                    break;

            }
        }

        public static void MantenimientoCuentas()
        {
            Console.WriteLine("\r\n");
            Console.WriteLine("***************************");
            Console.WriteLine("** Cuentas opciones CRUD: **");
            Console.WriteLine("***************************");

            var operacionSeleccionada = SeleccionarOperacionCrud();
        }

        public static String SeleccionarOperacionCrud()
        {

            Console.WriteLine("1.CREATE");
            Console.WriteLine("2.RETRIEVE ALL");
            Console.WriteLine("3.RETRIEVE BY ID");
            Console.WriteLine("4.UPDATE");
            Console.WriteLine("5.DELETE");

            Console.WriteLine("Seleccione una opcion: ");
            var option = Console.ReadLine();

            return option;
        }
    }
}
