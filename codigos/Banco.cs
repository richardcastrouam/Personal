using System;
using System.Collections.Generic;

namespace Banco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<string, float>> transacciones = new List<Tuple<string, float>>();
            int opcion = 0;
            do
            {
                Console.WriteLine("\nMenú de opciones:");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Mostrar todas las transacciones");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, introduzca un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1: ConsultarSaldo(transacciones); break;
                    case 2: Depositar(transacciones); break;
                    case 3: Retirar(transacciones); break;
                    case 4: MostrarTransacciones(transacciones); break;
                }
            } while (opcion != 5);
        }

        static void ConsultarSaldo(List<Tuple<string, float>> transacciones)
        {
            float saldo = CalcularSaldo(transacciones);
            Console.WriteLine($"Su saldo actual es: {saldo:C}");
        }

        static void Depositar(List<Tuple<string, float>> transacciones)
        {
            Console.Write("Ingrese la cantidad a depositar: ");
            if (float.TryParse(Console.ReadLine(), out float cantidad) && cantidad > 0)
            {
                transacciones.Add(new Tuple<string, float>("Depósito", cantidad));
                Console.WriteLine("Depósito exitoso.");
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
        }

        static void Retirar(List<Tuple<string, float>> transacciones)
        {
            Console.Write("Ingrese la cantidad a retirar: ");
            if (float.TryParse(Console.ReadLine(), out float cantidad) && cantidad > 0)
            {
                float saldo = CalcularSaldo(transacciones);
                if (cantidad <= saldo)
                {
                    transacciones.Add(new Tuple<string, float>("Retiro", -cantidad));
                    Console.WriteLine("Retiro exitoso.");
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes.");
                }
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
        }

        static float CalcularSaldo(List<Tuple<string, float>> transacciones)
        {
            float saldo = 0;
            foreach (var transaccion in transacciones)
            {
                saldo += transaccion.Item2;
            }
            return saldo;
        }

        static void MostrarTransacciones(List<Tuple<string, float>> transacciones)
        {
            if (transacciones.Count == 0)
            {
                Console.WriteLine("No hay transacciones registradas.");
                return;
            }

            Console.WriteLine("\nHistorial de transacciones:");
            foreach (var transaccion in transacciones)
            {
                Console.WriteLine($"{transaccion.Item1}: {transaccion.Item2:C}");
            }
        }
    }
}
