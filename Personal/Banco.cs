using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Tienda
{
    internal class Program
    {
        static float saldo = 0;

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("\nMenú de opciones:");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: ConsultarSaldo(); break;
                    case 2: Depositar(); break;
                    case 3: Retirar(); break;
                }
            } while (opcion != 4);
        }

        static void ConsultarSaldo()
        {
            Console.WriteLine($"Su saldo actual es: {saldo}");
        }

        static void Depositar()
        {
            Console.Write("Ingrese la cantidad a depositar: ");
            float cantidad = float.Parse(Console.ReadLine());
            saldo += cantidad;
            Console.WriteLine("Depósito exitoso.");
        }

        static void Retirar()
        {
            Console.Write("Ingrese la cantidad a retirar: ");
            float cantidad = float.Parse(Console.ReadLine());
            if (cantidad <= saldo)
            {
                saldo -= cantidad;
                Console.WriteLine("Retiro exitoso.");
            }
            else
            {
                Console.WriteLine("Fondos insuficientes.");
            }
        }
    }
}
