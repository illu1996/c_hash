# C# 250717 Chapter03

`데이터의 종류` / `변수` / `값-참조 형식` / `기본데이터형식` / `상수 및 열거`/ `Nullable` / `var`

### `변수 선언`

변수를 지정하면 컴퓨터는 일정 메모리에 데이터를 담는 공간을 지정한다.
이는 컴파일러에게 "이 변수에 필요한 공간을 예약해줘" 라고 하는 것과 같다.

```csharp
int x; //데이터 형식과 사용할 변수를 지정했으며,
x = 30; //값을 할당(초기화) 한다.
int x = 30; //한번에 처리해도 된다.
int a,b,c;
int x=30,b=50,c=70; //데이터 형식이 동일하다면 comma로 구분한다.
```

### `값-참조 형식`

값은 Value를 담고 있으며, 참조는 Reference를 담고 있다.
즉, 값은 그대로의 데이터를 가지고 있는 것이며, 참조는 값을 가진 위치를 담은 것이다.

이를 이해하려면 `stack`과 `heap` 두가지 메모리 영역에 대해 알아야한다.
`stack 메모리`는 값 형식을 가지며,

```csharp
static void stack()
{
    int a = 1;
    int b = 2;
}
```

stack()이라는 함수가 실행되면서 a,b에 대해 값이 메모리에 선언 및 초기화 되는데, 이 함수가 종료되면 할당된 값은 사라진다.

`heap 메모리`은 참조 형식을 가진다.

```csharp
{
    Object a = 10;
    Object b = 20;
}
```

이 참조형식은 `heap`에 저장되어, 가비지 컬렉션 GC에 따라 청소부가 일정 시간이 되어 청소하듯이 제거된다.

### `기본데이터형식`

C#이 제공하는 기본데이터 형식은 모두 15가지가 있다.
`값 형식`: 숫자, 논리
`참조 형식`: 문자열, 오브젝트

##### `숫자데이터 형식`

`정수`
|데이터 형식|설명|크기(바이트)|값 범위|
|---|---|---|---|
|byte|부호없는 정수|1(8비트)|0 ~ 255|
|sbyte|signed byte<br>부호있는 정수|1(8비트)|-128 ~ 127|
|short|정수|2(16비트)|-32,768 ~ 32,767|
|ushort|unsigned short<br>부호없는 정수|2(16비트)|0 ~ 65,535|
|int|정수|4(32비트)|-2,147,483,648 ~ 2,147,483,647|
|uint|unsigned int<br>부호없는 정수|4(32비트)|0 ~ 2,147,483,647|
|long|정수|8(64비트)|약 -9 _ 10 \*\* 17 ~ 9 _ 10 ** 17|
|ulong|unsigned long<br>부호없는 정수|8(64비트)|0 ~ 1 \* 10 ** 18|
|char|유니코드 문자| 2(16비트)|==|
|nint C#11.0|정수|4(32비트) or 8(64비트)|==|
|nuint C#11.0|unsigned int<br>부호없는 정수|4(32비트) or 8(64비트)|==|

```csharp
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte a = -10; // sbyte
            sbyte max_a = sbyte.MaxValue;
            sbyte min_a = sbyte.MinValue;

            byte b = 40; //byte
            byte max_b = byte.MaxValue;
            byte min_b = byte.MinValue;

            Console.WriteLine($"sbyte Max = {max_a},Min = {min_a}, val = {a}");
            Console.WriteLine($"byte Max = {max_b},Min = {min_b}, val = {b}");

            short c = -30000; //short
            short max_c = short.MaxValue;
            short min_c = short.MinValue;
            ushort d = 60000; //ushort
            ushort max_d = ushort.MaxValue;
            ushort min_d = ushort.MinValue;

            Console.WriteLine($"short Max = {max_c},Min = {min_c}, val = {c}");
            Console.WriteLine($"ushort Max = {max_d},Min = {min_d}, val = {d}");

            int e = -10_000_000; //int
            int max_e = int.MaxValue;
            int min_e = int.MinValue;
            uint f = 1_000_000_000; //uint
            uint max_f = uint.MaxValue;
            uint min_f = uint.MinValue;

            Console.WriteLine($"int Max = {max_e},Min = {min_e}, val = {e}");
            Console.WriteLine($"uint Max = {max_f},Min = {min_f}, val = {f}");

            long g = -500_000_000_000; //long
            long max_g = long.MaxValue;
            long min_g = long.MinValue;
            ulong h = 200_000_000_000_000; //ulong
            ulong max_h = ulong.MaxValue;
            ulong min_h = ulong.MinValue;

            Console.WriteLine($"int Max = {max_g},Min = {min_g}, val = {g}");
            Console.WriteLine($"uint Max = {max_h},Min = {min_h}, val = {h}");

            char i = 'a'; //char

            Console.WriteLine($"char = {i}");

            nint j = nint.MaxValue; //nint
            nint l = nint.MinValue;

            nuint k = nuint.MaxValue; //nuint
            nuint m = nuint.MinValue;

            Console.WriteLine($"nint Max = {j}, MIn = {j} // nuint Max= {k}, Min = {m}");
        }
    }
}

```

