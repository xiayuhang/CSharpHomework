using System;
using homework6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace OrderTest
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(3, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);

            Dictionary<uint, Order> result = new Dictionary<uint, Order>
            {
                [1] = order1
            };
            CollectionAssert.AreEqual(os.orderDict, result);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod()]
        public void AddOrderTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(3, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order1);//重复添加
        }


        [TestMethod()]
        public void RemoveOrderTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 20);
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer1);
            order1.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.RemoveOrder(1);

            Dictionary<uint, Order> result = new Dictionary<uint, Order>();
            result[2] = order2;
            CollectionAssert.AreEqual(os.orderDict, result);
        }

        [TestMethod()]
        public void QueryAllOrdersTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(3, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> orders = os.QueryAllOrders();

            List<Order> result = new List<Order>()
            {
                order1
            };
            CollectionAssert.AreEqual(orders, result);
        }

        [TestMethod()]
        public void GetByIdTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(3, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            Order order = os.GetById(1);

            Assert.AreEqual(order, order1);
        }

        [ExpectedException(typeof(KeyNotFoundException))]
        [TestMethod()]
        public void GetByIdTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(3, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            Order order = os.GetById(2);

            Assert.AreEqual(order, order1);
        }

        [TestMethod()]
        public void QueryByGoodsNameTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(3, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> orders = os.QueryByGoodsName("apple");

            List<Order> result = new List<Order>
            {
                order1
            };
            CollectionAssert.AreEqual(orders, result);
        }

        [TestMethod()]
        public void QueryByCustomerNameTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(3, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> orders = os.QueryByCustomerName("Customer1");

            List<Order> result = new List<Order>
            {
                order1
            };
            CollectionAssert.AreEqual(orders, result);
        }

        [TestMethod()]
        public void UpdateCustomerTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Goods apple = new Goods(3, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 20);
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(1, customer2);
            order1.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.UpdateCustomer(1, customer2);

            Assert.AreEqual(order1.ToString(), order2.ToString());
        }
    }
}
