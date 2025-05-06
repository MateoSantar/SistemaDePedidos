using System;
using System.Collections.Generic;
using Controllers;
using Models;
namespace SistemaDePedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderController oc = new OrderController();
            int opcion;
            Console.WriteLine("Bienvenido a mi sistema de pedidos.");
            do
            {
                Console.WriteLine("1. Cargar orden");
                Console.WriteLine("2. Mostrar ordenes");
                Console.WriteLine("3. Actualizar orden");
                Console.WriteLine("4. Eliminar orden");
                Console.WriteLine("5. Salir");
                Console.Write("Que desea hacer:");
                if (!int.TryParse(Console.ReadLine(),out opcion) && opcion <1 && opcion >5)
                {
                    Console.WriteLine("Ingrese un valor valido.");
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            oc.CreateOrder();
                            break;
                        case 2:
                            if (oc.getOrderList().Count == 0)
                            {
                                Console.WriteLine("No hay ordenes cargadas.");
                            }
                            else
                            {
                                oc.ShowOrders();

                            }
                            break;
                        case 3:
                            if (oc.getOrderList().Count == 0)
                            {
                                Console.WriteLine("No hay ordenes cargadas.");
                            }
                            else
                            {
                                oc.UpdateOrder();
                            }
                            break;
                        case 4:
                            if (oc.getOrderList().Count == 0)
                            {
                                Console.WriteLine("No hay ordenes cargadas.");
                            }
                            else
                            {
                                oc.DeleteOrder();
                            }
                            break;
                        default:
                            break;
                    }
                }
            } while (opcion != 5);
        }
    }
}
