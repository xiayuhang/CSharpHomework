using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace homework6
{
    //实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    public class OrderService
    {
        public Dictionary<uint, Order> orderDict;
        //构造函数
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }
        
        //添加订单
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
        }

        //取消订单
        public void RemoveOrder(uint orderId)
        {
            orderDict.Remove(orderId);
        }

        //查询所有订单 
        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        //通过标识符查询订单 
        public Order GetById(uint orderId)
        {
            return orderDict[orderId];
        }

        //通过货物名字查询订单
        public List<Order> QueryByGoodsName(string goodsName)
        {
            var que = from o in orderDict.Values
                      from d in o.Details
                      where d.Goods.Name == goodsName
                      select o;
            return que.ToList();
        }

        //通过顾客名字查询订单
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        //编辑一个订单的顾客
        public void UpdateCustomer(uint orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }

        public List<Order> GetBigger()
        {
            var query = orderDict.Values
                .Where(order => order.Money() > 70);
            return query.ToList();
        }

        
        // 将所有订单序列化类到xml文档
        public bool Export(Order order, String filePath)
        {
            XmlWriter writer = null;    //声明一个xml编写器
            XmlWriterSettings writerSetting = new XmlWriterSettings //声明编写器设置
            {
                Indent = true,//定义xml格式，自动创建新的行
                Encoding = UTF8Encoding.UTF8,//编码格式
            };

            try
            {
                //创建一个保存数据到xml文档的流
                writer = XmlWriter.Create(filePath, writerSetting);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"创建xml文档失败：{0}", ex.Message);
                return false;
            }

            XmlSerializer xser = new XmlSerializer(typeof(Order));  //实例化序列化对象

            try
            {
                xser.Serialize(writer, order);  //序列化对象到xml文档
            }
            catch (Exception ex)
            {
                Console.WriteLine($"创建xml文档失败：{0}", ex.Message);
                return false;
            }
            finally
            {
                writer.Close();
            }
            return true;

        }
        
        // 从 XML 文档中反序列化为对象
        public static object Import(string filePath, Type type)
        {
            string xmlString = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(xmlString))
            {
                return null;
            }
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                try
                {
                    return serializer.Deserialize(stream);
                }
                catch
                {
                    return null;
                }
            }

        }
    }
}
