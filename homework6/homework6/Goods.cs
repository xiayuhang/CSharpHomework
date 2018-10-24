using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    //货物的信息
    public class Goods
    {
        private double price;

        //构造函数
        public Goods(uint id, string name, double value)
        {
            Id = id;
            Name = name;
            Price = value;
        }

        public Goods() { }

        //货物标识符
        public uint Id { get; set; }

        //货物名字
        public string Name { get; set; }

        //货物价格
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }

        //重写字符串，返回货物的数据
        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Value:{Price}";
        }
    }
}
