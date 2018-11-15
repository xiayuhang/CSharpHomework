using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework7
{
    //订单信息
    public class Order
    {
        private double totalPrice;
        //订单号
        public string OrderNumber { set; get; }
        //客户姓名
        public string Client { set; get; }
        //客户电话
        public string PhoneNumber { set; get; }
        //商品条目
        public List<OrderDetails> detailsList = new List<OrderDetails>();
        public List<OrderDetails> DetailsList { get { return detailsList; } }
        //总价
        public double TotalPrice
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
    }
}
