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
            List<Tuple<int, string, int, float>> inventario = new List<Tuple<int, string, int, float>>();
            int opcion = 0;
            do
            {
                Console.WriteLine("\nMenú de opciones:");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Modificar producto");
                Console.WriteLine("4. Consultar producto");
                Console.WriteLine("5. Mostrar todos los productos");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: AgregarProducto(inventario); break;
                    case 2: EliminarProducto(inventario); break;
                    case 3: ModificarProducto(inventario); break;
                    case 4: ConsultarProducto(inventario); break;
                    case 5: MostrarProductos(inventario); break;
                }
            } while (opcion != 6);
        }

        public static void AgregarProducto(List<Tuple<int, string, int, float>> inventario)
        {
            Console.Write("Ingrese el código del producto: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la cantidad del producto: ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio del producto: ");
            float precio = float.Parse(Console.ReadLine());
            inventario.Add(new Tuple<int, string, int, float>(codigo, nombre, cantidad, precio));
            Console.WriteLine("Producto agregado con éxito.");
        }

        public static void EliminarProducto(List<Tuple<int, string, int, float>> inventario)
        {
            Console.Write("Ingrese el código del producto a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());
            var producto = inventario.FirstOrDefault(p => p.Item1 == codigo);
            if (producto != null)
            {
                inventario.Remove(producto);
                Console.WriteLine("Producto eliminado.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public static void ModificarProducto(List<Tuple<int, string, int, float>> inventario)
        {
            Console.Write("Ingrese el código del producto a modificar: ");
            int codigo = int.Parse(Console.ReadLine());
            var producto = inventario.FirstOrDefault(p => p.Item1 == codigo);
            if (producto != null)
            {
                Console.Write("Nuevo nombre del producto: ");
                string nombre = Console.ReadLine();
                Console.Write("Nueva cantidad del producto: ");
                int cantidad = int.Parse(Console.ReadLine());
                Console.Write("Nuevo precio del producto: ");
                float precio = float.Parse(Console.ReadLine());
                inventario[inventario.IndexOf(producto)] = new Tuple<int, string, int, float>(codigo, nombre, cantidad, precio);
                Console.WriteLine("Producto modificado.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public static void ConsultarProducto(List<Tuple<int, string, int, float>> inventario)
        {
            Console.Write("Ingrese el código del producto a consultar: ");
            int codigo = int.Parse(Console.ReadLine());
            var producto = inventario.FirstOrDefault(p => p.Item1 == codigo);
            if (producto != null)
            {
                Console.WriteLine($"Código: {producto.Item1}, Nombre: {producto.Item2}, Cantidad: {producto.Item3}, Precio: {producto.Item4}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public static void MostrarProductos(List<Tuple<int, string, int, float>> inventario)
        {
            if (inventario.Count > 0)
            {
                foreach (var producto in inventario)
                {
                    Console.WriteLine($"Código: {producto.Item1}, Nombre: {producto.Item2}, Cantidad: {producto.Item3}, Precio: {producto.Item4}");
                }
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario.");
            }
        }
    }
}
