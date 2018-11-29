using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework10
{
    class OrderService
    {
        public void Add(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(String orderId)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("Items").SingleOrDefault(o => o.OrderNumber == orderId); //Include()，把指定的外键表信息也读出来
                db.OrderItem.RemoveRange(order.Items);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.Items.ForEach(item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Items").ToList<Order>();
            }
        }

        public Order QueryById(String Id)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Items").SingleOrDefault(order => order.OrderNumber == Id);
            }
        }

        public List<Order> QueryByClient(String client)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Items").Where(order => order.Client.Equals(client)).ToList<Order>();
            }
        }

        public List<Order> QueryByGoods(String product)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Items").Where(order => order.Items.Where(
                    item => item.Product.Equals(product)).Count() > 0).ToList<Order>();
            }
        }

        public List<Order> QueryBigOrder()
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Items").Where(order => order.TotalPrice > 10000).ToList<Order>();
            }
        }

        //序列化操作
        public void Export(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xml.Serialize(fs, this.GetAllOrders());
            }
        }
    }
}
