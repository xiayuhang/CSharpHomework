using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    //按顺序记录每个货物及其数量
    public class Order
    {
        public Order()
        {

        }

        public List<OrderDetail> details = new List<OrderDetail>();

        //构造函数
        public Order(uint orderId, Customer customer)
        {
            Id = orderId;
            Customer = customer;
        }

        //订单标识符
        public uint Id { get; set; }

        //该货物的顾客
        public Customer Customer { get; set; }


        public List<OrderDetail> Details
        {
            get => details;
        }

        //向订单添加新订单的信息
        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }

        //按订单信息从订单中删除订单信息
        public void RemoveDetails(uint orderDetailId)
        {
            details.RemoveAll(d => d.Id == orderDetailId);
        }

        //重写字符串，返回订单的数据
        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer})";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }

        public double Money()
        {
            double sum = 0;
            foreach (OrderDetail orderDetail in Details)
            {
                sum += (orderDetail.Goods.Price * orderDetail.Quantity);
            }
            return sum;
        }
    }
}
