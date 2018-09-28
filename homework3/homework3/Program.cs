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
            Console.WriteLine("please input the form:");
            string form =Console.ReadLine();

            if (form== "triangle")
            {
                triangle triangle = new triangle();
                Console.WriteLine("please input the length ");
                int length = Console.Read();
                Console.WriteLine("please input the width ");
                int width = Console.Read();
                int s1 = triangle.TriangleArea(length, width);
                Console.WriteLine("the triangle's area is " + s1);
            }

            if (form== "rectangle")
            {
                rectangle rectangle = new rectangle();
                Console.WriteLine("please input the bottomlength ");
                int bottomlength = Console.Read();
                Console.WriteLine("please input the height ");
                int height = Console.Read();
                int s2 = rectangle.RectangleArea(bottomlength, height);
                Console.WriteLine("the rectangle's area is " + s2);
            }

            if (form == "square")
            {
                square square = new square();
                Console.WriteLine("please input the sidelength ");
                int sidelength = Console.Read();
                int s3 = square.SquareArea(sidelength);
                Console.WriteLine("the square's area is " + s3);
            }

            if (form == "circle")
            {
                circle circle = new circle();
                Console.WriteLine("please input the radius ");
                int radius = Console.Read();
                double s4 = circle.CircleArea(radius);
                Console.WriteLine("the circle's area is " + s4);
            }
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
        const double PI = 3.1415926;
        public double CircleArea(int r)
        {
            double s4;
            s4 = PI*r * r;
            return s4;
        }
    }
}
