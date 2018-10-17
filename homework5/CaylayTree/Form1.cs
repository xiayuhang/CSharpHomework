using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaylayTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th1 = angleBar1.Value * Math.PI / 180;
            th2 = angleBar2.Value * Math.PI / 180;
            per1 = (double)lengthBar1.Value / 100;
            per2 = (double)lengthBar2.Value / 100;
            k = (double)locationBar.Value / 1000;

            if (graphics == null)
                graphics = this.CreateGraphics();
            else
                graphics.Clear(Color.White);
            drawCayleyTree(10, 350, 500, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        double k = 0.618;   //两子树位置的系数

        private void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            //默认第二棵子树的生长点在黄金分割点处
            double x2 = x0 + leng * k * Math.Cos(th);
            double y2 = y0 + leng * k * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }

        private void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                Pens.Blue,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            k = (double)locationBar.Value/1000;
            locationLabel.Text = k.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void angleBar1_Scroll(object sender, EventArgs e)
        {
            th1 = angleBar1.Value * Math.PI / 180;
            angleLabel1.Text = angleBar1.Value.ToString();
        }

        private void angleBar2_Scroll(object sender, EventArgs e)
        {
            th2 = angleBar2.Value * Math.PI / 180;
            angleLabel2.Text = angleBar2.Value.ToString();
        }

        private void lengthBar1_Scroll(object sender, EventArgs e)
        {
            per1 = (double)lengthBar1.Value / 100;
            lengthLabel1.Text = per1.ToString();
        }

        private void lengthBar2_Scroll(object sender, EventArgs e)
        {
            per2 = (double)lengthBar2.Value / 100;
            lengthLabel2.Text = per2.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int i = r.Next(20, 70);
            th1 = i * Math.PI / 180;
            i = r.Next(20, 70);
            th2 = i * Math.PI / 180;
            i = r.Next(50, 90);
            per1 = (double)i / 100;
            i = r.Next(50, 90);
            per2 = (double)i / 100;
            i = r.Next(0, 1000);
            k = (double)i / 1000;
            if (graphics == null)
                graphics = this.CreateGraphics();
            else
                graphics.Clear(Color.White);
            drawCayleyTree(10, 350, 500, 100, -Math.PI / 2);
        }
    }
}
