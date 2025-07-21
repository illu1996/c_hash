# C# 250717 Chapter04

## 데이터를 가공하는 연산자

산술 연산자

```csharp
namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 111 + 222;
            Console.WriteLine(a);

            int b = a - 100;
            Console.WriteLine(b);

            int c = b * 10;
            Console.WriteLine(c);

            double d = c / 6.3;
            Console.WriteLine(d);

            Console.WriteLine($"22 / 7 = { 22/7}{22%7}");
        }
    }
}
```

증감 연산자

```csharp
namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
```

문자열 결합 연산

```csharp
namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string result = "123" + "456";
            Console.WriteLine(result); // 123456
        }
    }
}
```

관계 연산자

```csharp
namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bool_result;
            bool_result = 3 > 4; //거짓
            bool_result = 3 >= 4; //거짓
            bool_result = 3 < 4; //참
            bool_result = 3 <= 4; //참
            bool_result = 3 == 4; //거짓
            bool_result = 3 != 4; //참
        }
    }
}
```

논리연산자
<br>논리연산자는 참과 거짓으로 연산을 한다.
<br>
|A|B|A&&B|A\|\|B|
|--|--|--|--|
|참|참|참|참|
|참|거짓|거짓|참|
|거짓|거짓|거짓|거짓|
|거짓|참|거짓|참|

```csharp
namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //논리 연산자
            int int_a = 3;
            int int_b = 4;

            bool bool_c = a < b && b < 5; // 참 참 and연산자이니 true
            bool bool_d = a > b && b < 5; // 거짓 참 and연산자이니 false
            bool bool_e = a > b || b < 5; // 거짓 참 or 연산자이니 true
            bool bool_f = !bool_e; // bool_e 가 참이므로 false
        }
    }
}
```

조건 연산자

> 조건식 ? A(참일때) : B(거짓일때)

if문와 else 문을 간단히 쓰기에 좋다

```csharp
namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int int_g = 30;
            string result_string = a == 30 ? "삼심" : "삼십아님";
            // 삼십 출력
        }
    }
}
```

null 조건부 연산자

> C# 6.0 부터 도입한 조건부 연산자는 null인지 검사하여, null이면 null반환하고 아니면 지정된 멤버 반환

> int? bar<br>bar = foo?.member

```csharp
namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //null 조건부 연산
            ArrayList lst_k = null;
            lst_k?.Add("야구"); //lst_k 가 null을 반환하여 Add 가 실행되지 않는다.

            lst_k = new ArrayList();
            lst_k?.Add("야구");
            lst_k?.Add("축구");
            Console.WriteLine(lst_k.Count); //2
        }
    }
}
```

비트 연산자
|연산자|이름|설명|지원 형식|
|-----|--|--|--|
|<<|왼쪽시프트 연산자| 처음 피연산자의 비트를 두번째 피연산자의 수만큼 왼쪽으로 이동| 첫번째 피연산자는 int, uint, long, ulong|
|>> |오른쪽시프트 연산자| 처음 피연산자의 비트를 두번째 피연산자의 수만큼 왼쪽으로 이동|위와 동일
|& |논리곱(AND)연산자| 두개의 피연산자의 비트 논리곱 | 정수계열 형식과 bool형식|
|\ ||논리합(OR)연산자| 두개의 피연산자의 비트 논리합 | 위와 동일|
|^ |배타 논리합(XOR) 연산자 | 두개의 피연산자의 비트 배타 논리합 | 위와 동일|
|~ |보수(NOT)연산자| 피연산자의 비트를 0은 1로, 1은 0으로 반전||

> 시프트 연산자는 왼쪽으로 2비트 가면 앞의 비트가 뒤로 와서 2진수의 제곱의 단위가 올라감.

```csharp
namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
```
