//FARFAN CARRION JOSEPH MATTHEW 221447
using AppCuentaBancaria3;
using System;
using System.Collections.Generic;

namespace AppCuentaBancaria3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CuentaBancaria> cuentas = new List<CuentaBancaria>();
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
                        AperturarCuenta(cuentas);
                        break;
                    case 2:
                        RealizarDeposito(cuentas);
                        break;
                    case 3:
                        RealizarRetiro(cuentas);
                        break;
                    case 4:
                        MostrarSaldo(cuentas);
                        break;
                    case 5:
                        MostrarMovimientos(cuentas);
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
            Console.WriteLine("Menú de Cuentas Bancarias");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Aperturar Cuenta Bancaria");
            Console.WriteLine("2. Depósitos en una Cuenta Bancaria");
            Console.WriteLine("3. Retiros de una Cuenta Bancaria");
            Console.WriteLine("4. Mostrar Saldo de una Cuenta Bancaria");
            Console.WriteLine("5. Mostrar Movimientos de una Cuenta Bancaria");
            Console.WriteLine("6. Salir");
        }

        static void AperturarCuenta(List<CuentaBancaria> cuentas)
        {
            Console.Write("Ingrese el NroDNI: ");
            string nroDni = Console.ReadLine();
            Console.Write("Ingrese el nombre del cliente: ");
            string nombres = Console.ReadLine();
            Console.Write("Ingrese la dirección del cliente: ");
            string direccion = Console.ReadLine();

            Cliente cliente = new Cliente(nroDni, nombres, direccion);
            CuentaBancaria cuenta = new CuentaBancaria(cliente);
            cuentas.Add(cuenta);
            Console.WriteLine("Cuenta bancaria aperturada correctamente.");
        }

        static void RealizarDeposito(List<CuentaBancaria> cuentas)
        {
            CuentaBancaria cuenta = SeleccionarCuenta(cuentas);
            if (cuenta != null)
            {
                Console.Write("Ingrese el monto a depositar: ");
                double monto = Convert.ToDouble(Console.ReadLine());
                Movimiento movimiento = new Movimiento(DateTime.Now, "Abono", monto);
                cuenta.AgregarMovimiento(movimiento);
                Console.WriteLine("Depósito realizado correctamente.");
            }
        }

        static void RealizarRetiro(List<CuentaBancaria> cuentas)
        {
            CuentaBancaria cuenta = SeleccionarCuenta(cuentas);
            if (cuenta != null)
            {
                Console.Write("Ingrese el monto a retirar: ");
                double monto = Convert.ToDouble(Console.ReadLine());
                Movimiento movimiento = new Movimiento(DateTime.Now, "Cargo", monto);
                cuenta.AgregarMovimiento(movimiento);
                Console.WriteLine("Retiro realizado correctamente.");
            }
        }

        static void MostrarSaldo(List<CuentaBancaria> cuentas)
        {
            CuentaBancaria cuenta = SeleccionarCuenta(cuentas);
            if (cuenta != null)
            {
                double saldo = cuenta.CalcularSaldo();
                Console.WriteLine($"El saldo actual es: {saldo:C}");
            }
        }

        static void MostrarMovimientos(List<CuentaBancaria> cuentas)
        {
            CuentaBancaria cuenta = SeleccionarCuenta(cuentas);
            if (cuenta != null)
            {
                cuenta.MostrarMovimientos();
            }
        }

        static CuentaBancaria SeleccionarCuenta(List<CuentaBancaria> cuentas)
        {
            Console.WriteLine("Seleccione una cuenta bancaria:");
            for (int i = 0; i < cuentas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cuentas[i].Cliente}");
            }

            Console.Write("Ingrese el número de la cuenta: ");
            int seleccion = Convert.ToInt32(Console.ReadLine()) - 1;

            if (seleccion >= 0 && seleccion < cuentas.Count)
            {
                return cuentas[seleccion];
            }
            else
            {
                Console.WriteLine("Selección no válida.");
                return null;
            }
        }
    }
}
