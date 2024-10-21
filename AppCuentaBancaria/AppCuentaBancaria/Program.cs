//FARFAN CARRION JOSEPH MATTHEW 221447
using System;
using AppCuentaBancaria;

namespace AppCuentaBancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = null;
            CuentaBancaria cuenta = null;
            int opcion = -1;

            while (opcion != 6)
            {
                Console.Clear();
                MostrarMenu();

                Console.Write("Ingrese una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        cliente = IngresarDatosGenerales();
                        cuenta = new CuentaBancaria(cliente);
                        break;
                    case 2:
                        if (cuenta == null)
                        {
                            Console.WriteLine("Primero debe ingresar los datos del cliente.");
                        }
                        else
                        {
                            Deposito(cuenta);
                        }
                        break;
                    case 3:
                        if (cuenta == null)
                        {
                            Console.WriteLine("Primero debe ingresar los datos del cliente.");
                        }
                        else
                        {
                            Retiro(cuenta);
                        }
                        break;
                    case 4:
                        if (cuenta == null)
                        {
                            Console.WriteLine("Primero debe ingresar los datos del cliente.");
                        }
                        else
                        {
                            MostrarSaldo(cuenta);
                        }
                        break;
                    case 5:
                        if (cuenta == null)
                        {
                            Console.WriteLine("Primero debe ingresar los datos del cliente.");
                        }
                        else
                        {
                            MostrarMovimientos(cuenta);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Saliendo de la aplicación...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("Menú de Cuenta Bancaria");
            Console.WriteLine("=======================");
            Console.WriteLine("1. Ingresar Datos Generales");
            Console.WriteLine("2. Depósitos");
            Console.WriteLine("3. Retiros");
            Console.WriteLine("4. Mostrar Saldo");
            Console.WriteLine("5. Mostrar Movimientos");
            Console.WriteLine("6. Salir");
        }

        static Cliente IngresarDatosGenerales()
        {
            Console.Write("Ingrese el NroDNI: ");
            string nroDni = Console.ReadLine();
            Console.Write("Ingrese el nombre del cliente: ");
            string nombres = Console.ReadLine();
            Console.Write("Ingrese la dirección del cliente: ");
            string direccion = Console.ReadLine();

            return new Cliente(nroDni, nombres, direccion);
        }

        static void Deposito(CuentaBancaria cuenta)
        {
            Console.Write("Ingrese el monto a depositar: ");
            double monto = Convert.ToDouble(Console.ReadLine());
            Movimiento movimiento = new Movimiento(DateTime.Now, "Abono", monto);
            cuenta.AgregarMovimiento(movimiento);
            Console.WriteLine("Depósito realizado correctamente.");
        }

        static void Retiro(CuentaBancaria cuenta)
        {
            Console.Write("Ingrese el monto a retirar: ");
            double monto = Convert.ToDouble(Console.ReadLine());
            Movimiento movimiento = new Movimiento(DateTime.Now, "Cargo", monto);
            cuenta.AgregarMovimiento(movimiento);
            Console.WriteLine("Retiro realizado correctamente.");
        }

        static void MostrarSaldo(CuentaBancaria cuenta)
        {
            double saldo = cuenta.CalcularSaldo();
            Console.WriteLine($"El saldo actual es: {saldo:C}");
        }

        static void MostrarMovimientos(CuentaBancaria cuenta)
        {
            Console.WriteLine("Movimientos de la cuenta:");
            cuenta.MostrarMovimientos();
        }
    }
}
