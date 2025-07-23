using System;
using System.Net.Quic;

namespace _06_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = Calc.Plus(4, 3);
            Console.WriteLine(k); //7
                                  //메서드 없이 구현
            int a = 3; int b = 4;
            int x = a + b;
            Console.WriteLine(x); // 7

            int c;
            int d;
            Calc.Devide(a, b, out c, out d);
        }
    }
    
    class SOME
    {
        int SomeValue = 10;
        public ref int SomeTHTHING()
        {
            return ref SomeValue;
        }
        public int Plus(int a, int b)
        {
            return a + b;
        }
        //오버로딩
        public double Plus(double a, double b)
        {
            return a + b;
        }
    }
    class Calc
    {   
        
        public static int Plus(int x, int y)
            {
                return x + y;
            }
        public static bool JJ(int k)
        {
            if (k == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Devide(int a, int b, out int qt, out int rd)
        {
            qt = a / b;
            rd = a % b;
        }
    }
}