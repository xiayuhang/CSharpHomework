using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            textBox6.Text = curOrder.PhoneNumber;
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

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //判断订单号是否存在
            bool flag = false; //订单号默认不存在
            Form1 form1 = new Form1();
            foreach (Order o in form1.orders)
            {
                if (o.OrderNumber == textBox2.Text)
                {
                    flag = true;
                    break;
                }
            }

            //正则表达式判断订单号
            String patternOfOrderNumber = "^(?:(?!0000)[0-9]{4}" +      //年
                "(?:(?:0[1-9]|1[0-2])(?:0[1-9]|1[0-9]|2[0-8])|" +       //月份+(1-28)日
                "(?:0[13-9]|1[0-2])(?:29|30)|" +                        //除2月外的月份+(29-30)日
                "(?:0[13578]|1[02])31)|" +                              //有31天的月份+(31)日
                "(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)0229)" + //闰年+2月+29日
                "(?:[0-9]{3})$";    //三位流水号
            Regex rx1 = new Regex(patternOfOrderNumber);
            Match matchOfOrderNumber = rx1.Match(textBox2.Text);

            //homework8 - 正则表达式判断手机号
            String patternOfPhone = "^1[34578][0-9]{9}$";
            Regex rx2 = new Regex(patternOfPhone);
            Match matchOfPhone = rx2.Match(textBox6.Text);

            if (flag)//订单号存在
                MessageBox.Show("此订单号已存在，订单创建失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //订单号不存在
                //数据验证
                if (matchOfOrderNumber.Success && matchOfPhone.Success)
                {
                    order.Client = textBox1.Text;
                    order.OrderNumber = textBox2.Text;
                    order.PhoneNumber = textBox6.Text;
                    order.detailsList = orderDetails;
                }
                else
                {
                    if (!matchOfOrderNumber.Success && !matchOfPhone.Success)
                        MessageBox.Show("订单号和手机号数据验证限制不匹配，订单创建失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (!matchOfOrderNumber.Success)
                        MessageBox.Show("订单号数据验证限制不匹配，订单创建失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (!matchOfPhone.Success)
                        MessageBox.Show("手机号数据验证限制不匹配，订单创建失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void HtmlCreate()
        {
            //创建DataTable，添加列
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("NAME", typeof(string));
            table.Columns.Add("PHONE", typeof(string));
            table.Columns.Add("GOODS", typeof(string));
            table.Columns.Add("QUANTITY", typeof(string));
            table.Columns.Add("PRICE", typeof(string));
            //再添加行
            table.Rows.Add(111, "Devesh", "Ghaziabad");
            table.Rows.Add(222, "ROLI", "KANPUR");
            table.Rows.Add(102, "ROLI", "MAINPURI");
            table.Rows.Add(212, "DEVESH", "KANPUR");
            //绑定DataGridView
            dataGridView1.DataSource = table;
            //创建HTML文件
            string HtmlBody = ExportDatatableToHtml(table);
            System.IO.File.WriteAllText(@"E:\hhh.HTML", HtmlBody);
        }
        protected string ExportDatatableToHtml(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html >");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; font-size:smaller'>");

            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");
            foreach (DataRow myRow in dt.Rows)
            {
                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }
            //Close tags. 
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");
            string Htmltext = strHTMLBuilder.ToString();

            return Htmltext;
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
