using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class NotFoundException : ApplicationException
    {
        public NotFoundException(String message) : base(message) { }
    }

    class Order
    {
        private double totalPrice;

        public string Client { set; get; }   //客户姓名
        public string OrderNumber { set; get; }   //订单号
        public List<OrderDetails> detailsList = new List<OrderDetails>();   //商品条目
        public double TotalPrice   //总价
        {
            set
            {
                //用Linq设置订单总价
                var query = detailsList;
                totalPrice = query.Sum(details => details.TotalPrice);
            }
            get
            {
                //用Linq得到订单总价
                var query = detailsList;
                totalPrice = query.Sum(details => details.TotalPrice);
                return totalPrice;
            }
        }

        public void AddOrderDetails()
        {
            while (true)
            {
                OrderDetails orderDetails = new OrderDetails();
                Console.WriteLine("   >>添加商品:");
                Console.Write("请输入商品名称：");
                orderDetails.Name = Console.ReadLine();
                Console.Write("请输入商品数量：");
                orderDetails.Count = Int32.Parse(Console.ReadLine());
                Console.Write("请输入商品单价：");
                orderDetails.Price = Double.Parse(Console.ReadLine());
                detailsList.Add(orderDetails);
                Console.WriteLine("添加商品成功！");
                Console.Write("是否继续添加（1：继续添加商品；其他：返回）：");
                int flag = 0;
                try
                {
                    flag = Int32.Parse(Console.ReadLine());
                }
                catch (SystemException e)
                {
                    Console.WriteLine("输入错误：" + e.Message);
                }
                if (flag == 1)
                    continue;
                else
                    Console.WriteLine();
                break;
            }
        }
    }

    class OrderDetails
    {
        private double totalPrice;

        public string Name { set; get; }   //商品名称
        public int Count { set; get; }   //商品数目
        public double Price { set; get; }   //商品单价
        public double TotalPrice   //商品总价
        {
            set
            {
                totalPrice = Count * Price;
            }
            get
            {
                totalPrice = Count * Price;
                return totalPrice;
            }
        }
    }

    class OrderService
    {
        private int orderNum = 0;   //订单号生成
        public List<Order> orderList = new List<Order>();   //订单list

        //添加订单
        public void AddOrder()
        {
            Order order = new Order();
            Console.WriteLine();
            Console.Write("请输入客户名字：");
            order.Client = Console.ReadLine();
            order.OrderNumber = (++orderNum).ToString();
            order.AddOrderDetails();
            orderList.Add(order);
        }

        //删除订单
        public void DeleteOrder()
        {
            Console.Write("1：按客户名字删除；2：按订单号删除 ：");
            int flag = 0;
            try
            {
                flag = Int32.Parse(Console.ReadLine());
            }
            catch (SystemException e)
            {
                Console.WriteLine("输入错误：" + e.Message);
            }
            if (flag == 1)
            {
                bool find = false;
                Console.Write("请输入客户名字：");
                string tempClient = Console.ReadLine();
                foreach (Order order in orderList)
                {
                    if (order.Client == tempClient)
                    {
                        orderList.Remove(order);
                        find = true;
                        Console.WriteLine("删除成功！");
                        break;
                    }
                }
                if (!find)
                {
                    throw new NotFoundException("未查询到订单！");
                }
            }
            else if (flag == 2)
            {
                bool find = false;
                Console.Write("请输入订单号：");
                string tempNum = Console.ReadLine();
                foreach (Order order in orderList)
                {
                    if (order.OrderNumber == tempNum)
                    {
                        orderList.Remove(order);
                        find = true;
                        Console.WriteLine("删除成功！");
                        break;
                    }
                }
                if (!find)
                {
                    throw new NotFoundException("未查询到订单！");
                }
            }
            else
            {
                Console.WriteLine("输入失败！");
            }
        }

        //修改订单
        public void ChangeOrder()
        {
            Console.Write("1：查询客户名字修改；2：查询订单号修改 ：");
            int flag = 0;
            try
            {
                flag = Int32.Parse(Console.ReadLine());
            }
            catch (SystemException e)
            {
                Console.WriteLine("输入错误：" + e.Message);
            }
            if (flag == 1)
            {
                bool find = false;
                Console.Write("请输入客户名字：");
                string tempClient = Console.ReadLine();
                foreach (Order order in orderList)
                {
                    if (order.Client == tempClient)
                    {
                        Console.WriteLine("请重新输入此订单：");
                        Console.Write("请输入客户名字：");
                        order.Client = Console.ReadLine();
                        order.detailsList.Clear();
                        order.AddOrderDetails();
                        find = true;
                        Console.WriteLine("修改成功！");
                        break;
                    }
                }
                if (!find)
                {
                    throw new NotFoundException("未查询到订单！");
                }
            }
            else if (flag == 2)
            {
                bool find = false;
                Console.Write("请输入订单号：");
                string tempNum = Console.ReadLine();
                foreach (Order order in orderList)
                {
                    if (order.OrderNumber == tempNum)
                    {
                        Console.WriteLine("请重新输入此订单：");
                        Console.Write("请输入客户名字：");
                        order.Client = Console.ReadLine();
                        order.detailsList.Clear();
                        order.AddOrderDetails();
                        find = true;
                        Console.WriteLine("修改成功！");
                        break;
                    }
                }
                if (!find)
                {
                    throw new NotFoundException("未查询到订单！");
                }
            }
            else
            {
                Console.WriteLine("输入失败！");
            }
        }

        //显示订单
        public void ShowOrder(Order order)
        {
            Console.WriteLine("\n订单号：" + order.OrderNumber);
            Console.WriteLine("客户：" + order.Client);
            Console.WriteLine("******************************");
            foreach (OrderDetails orderDetails in order.detailsList)
            {
                Console.WriteLine("商品名称：" + orderDetails.Name);
                Console.WriteLine("数目：" + orderDetails.Count);
                Console.WriteLine("单价：" + orderDetails.Price);
                Console.WriteLine("此商品总价：" + orderDetails.TotalPrice);
                Console.WriteLine("******************************");
            }
            Console.WriteLine("总价：" + order.TotalPrice);
        }
        public void ShowBigOrder()
        {
            var query = orderList
                       .Where(order => order.TotalPrice > 10000);
            List<Order> list = query.ToList();
            foreach (Order order in list)
            {
                ShowOrder(order);
            }
        }
        public void ShowAllOrder()
        {
            foreach (Order order in orderList)
            {
                ShowOrder(order);
            }
        }

        /*
        查询订单
        public void SearchOrder()
        {
            Console.Write("1：客户名字查找；2：订单号查找 ：");
            int flag = 0;
            try
            {
                flag = Int32.Parse(Console.ReadLine());
            }
            catch (SystemException e)
            {
                Console.WriteLine("输入错误：" + e.Message);
            }
            if (flag == 1)
            {
                bool find = false;
                Console.Write("请输入客户名字：");
                string tempClient = Console.ReadLine();
                foreach (Order order in orderList)
                {
                    if (order.Client == tempClient)
                    {
                        Console.WriteLine("\n订单号：" + order.OrderNumber);
                        Console.WriteLine("客户：" + order.Client);
                        Console.WriteLine("******************************");
                        foreach (OrderDetails orderDetails in order.detailsList)
                        {
                            Console.WriteLine("商品名称：" + orderDetails.Name);
                            Console.WriteLine("数目：" + orderDetails.Count);
                            Console.WriteLine("单价：" + orderDetails.Price);
                            Console.WriteLine("总价：" + orderDetails.TotalPrice);
                            Console.WriteLine("******************************");
                        }
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    throw new NotFoundException("未查询到订单！");
                }
            }
            else if (flag == 2)
            {
                bool find = false;
                Console.Write("请输入订单号：");
                string tempNum = Console.ReadLine();
                foreach (Order order in orderList)
                {
                    if (order.OrderNumber == tempNum)
                    {
                        Console.WriteLine("\n订单号：" + order.OrderNumber);
                        Console.WriteLine("客户：" + order.Client);
                        Console.WriteLine("******************************");
                        foreach (OrderDetails orderDetails in order.detailsList)
                        {
                            Console.WriteLine("商品名称：" + orderDetails.Name);
                            Console.WriteLine("数目：" + orderDetails.Count);
                            Console.WriteLine("单价：" + orderDetails.Price);
                            Console.WriteLine("总价：" + orderDetails.TotalPrice);
                            Console.WriteLine("******************************");
                        }
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    throw new NotFoundException("未查询到订单！");
                }
            }
            else
            {
                Console.WriteLine("输入失败！");
            }
        }
        */

        //查询订单
        public void SearchOrder()
        {
            Console.Write("1：客户名字查找；2：商品名称查找 ：");
            int flag = 0;
            try
            {
                flag = Int32.Parse(Console.ReadLine());
            }
            catch (SystemException e)
            {
                Console.WriteLine("输入错误：" + e.Message);
            }
            if (flag == 1)
            {
                Console.Write("请输入客户名字：");
                string tempClient = Console.ReadLine();
                var query = from order in orderList
                            where order.Client == tempClient
                            select order;       //Linq查询表达式语法
                if (query.Count() == 0)
                {
                    throw new NotFoundException("未查询到订单！");
                }
                else
                {
                    List<Order> list = query.ToList();
                    foreach (Order order in list)
                    {
                        ShowOrder(order);
                    }
                }
            }
            else if (flag == 2)
            {
                Console.Write("请输入商品名称：");
                string tempName = Console.ReadLine();
                var query = orderList
                           .Where(order =>
                           {
                               foreach (OrderDetails details in order.detailsList)
                               {
                                   if (details.Name == tempName)
                                       return true;
                               }
                               return false;
                           });             //Linq查询方法语法
                if (query.Count() == 0)
                {
                    throw new NotFoundException("未查询到订单！");
                }
                else
                {
                    List<Order> list = query.ToList();
                    foreach (Order order in list)
                    {
                        ShowOrder(order);
                    }
                }
            }
            else
            {
                Console.WriteLine("输入失败！");
            }
        }

        //订单服务操作
        public void Operation()
        {
            int flag = 1;
            while (flag == 1)   //循环执行
            {
                Console.Write("1:添加订单 2:删除订单 3:修改订单 4:查询订单 5:查询订单金额大于1万元的订单 6:查看当前所有订单 其他:退出\n请选择:");
                int sel = 0;
                try
                {
                    sel = Int32.Parse(Console.ReadLine());
                }
                catch (SystemException e)
                {
                    Console.WriteLine("输入错误：" + e.Message);
                }
                switch (sel)
                {
                    case 1:
                        AddOrder();
                        Console.WriteLine();
                        break;
                    case 2:
                        try
                        {
                            DeleteOrder();
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine("删除失败，原因：" + e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        try
                        {
                            ChangeOrder();
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine("修改失败，原因：" + e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        try
                        {
                            SearchOrder();
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        ShowBigOrder();
                        Console.WriteLine();
                        break;
                    case 6:
                        ShowAllOrder();
                        Console.WriteLine();
                        break;
                    default:
                        flag = 0;
                        break;
                }
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            orderService.Operation();
        }
    }
}
