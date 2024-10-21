//FARFAN CARRION JOSEPH MATTHEW 221447
using System;

namespace AppCuentaBancaria3
{
    internal class Cliente
    {
        public string NroDni { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }

        public Cliente(string nroDni, string nombres, string direccion)
        {
            NroDni = nroDni;
            Nombres = nombres;
            Direccion = direccion;
        }

        public override string ToString()
        {
            return $"DNI: {NroDni}, Nombres: {Nombres}, Dirección: {Direccion}";
        }
    }

    internal class Movimiento
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // "Abono" o "Cargo"
        public double Monto { get; set; }

        public Movimiento(DateTime fecha, string tipo, double monto)
        {
            Fecha = fecha;
            Tipo = tipo;
            Monto = monto;
        }

        public override string ToString()
        {
            return $"{Fecha.ToString("dd/MM/yyyy")}: {Tipo} de {Monto:C}";
        }
    }

    internal class Nodo
    {
        public Movimiento Movimiento { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Movimiento movimiento)
        {
            Movimiento = movimiento;
            Siguiente = null;
        }
    }

    internal class CLista
    {
        private Nodo cabeza;

        public CLista()
        {
            cabeza = null;
        }

        public void Agregar(Movimiento movimiento)
        {
            Nodo nuevoNodo = new Nodo(movimiento);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo temp = cabeza;
                while (temp.Siguiente != null)
                {
                    temp = temp.Siguiente;
                }
                temp.Siguiente = nuevoNodo;
            }
        }

        public double CalcularSaldo()
        {
            double saldo = 0;
            Nodo temp = cabeza;

            while (temp != null)
            {
                if (temp.Movimiento.Tipo == "Abono")
                {
                    saldo += temp.Movimiento.Monto;
                }
                else if (temp.Movimiento.Tipo == "Cargo")
                {
                    saldo -= temp.Movimiento.Monto;
                }
                temp = temp.Siguiente;
            }

            return saldo;
        }

        public void MostrarMovimientos()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay movimientos registrados.");
                return;
            }

            Nodo temp = cabeza;
            while (temp != null)
            {
                Console.WriteLine(temp.Movimiento);
                temp = temp.Siguiente;
            }
        }
    }

    internal class CuentaBancaria
    {
        public Cliente Cliente { get; private set; }
        public CLista Movimientos { get; private set; }

        public CuentaBancaria(Cliente cliente)
        {
            Cliente = cliente;
            Movimientos = new CLista();
        }

        public void AgregarMovimiento(Movimiento movimiento)
        {
            Movimientos.Agregar(movimiento);
        }

        public double CalcularSaldo()
        {
            return Movimientos.CalcularSaldo();
        }

        public void MostrarMovimientos()
        {
            Console.WriteLine("Movimientos de la cuenta:");
            Movimientos.MostrarMovimientos();
        }
    }
}
