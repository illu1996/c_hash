using System.Net.Sockets;

namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine($"i = {i}");
            
            nint j = nint.MaxValue;
            nuint k = nuint.MaxValue;
            nint l = nint.MinValue;
            nuint m = nuint.MinValue;

            Console.WriteLine($"nint Max = {j}, MIn = {j} // nuint Max= {k}, Min = {m}");
        }
    }
}
