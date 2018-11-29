using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework10
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            OrderService orderService = new OrderService();

            List<OrderItem> items1 = new List<OrderItem>() {
                new OrderItem("1", "iPhone XR", 6499, 1),
                new OrderItem("2", "iPhone XS", 8699, 1),
                new OrderItem("3", "Airpords", 1199, 2)
            };

            List<OrderItem> items2 = new List<OrderItem>() {
                new OrderItem("4", "iPad Pro", 6499, 1),
                new OrderItem("5", "Airpords", 1199, 1)
            };

            //添加订单
            Order order1 = new Order("20181124001", "Alan", "18788888888", items1);
            orderService.Add(order1);

            Order order2 = new Order("20181124002", "Bob", "18777777777", items2);
            orderService.Add(order2);

            //修改订单
            Order order3 = new Order("20181124001", "Iggie", "18766666666", items1);
            orderService.Update(order3);

            //得到所有订单
            List<Order> orders = orderService.GetAllOrders();
            Console.WriteLine("所有订单:");
            orders.ForEach(o => Console.WriteLine(o.OrderNumber + " " + o.Client + " " + o.PhoneNumber + " " + o.TotalPrice));

            //Id查询
            Order order = orderService.QueryById("20181124002");
            Console.WriteLine("ID查询:");
            orders.ForEach(o => Console.WriteLine(o.OrderNumber + " " + o.Client + " " + o.PhoneNumber + " " + o.TotalPrice));

            //客户名查询
            orders = orderService.QueryByClient("Iggie");
            Console.WriteLine("客户名查询:");
            orders.ForEach(o => Console.WriteLine(o.OrderNumber + " " + o.Client + " " + o.PhoneNumber + " " + o.TotalPrice));

            //商品名查询
            orders = orderService.QueryByGoods("Airpords");
            Console.WriteLine("商品名查询:");
            orders.ForEach(o => Console.WriteLine(o.OrderNumber + " " + o.Client + " " + o.PhoneNumber + " " + o.TotalPrice));

            //总价大于10000元查询
            orders = orderService.QueryBigOrder();
            Console.WriteLine("总价大于10000元查询:");
            orders.ForEach(o => Console.WriteLine(o.OrderNumber + " " + o.Client + " " + o.PhoneNumber + " " + o.TotalPrice));

            //序列化
            string path = @"../../MyOrderList.xml";
            orderService.Export(path);

            //删除订单
            orderService.Delete("20181124002");
        }
    }
}
