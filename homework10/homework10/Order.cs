using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;

namespace homework10
{
    //订单信息
    public class Order
    {
        public String OrderNumber { get; set; }        //订单号
        public string Client { set; get; }   //客户姓名
        public string PhoneNumber { set; get; }   //手机号
        public List<OrderItem> Items { get; set; }
        private double totalPrice;
        public List<OrderDetails> detailsList = new List<OrderDetails>();
        public List<OrderDetails> DetailsList { get { return detailsList; } }
        public double TotalPrice   //总价
        {
            set
            {
                //用Linq设置订单总价
                var query = Items;
                totalPrice = query.Sum(details => details.TotalPrice);
            }
            get
            {
                //用Linq得到订单总价
                var query = Items;
                totalPrice = query.Sum(details => details.TotalPrice);
                return totalPrice;
            }
        }

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public Order(string ordernumber, string client, string phonenumber, List<OrderItem> items)
        {
            OrderNumber = ordernumber;
            Client = client;
            PhoneNumber = phonenumber;
            Items = items;
        }
    }

    public class OrderItem
    {
        public string Id { get; set; }

        public string Product { get; set; }   //商品名称
        public double Price { set; get; }   //商品单价
        public int Count { set; get; }   //商品数目
        private double totalPrice;
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

        public OrderItem()
        {
            Id = Guid.NewGuid().ToString();
        }

        public OrderItem(string id, string product, double price, int count)
        {
            Id = id;
            Product = product;
            Price = price;
            Count = count;
        }
    }

    public class OrderDB : DbContext
    {
        public OrderDB() : base("OrderData")
        {
        }
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

    }
}
