using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace receive1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a, b;
            int x, y, z;
            Console.Write("Please input a:");
            a = Console.ReadLine();
            x = Convert.ToInt32(a);
            Console.Write("Please input b:");
            b = Console.ReadLine();
            y = Convert.ToInt32(b);
            z = x * y;
            Console.Write("z ="+z);
        }
    }
}
