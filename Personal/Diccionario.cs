using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Tienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<string, string>> diccionario = CrearDiccionario();
            Traducir(diccionario);
        }

        static List<Tuple<string, string>> CrearDiccionario()
        {
            List<Tuple<string, string>> diccionario = new List<Tuple<string, string>>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Introduzca la palabra {i + 1} en inglés: ");
                string palabraIngles = Console.ReadLine();
                Console.Write($"Introduzca la palabra {i + 1} en español: ");
                string palabraEspanol = Console.ReadLine();
                diccionario.Add(new Tuple<string, string>(palabraIngles, palabraEspanol));
            }

            return diccionario;
        }

        static void Traducir(List<Tuple<string, string>> diccionario)
        {
            Console.Write("Introduzca la palabra a traducir: ");
            string palabra = Console.ReadLine();
            bool encontrada = false;

            foreach (var entrada in diccionario)
            {
                if (entrada.Item1.Equals(palabra, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"La traducción de {palabra} es: {entrada.Item2}");
                    encontrada = true;
                    break;
                }
                else if (entrada.Item2.Equals(palabra, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"La traducción de {palabra} es: {entrada.Item1}");
                    encontrada = true;
                    break;
                }
            }

            if (!encontrada)
            {
                Console.WriteLine($"La palabra '{palabra}' no se encontró en el diccionario.");
            }
            Console.ReadLine();
        }
    }
}