2진수와 16진수
`2진수` : 0b
`16진수` : 0x

```csharp
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte o = 240; //10진수 리터럴
            byte o1 = 0b1111_0000; //2진수 리터럴
            byte o2 = 0xF0; //16진수 리터럴
            uint o3 = 0x1234_abcd; //16진수 리터럴
            Console.WriteLine($"10진수 : {o}"); //240
            Console.WriteLine($"2진수 : {o1}"); //240
            Console.WriteLine($"16진수 : {o2}"); //240
            Console.WriteLine($"16진수 : {o3}"); //305441741
        }
    }
}
```

`소수`:
`부동소수점`이란 움직이지 않는 것이 아니라 뜰 부를 사용하여 떠서 움직인다는 뜻이다.
이는 소수점이 이동하면서 수를 표현하여 부동소수라고 붙었다.
표현하는 방식은 `float` 과 `double`이 존재한다.
`demical`은 부동 소수는 아니지만 실수에서 소수를 다룹니다.

| 데이터 형식 | 설명                                                          | 크기(바이트) | 범위                         |
| ----------- | ------------------------------------------------------------- | ------------ | ---------------------------- |
| float       | 단일정밀도 부동 소수점형식<br>7개의 자릿수만 다룰 수 있음     | 4(32비트)    | -3.402823e38 ~ 3.402823e38   |
| double      | 복수정밀도 부동 소수점형식<br>15~16개의 자릿수만 다룰 수 있음 | 8(64비트)    | -1.7976931xxxxx~1.7976xxxxxx |
| demical     | 29자리 데이터를 표현할 수 있는 소수 형식                      | 16(128비트)  | +- 29자리 소수점 아래        |

여기서 정밀도란 부동 소수점 형식의 특징이자 한계를 나타내는 말이다. `IEEE754` 표준 알고리즘에 기반한 데이터 형식이다.

```csharp
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float f1 = 3.1415_9265_3589_7932_3846f;
            float f_max = float.MaxValue;
            float f_min = float.MinValue;
            Console.WriteLine($"float max = {f_max}, min = {f_min}, val = {f1}");
            //float max = 3.4028235E+38, min = -3.4028235E+38, val = 3.1415927
            double db1 = 3.1415_9265_3589_7932_3846;
            double db_max = double.MaxValue;
            double db_min = double.MinValue;
            Console.WriteLine($"double max = {db_max}, min = {db_min}, val = {db1}");
            //double max = 1.7976931348623157E+308, min = -1.7976931348623157E+308, val = 3.141592653589793

            decimal dm1 = 3.1415_9265_3589_7932_3846m;
            Console.WriteLine($"float : {f1}\ndouble : {db1}\ndemical : {dm1}");
            //float : 3.1415927
            // double : 3.141592653589793
            // demical : 3.14159265358979323846
        }
    }
}
```

이처럼 메모리는 분명 많이 차이나지만 정밀성에 대해서는 `float` < `double` < `demical`을 따른다.

#### `문자열`

`char`: 개별 문자을 표현 ' '를 사용<br>
`string` : 문자열을 표현 " "를 사용

```csharp
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char c1 = 'a';
            string s1 = "ab";
            Console.WriteLine($"char = {c1} ,string = {s1}");
            //char = a ,string = ab
        }
    }
}
```

#### `논리형식 Boolean`

```csharp
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool suc = true;
            bool fail = false;
            Console.WriteLine($"{suc}");
            Console.WriteLine($"{fail}");
            //True
            //False
        }
    }
}
```

C# 에서 논리형식은 소문자로 `true/false` 이지만 문자열로 변경될때, `True/False` 로 나온다.

#### `Object 형식`

```csharp
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Object ob1 = 1;
            Object ob2 = "object2";
            Object ob3 = true;
            Object ob4 = 3.12316124634673325264367m;
            Console.WriteLine(ob1);
            Console.WriteLine(ob2);
            Console.WriteLine(ob3);
            Console.WriteLine(ob4);
            //1
            // object2
            // True
            // 3.12316124634673325264367
        }
    }
}
```

object 형식은 모든 데이터를 다룰 수 있다. object는 모든 데이터 형식의 조상이라고 생각하면 좋다.

## \*\*박싱과 언박싱

여기서 중요한 것은 `Object` 형식은 참조 형식이기에 `heap메모리`에 데이터를 할당한다.
값 형식은 `stack메모리`에 할당 되지만 `Object`가 되기 위하여 `박싱`과`언박싱`을 이용한다.
`박싱` : `heap메모리`로 가기위해 박스처럼 감싸주는 역할
`언박싱` : `heap메모리`에서 `stack메모리`로 가기위해 박스를 헤체하는 역할

