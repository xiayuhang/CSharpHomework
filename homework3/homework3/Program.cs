using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Program
    { 
        static void Main(string[] args)
        {
            triangle triangle = new triangle();
            int s1=triangle.TriangleArea(2,3);
            Console.WriteLine("the triangle's area is "+s1);

            rectangle rectangle = new rectangle();
            int s2=rectangle.RectangleArea(3, 4);
            Console.WriteLine("the rectangle's area is " + s2);

            square square = new square();
            int s3=square.SquareArea(1);
            Console.WriteLine("the square's area is " + s3);

            circle circle = new circle();
            double s4=circle.CircleArea(1);
            Console.WriteLine("the circle's area is " + s4);
        }
    }

    public class  triangle
    {
        public int TriangleArea(int a,int h)
        {
            int s1;
            s1 = a*h/2;
            return s1;
        }
    }

    public class rectangle
    {
        public int RectangleArea(int m,int  n)
        {
            int s2;
            s2 = m * n;
            return s2;
        }
    }

    public class square
    {
        public int SquareArea(int i)
        {
            int s3;
            s3 = i * i;
            return s3;
        }
    }

    public class circle
    {
        const double PI = 3.1415936;
        public double CircleArea(int r)
        {
            double s4;
            s4 = PI*r * r;
            return s4;
        }
    }
}
