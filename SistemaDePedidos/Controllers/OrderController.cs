using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Models;
using Views;
using Repository;
namespace Controllers
{
    class OrderController
    {
        private ClientController cController;
        private ProductController pController;
        private List<Order> orderList;

        public List<Order> getOrderList()
        {
            return this.orderList;
        }
        public OrderController()
        {
            this.cController = new ClientController();
            this.pController = new ProductController();
            this.orderList = Repository<Order>.ObtenerTodos("ordenes");
        }

        public void CreateOrder()
        {
            Order temp = new Order();
            temp.client = cController.LoadClient();
            temp.setProductList(pController.LoadProductList());
            Repository<Order>.Agregar("ordenes", temp);
            this.orderList.Add(temp);
        }

        public void ShowOrders()
        {
            for (int i = 0; i < orderList.Count; i++)
            {
                OrderView.ShowMsg("Order N* " + (i+1));
                cController.ShowClient(orderList[i].client);
                pController.ShowProductList(orderList[i].getProductList());
            }
        }

        public void UpdateOrder()
        {
            try
            {
                ShowOrders();
                OrderView.ShowMsg("Orden a modificar (Indice): ");
                int index = int.Parse(Console.ReadLine()) - 1;
                Order order = orderList[index];
                OrderView.ShowMsg("1. Cliente");
                OrderView.ShowMsg("2. Lista de Productos");
                OrderView.ShowMsg("Que desea actualizar de la orden: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        order.client = cController.LoadClient();
                        OrderView.ShowMsg("Actualizado!");
                        break;
                    case "2":
                        order.setProductList(pController.LoadProductList());
                        OrderView.ShowMsg("Actualizado!");
                        break;
                    default:
                        break;
                }
                        Repository<Order>.Actualizar("ordenes", index, order);
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine("Error: No hay una orden en ese indice");
            }

        }

        public void DeleteOrder()
        {
            ShowOrders();
            OrderView.ShowMsg("Orden a eliminar: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            orderList.RemoveAt(index);
            Repository<Order>.Eliminar("ordenes", index);
            Console.WriteLine("Eliminado!");
        }


        

    }
}
