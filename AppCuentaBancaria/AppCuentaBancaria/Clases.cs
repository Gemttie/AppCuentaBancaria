//FARFAN CARRION JOSEPH MATTHEW 221447

using System;
using System.Collections.Generic;

namespace AppCuentaBancaria
{
    //----------------------------
    //CLASE CLIENTE
    //----------------------------
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

    //----------------------------
    //CLASE MOVIMIENTO
    //----------------------------
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


    //----------------------------
    //CLASE CUENTA BANCARIA
    //----------------------------

    internal class CuentaBancaria
    {
        public Cliente Cliente { get; private set; }
        public List<Movimiento> Movimientos { get; private set; }

        public CuentaBancaria(Cliente cliente)
        {
            Cliente = cliente;
            Movimientos = new List<Movimiento>();
        }

        public void AgregarMovimiento(Movimiento movimiento)
        {
            Movimientos.Add(movimiento);
        }

        public double CalcularSaldo()
        {
            double saldo = 0;

            foreach (var movimiento in Movimientos)
            {
                if (movimiento.Tipo == "Abono")
                {
                    saldo += movimiento.Monto;
                }
                else if (movimiento.Tipo == "Cargo")
                {
                    saldo -= movimiento.Monto;
                }
            }

            return saldo;
        }

        public void MostrarMovimientos()
        {
            if (Movimientos.Count == 0)
            {
                Console.WriteLine("No hay movimientos registrados.");
            }
            else
            {
                foreach (var movimiento in Movimientos)
                {
                    Console.WriteLine(movimiento);
                }
            }
        }
    }
}
