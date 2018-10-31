using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form2 : Form
    {
        public Order order = new Order();
        public List<OrderDetails> orderDetails = new List<OrderDetails>();

        public Form2()
        {
            InitializeComponent();
        }
        //形参为Order的构造函数，用于修改订单
        public Form2(Order curOrder)
        {
            InitializeComponent();
            order = curOrder;
            textBox1.Text = curOrder.Client;
            textBox2.Text = curOrder.OrderNumber;
            orderDetails = curOrder.detailsList;
            for (int i = 0; i < orderDetails.Count; i++)
                bsDetail2.Add(orderDetails[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderDetails orderDetail = new OrderDetails();
            orderDetail.Item = textBox3.Text;
            orderDetail.Count = Int32.Parse(textBox4.Text);
            orderDetail.Price = Double.Parse(textBox5.Text);
            //添加数据到bsDetail2，从而在datagridview中显示
            bsDetail2.Add(orderDetail);
            orderDetails.Add(orderDetail);

            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            order.Client = textBox1.Text;
            order.OrderNumber = textBox2.Text;
            order.detailsList = orderDetails;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //DeleteItem属性并将其设置(无)，重写点击事件，以便删除List中的元素
            OrderDetails cur = (OrderDetails)bsDetail2.Current;
            if (cur != null)
            {
                bsDetail2.Remove(cur);
                orderDetails.Remove(cur);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Close();
        }
    }
}
