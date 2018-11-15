using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace homework7
{
    public partial class Form1 : Form
    {
        public List<Order> orders = new List<Order>();
        public string KeyWord { get; set; }

        public Form1()
        {
            InitializeComponent();

            queryInput.DataBindings.Add("Text", this, "KeyWord"); //文本框与KeyWord数据绑定
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //文本框内容为空，显示全部订单
            if (queryInput.Text == "")
            {
                bsOrder.DataSource = orders;
            }
            //文本框内容不为空，显示满足条件的订单，用数据绑定
            else
            {
                if (comboBoxForSearch.SelectedItem.ToString() == "客户名")
                {
                    bsOrder.DataSource = orders.Where(order => order.Client == KeyWord);
                }
                if (comboBoxForSearch.SelectedItem.ToString() == "订单号")
                {
                    bsOrder.DataSource = orders.Where(order => order.OrderNumber == KeyWord);
                }
                if (comboBoxForSearch.SelectedItem.ToString() == "商品名")
                {
                    bsOrder.DataSource = orders
                               .Where(order =>
                               {
                                   foreach (OrderDetails detail in order.detailsList)
                                   {
                                       if (detail.Item == KeyWord)
                                           return true;
                                   }
                                   return false;
                               });
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "添加订单";
            form.ShowDialog();
            //添加数据到bsOrder，从而在datagridview中显示
            bsOrder.Add(form.order);
            orders.Add(form.order);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order curOrder = (Order)bsOrder.Current;
            Form2 form = new Form2(curOrder);
            form.Text = "修改订单";
            form.ShowDialog();

            bsOrder.Add(form.order);
            bsOrder.Remove(curOrder);
            orders.Add(form.order);
            orders.Remove(curOrder);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //DeleteItem属性并将其设置(无)，重写点击事件，以便删除List中的元素
            Order cur = (Order)bsOrder.Current;
            if (cur != null)
            {
                bsOrder.Remove(cur);
                orders.Remove(cur);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxForSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            System.Environment.Exit(0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = @"..\..\MyOrderList.xml";
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xml.Serialize(fs, orders);
            }
            
            XmlDocument xDocument = new XmlDocument();
            xDocument.Load(@"..\..\MyOrderList.xml");

            XPathNavigator xNavigator = xDocument.CreateNavigator();
            xNavigator.MoveToRoot();

            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(@"..\..\MyOrderList.xslt");

            FileStream html = File.OpenWrite(@"..\..\MyOrderList.html");
            XmlTextWriter writer = new XmlTextWriter(html, System.Text.Encoding.UTF8);

            xsl.Transform(xNavigator, null, writer);
            writer.Close();

            MessageBox.Show("导出成功！");
        }
    }
}
