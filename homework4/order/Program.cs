using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order
{
    class Order
    {
        public string id;
        public List<OrderDetails> OrderList = new List<OrderDetails>();//建立订单列表
        public Order(string id)
        {
            this.id = id;
        }
        public void AddDetails(OrderDetails od)//添加条目
        {
            this.OrderList.Add(od);
        }
        public void DeleteDetails(OrderDetails od)//删除条目
        {
            try
            {
                this.OrderList.Remove(od);
            }
            catch (Exception e)
            {
                Console.WriteLine("订单列表为空，无法删除");
            }
        }
        public int FindDetails(string s)//检索条目
        {
            for (int i = 0; i < this.OrderList.Count; i++)
            {
                if (this.OrderList[i].dic[0] == s || this.OrderList[i].dic[1] == s)
                    return i;
            }
            return -1;
        }
        public void PrintDetails()//打印条目
        {
            foreach (OrderDetails od in this.OrderList)
            {
                Console.WriteLine(od.dic[0] + " " + od.dic[1] + " " + od.dic[2] + " " + od.dic[3]);
            }
        }

    }

    class OrderDetails
    {
        public Dictionary<int, string> dic = new Dictionary<int, string>();

        public OrderDetails(string name = "", string cname = "", string num = "", string price = "")
        {
            dic[0] = name;//商品名
            dic[1] = cname;//客户名
            dic[2] = num;//商品数量
            dic[3] = price;//商品价格
        }
    }

    class OrderService
    {
        public void AddOrder(List<Order> list, Order order)//增加订单
        {
            list.Add(order);
        }
        public void DeleteOrder(List<Order> list, Order order)//增加订单
        {
            try
            {
                list.Remove(order);
            }
            catch (Exception e)
            {
                Console.WriteLine("订单数为0，无法删除");
            }
        }
        public int FindOrder(List<Order> list, string s)//查询订单，返回下标
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (s == list[i].id)
                    return i;
                foreach (OrderDetails od in list[i].OrderList)
                {
                    if (od.dic[0] == s || od.dic[1] == s)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public void ChangeOrder(List<Order> list, int index, int i, int j, string s)//修改index订单第i条目第j属性
        {
            try
            {
                list[index].OrderList[i].dic[j] = s;
            }
            catch (Exception e)
            {
                Console.WriteLine("无法修改");
            }
        }

        static void Main(string[] args)
        {
            List<Order> list = new List<Order>();//订单列表

            OrderService os = new OrderService();

            OrderDetails od1 = new OrderDetails("xxx", "a", "10", "10");
            OrderDetails od2 = new OrderDetails("hhh", "b", "11", "11");
            OrderDetails od3 = new OrderDetails("kkk", "c", "12", "12");//初始化条目

            Order order1 = new Order("001");
            Order order2 = new Order("002");
            Order order3 = new Order("003");
            order1.AddDetails(od1);
            order2.AddDetails(od2);
            order3.AddDetails(od3);//初始化订单

            os.AddOrder(list, order1);
            os.AddOrder(list, order2);
            os.DeleteOrder(list, order3);//增减订单

            //查询并打印
            int index = os.FindOrder(list, "xxx");//订单下标
            int i = list[index].FindDetails("xxx");//订单中条目下标
            os.ChangeOrder(list, index, i, 0, "嘻嘻嘻");//修改订单
            foreach (Order od in list)
            {
                od.PrintDetails();//打印
            }
        }
    }
}
