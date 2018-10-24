using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class Customer
    {

        //顾客的标识符
        public uint Id { get; set; }

        //顾客的名字
        public string Name { get; set; }
        
        //构造函数
        public Customer(uint id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Customer() {

        }

        //重写字符串，返回顾客的数据
        public override string ToString()
        {
            return $"customerId:{Id}, CustomerName:{Name}";
        }
    }
}
