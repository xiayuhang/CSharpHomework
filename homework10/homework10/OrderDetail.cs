using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework10
{
//订单条目信息
    public class OrderDetails
    {
        private double totalPrice;
        //商品名称
        public string Item { set; get; }
        //商品单价
        public double Price { set; get; }
        //商品数目
        public int Count { set; get; }
        //商品总价
        public double TotalPrice
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
}
