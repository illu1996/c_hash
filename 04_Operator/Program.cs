using System.Collections;

namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //산술 연산자
            int a = 111 + 222;
            Console.WriteLine(a);

            int b = a - 100;
            Console.WriteLine(b);

            int c = b * 10;
            Console.WriteLine(c);

            double d = c / 6.3;
            Console.WriteLine(d);

            Console.WriteLine($"22 / 7 = { 22/7}{22%7}");

            //증감 연산자
            int k = 10;
            Console.WriteLine(k); // 10

            k++;
            Console.WriteLine(k); // 11

            k--;
            k--;
            Console.WriteLine(k); // 9

            int l = 10;
            Console.WriteLine(l++); // 10 출력 후 + 1
            Console.WriteLine(++l); // 11인데, +1 한 후 12출력

            //문자열 연산자
            string result = "123" + "456";
            Console.WriteLine(result); // 123456

            //관계 연산자
            bool bool_result;
            bool_result = 3 > 4; //거짓
            bool_result = 3 >= 4; //거짓
            bool_result = 3 < 4; //참
            bool_result = 3 <= 4; //참
            bool_result = 3 == 4; //거짓
            bool_result = 3 != 4; //참

            //논리 연산자
            int int_a = 3;
            int int_b = 4;

            bool bool_c = a < b && b < 5; // 참 참 and연산자이니 true
            bool bool_d = a > b && b < 5; // 거짓 참 and연산자이니 false
            bool bool_e = a > b || b < 5; // 거짓 참 or 연산자이니 true
            bool bool_f = !bool_e; // bool_e 가 참이므로 false

            //조건 연산자
            int int_g = 30;
            string result_string = a == 30 ? "삼심" : "삼십아님";
            // 삼십 출력

            //null 조건부 연산
            ArrayList lst_k = null;
            lst_k?.Add("야구"); //lst_k 가 null을 반환하여 Add 가 실행되지 않는다.

            lst_k = new ArrayList();
            lst_k?.Add("야구");
            lst_k?.Add("축구");
            Console.WriteLine(lst_k.Count); //2


            // 시프트 연산자

            int bit_a = 1;
            Console.WriteLine(bit_a);
            Console.WriteLine(bit_a << 1);
            Console.WriteLine(bit_a << 2);
            Console.WriteLine(bit_a << 5);

            int bit_b = 255;
            Console.WriteLine(bit_b >> 1);
            Console.WriteLine(bit_b >> 2);
        }
    }
}
