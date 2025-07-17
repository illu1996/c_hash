namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------데이터 정수 타입----------");
            sbyte a = -10;
            sbyte max_a = sbyte.MaxValue;
            sbyte min_a = sbyte.MinValue;

            byte b = 40;
            byte max_b = byte.MaxValue;
            byte min_b = byte.MinValue;

            Console.WriteLine($"sbyte Max = {max_a},Min = {min_a}, val = {a}");
            Console.WriteLine($"byte Max = {max_b},Min = {min_b}, val = {b}");

            short c = -30000;
            short max_c = short.MaxValue;
            short min_c = short.MinValue;
            ushort d = 60000;
            ushort max_d = ushort.MaxValue;
            ushort min_d = ushort.MinValue;

            Console.WriteLine($"short Max = {max_c},Min = {min_c}, val = {c}");
            Console.WriteLine($"ushort Max = {max_d},Min = {min_d}, val = {d}");

            int e = -10_000_000;
            int max_e = int.MaxValue;
            int min_e = int.MinValue;
            uint f = 1_000_000_000;
            uint max_f = uint.MaxValue;
            uint min_f = uint.MinValue;

            Console.WriteLine($"int Max = {max_e},Min = {min_e}, val = {e}");
            Console.WriteLine($"uint Max = {max_f},Min = {min_f}, val = {f}");


            long g = -500_000_000_000;
            long max_g = long.MaxValue;
            long min_g = long.MinValue;
            ulong h = 200_000_000_000_000;
            ulong max_h = ulong.MaxValue;
            ulong min_h = ulong.MinValue;

            Console.WriteLine($"int Max = {max_g},Min = {min_g}, val = {g}");
            Console.WriteLine($"uint Max = {max_h},Min = {min_h}, val = {h}");

            char i = 'a';

            Console.WriteLine($"char = {i}");
            
            nint j = nint.MaxValue;
            nuint k = nuint.MaxValue;
            nint l = nint.MinValue;
            nuint m = nuint.MinValue;

            Console.WriteLine($"nint Max = {j}, MIn = {j} // nuint Max= {k}, Min = {m}");
            Console.WriteLine("----------구분선----------");

            Console.WriteLine("----------2진수와 10진수----------");

            byte o = 240; //10진수 리터럴
            byte o1 = 0b1111_0000; //2진수 리터럴
            byte o2 = 0xF0; //16진수 리터럴
            uint o3 = 0x1234_abcd; //16진수 리터럴
            Console.WriteLine($"10진수 : {o}");
            Console.WriteLine($"2진수 : {o1}");
            Console.WriteLine($"16진수 : {o2}");
            Console.WriteLine($"16진수 : {o3}");
            Console.WriteLine("----------구분선----------");

            Console.WriteLine("----------float와 double----------");
            float f1 = 3.1415_9265_3589_7932_3846f;
            float f_max = float.MaxValue;
            float f_min = float.MinValue;
            Console.WriteLine($"float max = {f_max}, min = {f_min}, val = {f1}");

            double db1 = 3.1415_9265_3589_7932_3846;
            double db_max = double.MaxValue;
            double db_min = double.MinValue;
            Console.WriteLine($"double max = {db_max}, min = {db_min}, val = {db1}");

            decimal dm1 = 3.1415_9265_3589_7932_3846m;
            Console.WriteLine($"float : {f1}\ndouble : {db1}\ndemical : {dm1}");
            Console.WriteLine("----------구분선----------");

            Console.WriteLine("----------char & string----------");

            char c1 = 'a';
            string s1 = "ab";
            Console.WriteLine($"char = {c1} ,string = {s1}");
            Console.WriteLine("----------구분선----------");

            Console.WriteLine("----------boolean----------");
            bool suc = true;
            bool fail = false;
            Console.WriteLine($"{suc}");
            Console.WriteLine($"{fail}");
            Console.WriteLine("----------구분선----------");

            Console.WriteLine("----------Object----------");
            Object ob1 = 1;
            Object ob2 = "object2";
            Object ob3 = true;
            Object ob4 = 3.12316124634673325264367m;
            Console.WriteLine(ob1);
            Console.WriteLine(ob2);
            Console.WriteLine(ob3);
            Console.WriteLine(ob4);
            Console.WriteLine("----------구분선----------");


        }
    }
}
