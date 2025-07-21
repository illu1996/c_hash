namespace DataType_03
{
    internal class Program
    {
        enum DialogResult { YES, NO, CANCEL, CONFIRM, WAIT };
        enum DialogResult1 { YES = 20, NO, CANCEL, CONFIRM = 40, WAIT };


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

            Console.WriteLine("----------Boxing & UnBoxing----------");
            int int_a = 123;
            Object obj = (Object)int_a; //int_a 값을 박싱해서 힙에 저장
            int int_c = (int)obj; //obj에 담긴 값을 언박싱
            Console.WriteLine("---------구분선----------");

            Console.WriteLine("----------형변환----------");
            int int_12345 = 12345;
            float f_1234 = 0.234f;
            string string_12345 = int_12345.ToString();
            string string_1234 = f_1234.ToString();
            int convert_int = int.Parse(string_12345);
            float convert_float = float.Parse(string_1234);
            Console.WriteLine($"{int_12345},{string_12345},{f_1234},{string_1234},{convert_int},{convert_float}");
            Console.WriteLine("----------구분선----------");

            Console.WriteLine("----------상수와 열거형식----------");
            const int const1 = 1;
            const double const2 = 3.14;
            const string const3 = "abcdef";
            Console.WriteLine($"{const1},{const2},{const3}");
            //const int const1 = 4; // 에러표시
            //Console.WriteLine(const1);
            const int MAX_INT = int.MaxValue;
            const int MIN_INT = int.MinValue;

            //상수를 이용한 열거처럼 사용
            const int RESULT_OK = 1;
            const int RESULT_NO = 2;
            const int RESULT_CONFIRM = 3;
            const int RESULT_CANCLE = 4;
            const int RESULT_WAIT = 5;

            //열거 
            Console.WriteLine((int)DialogResult.YES);
            Console.WriteLine(DialogResult.NO);
            Console.WriteLine((int)DialogResult.CANCEL);
            Console.WriteLine(DialogResult.CONFIRM);
            Console.WriteLine(DialogResult.WAIT);

            Console.WriteLine("----------구분선----------");
            Console.WriteLine("----------Nullable----------");
            int? null_a = null;
            float? null_b = null;
            double? null_c = null;

            Console.WriteLine(null_a.HasValue); // False
            null_a = 3;
            Console.WriteLine(null_a.HasValue); // True
            Console.WriteLine(null_a.Value); // 3

            int null_d; //이는 nullable 형식도 아닐뿐더러 0으로 C#이 초기화 시켜버린다.

            Console.WriteLine("----------구분선----------");
            Console.WriteLine("---------- var ----------");
            var var_a = 20;//var는 반드시 선언과 동시에 초기화
            var var_b = 3.1414213;
            var var_c = "Hello,World";
            var var_d = new int[] { 10, 20, 30 };

            Console.WriteLine("Type:{0}, Value{1}", var_a.GetType(), var_a); //Type: System.Int32, Value20
            Console.WriteLine("Type:{0}, Value{1}", var_b.GetType(), var_b); //Type:System.Double, Value3.1414213
            Console.WriteLine("Type:{0}, Value{1}", var_c.GetType(), var_c);// Type: System.String, ValueHello,World
            foreach ( var var_e in var_d)
            {
                Console.WriteLine("Type:{0}, Value{1}", var_e.GetType(), var_e);

            }

            Console.WriteLine("----------구분선----------");
            Console.WriteLine("---------- 문자열 포매터----------");
            Console.WriteLine("Total : {0,-7:D}DEF", "ABC"); //{첨자, 맞춤, 서식문자열}
            //Total : ABC       DEF DEF의 칸 지정

            string fmt = "{0,-20}{1,-15}{2,30}";
            Console.WriteLine(fmt, "Publisher", "Author","Title");
            Console.WriteLine(fmt, "Marvle", "Stan Lee","Iron Man");
            Console.WriteLine(fmt, "Hanbit", "Sanghyun Park","This is C#");
            //Publisher           Author                                  Title
            //Marvle              Stan Lee                             Iron Man
            //Hanbit              Sanghyun Park                      This is C#
        }
    }
}
