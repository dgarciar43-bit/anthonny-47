using System;
using System.Collections.Generic;

namespace RegistroEmpleados
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal SalarioBase { get; set; }
        public int HorasExtra { get; set; }

        public decimal PagoTotal()
        {
            return SalarioBase + (HorasExtra * 250);
        }
    }

    public class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            // Empleados de prueba agregados de una vez
            empleados.Add(new Empleado
            {
                Id = 1,
                Nombre = "Juan Perez",
                SalarioBase = 4000,
                HorasExtra = 10
            });

            empleados.Add(new Empleado
            {
                Id = 2,
                Nombre = "Maria Lopez",
                SalarioBase = 5500,
                HorasExtra = 0
            });

            int siguienteId = 3;
            int opcion;

            do
            {
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado(ref siguienteId);
                        break;

                    case 2:
                        ListarEmpleados();
                        break;

                    case 3:
                        BuscarEmpleado();
                        break;

                    case 4:
                        CalcularFactorial();
                        break;

                    case 5:
                        Console.WriteLine("El programa termina.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != 5);
        }

        static int LeerOpcionMenu()
        {
            Console.WriteLine("=== REGISTRO DE EMPLEADOS ===");
            Console.WriteLine("1. Agregar empleado");
            Console.WriteLine("2. Listar empleados");
            Console.WriteLine("3. Buscar empleado");
            Console.WriteLine("4. Calcular factorial");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");

            int opcion;

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                return opcion;
            }

            return 0;
        }

        static void AgregarEmpleado(ref int siguienteId)
        {
            Empleado empleado = new Empleado();

            empleado.Id = siguienteId;

            Console.Write("Nombre: ");
            empleado.Nombre = Console.ReadLine();

            decimal salario;

            while (true)
            {
                Console.Write("Salario base: ");

                if (decimal.TryParse(Console.ReadLine(), out salario))
                {
                    break;
                }

                Console.WriteLine("Dato inválido.");
            }

            empleado.SalarioBase = salario;

            int horas;

            while (true)
            {
                Console.Write("Horas extra: ");

                if (int.TryParse(Console.ReadLine(), out horas) && horas >= 0)
                {
                    break;
                }

                Console.WriteLine("Dato inválido.");
            }

            empleado.HorasExtra = horas;

            empleados.Add(empleado);
            siguienteId++;

            Console.WriteLine("Empleado agregado.");
            Console.WriteLine("Pago total = Q " +
                empleado.PagoTotal().ToString("N2"));
        }

        static void ListarEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            decimal totalNomina = 0;

            Console.WriteLine("\n=== LISTA DE EMPLEADOS ===");

            foreach (Empleado empleado in empleados)
            {
                decimal pago = empleado.PagoTotal();

                Console.WriteLine(
                    empleado.Id + " - " +
                    empleado.Nombre +
                    " - Q " +
                    pago.ToString("N2")
                );

                totalNomina += pago;
            }

            Console.WriteLine("\nTOTAL DE NÓMINA: Q " +
                totalNomina.ToString("N2"));
        }

        static void BuscarEmpleado()
        {
            Console.Write("Nombre a buscar: ");
            string texto = Console.ReadLine();

            bool encontrado = false;

            foreach (Empleado empleado in empleados)
            {
                if (empleado.Nombre.IndexOf(
                    texto,
                    StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine(
                        "Encontrado: " +
                        empleado.Id + " - " +
                        empleado.Nombre
                    );

                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró el empleado.");
            }
        }

        static void CalcularFactorial()
        {
            Console.Write("Número (entero, 0 o mayor): ");

            int numero;

            if (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Dato inválido.");
                return;
            }

            if (numero < 0)
            {
                Console.WriteLine("Dato inválido.");
                return;
            }

            Console.WriteLine(numero + "! = " + Factorial(numero));
        }

        static long Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
