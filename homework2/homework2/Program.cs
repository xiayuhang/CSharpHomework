using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeFactor();
            Array();
            Seive();
        }

        static void PrimeFactor()
        {
            Console.WriteLine("please input a number:");
            int num;
            num = int.Parse(Console.ReadLine());

            bool a=true;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    for(int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            a = false;
                            break;
                        }
                    }
                    if (a == true)
                    {
                        Console.Write(i + "\t");
                    }
                }
            }
            Console.Write("\n");
        }

        static void Array()
        {
            int[] array = new int[10] { 1,2,3,4,5,6,7,8,9,10};
            int swap;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        swap = array[i];
                        array[i] = array[j];
                        array[j] = swap;
                    }
                }
            }
            Console.WriteLine("the mininum number is " + array[0]+"\n");
            Console.WriteLine("the maxinum number is " + array[9] + "\n");

            int all=0;
            for (int k=0;k< array.Length; k++)
            {
                all += array[k];
            }
            int average;
            average = all / array.Length;
            Console.WriteLine("the total value is " + all + "\n");
            Console.WriteLine("the average value is " + average + "\n");
        }

        private static void Seive()
        {
            int[] array = new int[99];
            for(int i = 2; i < array.Length + 2; i++)
            {
                array[i - 2] = i;
            }

            for(int j = 0; j < array.Length ; j++)
            {
                for(int k = 2; k < array.Length+2 ; k++)
                {
                    if (array[j] != 0)
                    {
                        if(array[j]%k==0 && array[j]/k!=1)
                        {
                            array[j] = 0;
                        }
                    }
                }
            }

            Console.WriteLine("the prime numbers from 2 to 100 are:");
            for(int l = 0; l < array.Length; l++)
            {
                if (array[l] != 0)
                {
                    Console.Write(array[l]+"\t");
                }
            }
        }
        
    }
}
