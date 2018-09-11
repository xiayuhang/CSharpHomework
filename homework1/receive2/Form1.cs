using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace receive2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a, b,c;
            int x, y,z;
            Console.Write("Please input a:");
            a = textBox1.Text;
            x = Convert.ToInt32(a);
            Console.Write("Please input b:");
            b = textBox2.Text;
            y = Convert.ToInt32(b);
            z = x * y;
            c = z.ToString();
            textBox3.Text = c;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
