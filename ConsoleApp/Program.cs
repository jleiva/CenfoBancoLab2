using ConsoleTableExt;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        enum OPERATIONS {
            CREATE, RETRIVE, UPDATE, DELETE, RETRIVE_ALL
        };

        static void Main(string[] args)
        {

            DoIt();
        }

        public static void DoIt() { 
            try
            {
                var mng = new CustomerManagement();
                var customer = new Customer();

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
                        CustomerOperations();

                        break;

                    case "2":
                        AccountOperations();

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

        public static void CustomerOperations()
        {
            var mng = new CustomerManagement();
            var customer = new Customer();

            Console.WriteLine("\r\n");
            Console.WriteLine("***************************");
            Console.WriteLine("** Clientes opciones CRUD: **");
            Console.WriteLine("***************************");

            var operacionSeleccionada = SelectCrudOperation();

            switch (operacionSeleccionada)
            {
                case "1":
                    Console.WriteLine(getOperationHeading(0));
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

                    customer = new Customer(infoArray);
                    mng.Create(customer);

                    Console.WriteLine("Customer was created");

                    break;

                case "2":
                    Console.WriteLine(getOperationHeading(4));

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
                    Console.WriteLine(getOperationHeading(1));
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
                    Console.WriteLine(getOperationHeading(2));

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
                    Console.WriteLine(getOperationHeading(3));
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

        public static void CreditOperations()
        {
            var mng = new CreditManagement();
            var credit = new Credit();

            Console.WriteLine("\r\n");
            Console.WriteLine("***************************");
            Console.WriteLine("** Creditos opciones CRUD: **");
            Console.WriteLine("***************************");

            var operacionSeleccionada = SelectCrudOperation();

            switch (operacionSeleccionada)
            {
                case "1":
                    Console.WriteLine(getOperationHeading(0));

                    break;

                case "2":
                    Console.WriteLine(getOperationHeading(4));

                    break;

                case "3":
                    Console.WriteLine(getOperationHeading(1));
                    Console.WriteLine("Digite el ID de la cuenta:");
                    break;

                case "4":
                    Console.WriteLine(getOperationHeading(2));
                    break;

                case "5":
                    Console.WriteLine(getOperationHeading(3));
                    Console.WriteLine("Digite el ID de la cuenta:");
                    break;
            }
        }

        public static void AccountOperations()
        {

            var mng = new AccountManagement();
            var account = new Account();

            Console.WriteLine("\r\n");
            Console.WriteLine("***************************");
            Console.WriteLine("** Cuentas opciones CRUD: **");
            Console.WriteLine("***************************");

            var operacionSeleccionada = SelectCrudOperation();

            switch (operacionSeleccionada)
            {
                case "1":
                    var cMng = new CustomerManagement();
                    var customer = new Customer();

                    Console.WriteLine(getOperationHeading(0));
                    Console.WriteLine("Digite la cedula del cliente:");
                    customer.Cedula = Console.ReadLine();
                    customer = cMng.RetrieveById(customer);

                    if (customer != null)
                    {
                        Console.WriteLine("Digite el tipo de moneda: \n Colones, Dolares, etc");
                        var moneda = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Deposito inicial, formato de moneda: 1345.978");
                        var inicial = Console.ReadLine();
                        double saldo = 0;

                        if (Double.TryParse(inicial, out saldo))
                        {
                            account = new Account(moneda, customer.Cedula, saldo);
                        }
                        else
                        {
                            account = new Account(moneda, customer.Cedula, saldo);
                            Console.WriteLine("El valor para deposito inicial no es valido '{0}'.", inicial);
                            Console.WriteLine("Se creo la cuenta con un saldo de 0");
                        }

                        mng.Create(account);
                        Console.WriteLine("La Cuenta se creo de manera exitosa.");
                    }
                    else
                    {
                        throw new Exception("Cliente no esta registrado");
                    }

                    break;

                case "2":
                    Console.WriteLine(getOperationHeading(4));

                    var lstCuentas = mng.RetrieveAll();
                    var count = 0;
                    DataTable table = new DataTable();

                    table.Columns.Add("#", typeof(string));
                    table.Columns.Add("ID Cuenta", typeof(string));
                    table.Columns.Add("ID Cliente", typeof(string));
                    table.Columns.Add("Moneda", typeof(string));
                    table.Columns.Add("Saldo", typeof(double));

                    foreach (var c in lstCuentas)
                    {
                        count++;
                        table.Rows.Add(count, c.Id, c.ClienteId, c.Moneda, c.Saldo);
                    }

                    //  formatted table
                    // https://github.com/minhhungit/ConsoleTableExt/
                    var tableBuilder = ConsoleTableBuilder.From(table);
                    tableBuilder.ExportAndWriteLine();

                    break;

                case "3":
                    Console.WriteLine(getOperationHeading(1));
                    Console.WriteLine("Digite el ID de la cuenta:");
                    var idCuenta = Console.ReadLine();
                    var id = 0;

                    if (Int32.TryParse(idCuenta, out id))
                    {
                        account.Id = id;
                        account = mng.RetrieveById(account);
                    }
                    else
                    {
                        throw new Exception("ID de la cuenta debe ser un numero");
                    }
                        
                    if (account != null)
                    {
                        Console.WriteLine(" ==> " + account.GetEntityInformation());
                    }
                    else
                    {
                        throw new Exception("Cuenta no esta registrada");
                    }

                    break;

                case "4":
                    Console.WriteLine(getOperationHeading(2));

                    Console.WriteLine("Digite el ID de la cuenta:");
                    var idCta = Console.ReadLine();
                    var idFallback = 0;

                    if (Int32.TryParse(idCta, out idFallback))
                    {
                        account.Id = idFallback;
                        account = mng.RetrieveById(account);
                    }
                    else
                    {
                        throw new Exception("ID de la cuenta debe ser un numero");
                    }

                    if (account != null)
                    {
                        Console.WriteLine(" ==> " + account.GetEntityInformation());

                        Console.WriteLine("Digite el tipo de Moneda; el valor actual es: " + account.Moneda);
                        account.Moneda = Console.ReadLine();

                        Console.WriteLine("Digite el Id del Cliente; el valor actual es: " + account.ClienteId);
                        account.ClienteId = Console.ReadLine();

                        mng.Update(account);
                        Console.WriteLine("Cuenta fue actualizada");
                        Console.WriteLine(" ==> " + account.GetEntityInformation());
                    }
                    else
                    {
                        throw new Exception("Cuenta no esta registrada");
                    }

                    break;

                case "5":
                    Console.WriteLine(getOperationHeading(3));
                    Console.WriteLine("Digite el ID de la cuenta:");
                    var idCtaF = Console.ReadLine();
                    var idFallbackD = 0;

                    if (Int32.TryParse(idCtaF, out idFallbackD))
                    {
                        account.Id = idFallbackD;
                        account = mng.RetrieveById(account);
                    }
                    else
                    {
                        throw new Exception("ID de la cuenta debe ser un numero");
                    }

                    if (account != null)
                    {
                        Console.WriteLine(" ==> " + account.GetEntityInformation());

                        Console.WriteLine("Desea eliminar la cuenta? Y/N");
                        var delete = Console.ReadLine();

                        if (delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                        {
                            mng.Delete(account);
                            Console.WriteLine("Cuenta fue eliminado de manera exitosa.");
                        }
                    }
                    else
                    {
                        throw new Exception("Cuenta no esta registrado");
                    }

                    break;
            }
        }

        public static String SelectCrudOperation()
        {
            Console.WriteLine("1. CREATE");
            Console.WriteLine("2. RETRIEVE ALL");
            Console.WriteLine("3. RETRIEVE BY ID");
            Console.WriteLine("4. UPDATE");
            Console.WriteLine("5. DELETE");

            Console.WriteLine("Seleccione una opcion: ");
            var option = Console.ReadLine();

            return option;
        }

        public static String getOperationHeading(int headingType)
        {
            var operation = Enum.GetName(typeof(OPERATIONS), headingType);
            var spacing = "*************************************";
            var heading = $"\n{spacing} \n***** {operation} ***** \n{spacing}";

            return heading;
        }
    }
}