```csharp
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int int_a = 20;
            Object obj = (object) int_a; //int_a 값을 박싱해서 힙에 저장
            int int_c = (int) obj; //obj에 담긴 값을 언박싱
        }
    }
}
```

#### `데이터 형식 변환`

변수를 다른 데이터 형식으로 변환하는데, 형변환이라고도 한다.
형변환 시 저장될 수 없어 손실되는 데이터들이 있으므로 (int) 등의 형변환을 사용할 때, 조심해야한다.

다만, 문자열과 숫자형의 변환같은 경우 컴파일 조차 안되기에, `Parse`와 `Convert`를 이용하여야 한다.

```csharp
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int int_12345 = 12345;
            float f_1234 = 0.234f;
            string string_12345 = int_12345.ToString();
            string string_1234 = f_1234.ToString();
            int convert_int = int.Parse(string_12345);
            float convert_float = float.Parse(string_1234);
            Console.WriteLine($"{int_12345},{string_12345},{f_1234},{string_1234},{convert_int},{convert_float}");
        }
    }
}
```

#### `상수 및 열거형식`

`상수`와`열거형식`은 변수처럼 동작하지만 안에 담긴 데이터를 절대 바꿀 수 없는 메모리 공간이다.

```csharp
//상수
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int const1 = 1;
            const double const2 = 3.14;
            const string const3 = "abcdef";
            Console.WriteLine($"{const1},{const2},{const3}");
            const int const1 = 4; // 에러로 컴파일 불가 표시
            Console.WriteLine(const1);

            const int MAX_INT = int.MaxValue; //미리 선언해놓고 계속 사용
            const int MIN_INT = int.MinValue;
        }
    }
}
```

예시를 보자.
`상수`는 내가 알고리즘 문제를 푸는데, int 의 max값을 자주 사용한다면 미리 선언해놓고 계속 불러다가 쓸 수 있다. 프로그래머의 실수를 방지하기 위해 사용합니다.
하지만 이 상수에서도 엄청 많이 사용되어 헷갈리기 시작한다면 `열거 형식`은 `상수`를 이용할 수 있다.
예를 들면 내가 http 상태 결과를 5개 받아야하는데, 변수명이 비슷해서 문제가 생길 수 있는 것을 방지하는 것이 좋다.

```csharp
//열거
namespace DataType_03
{
    internal class Program
    {
        //열거 선언
        enum DialogResult { YES, NO, CANCEL, CONFIRM, WAIT };
        enum DialogResult1 { YES=20, NO, CANCEL, CONFIRM=40, WAIT }; //이렇게도 가능하다.
        //미선언 시 앞의 값의 + 1
        static void Main(string[] args)
        {
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
        }
    }
}
```

### `Nullable 형식`

int 형식 변수 선언시 4바티으 메모리 할당하는데, C# 컴파일러는 어떻게든 값이 없으면 실행 파일을 주지않는다.
이에 비어 있다는 뜻인 `null`을 넣어둔다.

```csharp
int? a = null;
float? b = null;
double? c = null;

Console.WriteLine(a.HasValue); // False
a= 3;

int d; //이는 null이 아니라 0으로 C#이 초기화 시켜버린다.
```

### `var`

```csharp
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
```

### `문자열!!!`

문자열 메서드

| 찾는 메서드   | 설명                                                                       |
| ------------- | -------------------------------------------------------------------------- |
| IndexOf()     | 현재 문자열 내에서 찾고자 하는 지정된 문자 또는 문자열 위치 찾음.          |
| LastIndexOf() | 현재 문자열 내에서 찾고자 하는 지정된 문자 또는 문자열 위치를 뒤부터 찾음. |
| StartsWith()  | 현재 문자열이 지정된 문자열로 시작하는 확인.                               |
| EndsWith()    | 현재 문자열이 지정된 문자열로 끝나는지 확인.                               |
| Contains()    | 현재 문자열이 지정된 문자열을 포함하는지 확인.                             |
| Replace()     | 현재 문자열에서 지정된 문자열이 다른 지정된 문자열로 바뀐 후 반환.         |

| 가공 메서드 | 설명                                                |
| ----------- | --------------------------------------------------- |
| ToLower()   | 현재 문자열의 모든 대문자를 소문자로 변경 후 반환.  |
| ToUpper()   | 현재 문자열의 모든 소문자를 대문자로 변경 후 반환.  |
| Insert()    | 현재 문자열의 지정된 위치에서 문자열 삽입.          |
| Remove()    | 현재 문자열의 지정된 위치로부터 지정된 수만큼 삭제. |
| Trim()      | 현재 문자열의 앞뒤 공백 제거.                       |
| TrimStart() | 현재 문자열의 앞 공백 제거.                         |
| TrimEnd()   | 현재 문자열의 뒤 공백 제거.                         |
| Split()     | 지정된 문자를 기준으로 분리함.                      |
| SubString() | 지정된 위치의 시작부터 끝까지 잘라서 반환.          |

### `문자열 Formatter`

```csharp
namespace DataType_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
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


```
