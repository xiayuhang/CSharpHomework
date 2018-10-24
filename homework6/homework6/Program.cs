using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods A = new Goods(1, "A", 25.5);
                Goods B = new Goods(2, "B", 32.5);
                Goods C = new Goods(3, "C", 29.5);

                OrderDetail orderDetails1 = new OrderDetail(1, A, 2);
                OrderDetail orderDetails2 = new OrderDetail(2, B, 3);
                OrderDetail orderDetails3 = new OrderDetail(3, C, 4);

                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer2);
                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);
                order1.AddDetails(orderDetails3);
                //order1.AddOrderDetails(orderDetails3);
                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails3);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);

                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("Find bigger than 70:");
                os.GetBigger().ForEach(
                    od => Console.WriteLine(od));

                Console.WriteLine("Please input the goods' name you want to search:");
                string str = Console.ReadLine();
                os.QueryByGoodsName(str).ForEach(
                    od => Console.WriteLine(od));

                Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                orders = os.QueryByCustomerName("Customer2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                orders = os.QueryByGoodsName("apple");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("Remove order(id=2) and qurey all");
                os.RemoveOrder(2);
                os.QueryAllOrders().ForEach(
                    od => Console.WriteLine(od));

                os.Export(order1, "E:\\xyh.txt");

                Type type = typeof(Order);
                Order order4 = OrderService.Import("E:\\xyh.txt", type) as Order;
                Console.WriteLine("imported order:\n" + order4.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
