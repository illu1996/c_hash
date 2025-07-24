# C# 250717 Chapter05

## 코드 흐름 제어 Flow Control

```txt
if, else --> if 중첩 --> switch --> 반복문 --> while --> do while --> for --> 중첩 for
--> foreach -->  무한반복 --> 점프문 --> continue --> goto --> return & throw
```

## 1. 분기문

분기문은 여러갈래로 나누어지는 흐름제어

### if, else 문

```csharp
namespace _05_FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //분기문
            int a = 10;
            if (( a %10) == 0)
            {
                Console.WriteLine("짝수");
            }
            else
            {
                Console.WriteLine("홀수");
            }
        }
    } //짝수
}
```

### if 중첩문

```csharp
namespace _05_FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //if 중첩

            int b = 10;
            if ((a % 10) > 0)
            {
                if (a % 2 == 0)
                {
                    Console.WriteLine("0보다 큰 짝수");
                }
                else
                {
                    Console.WriteLine("0보다 큰 홀수");
                }
            }
            else
            {
                Console.WriteLine("0보다 작거나 같은 수");
            }
        }  // 0보다 큰 짝수
    }
}
```

### switch 문

switch 문은 조건식의 결과가 가질 수 있는 다양한 경우, 한번에 평가하고 프로그램의 흐름을 가릅니다.

> 다만 switch 문에 사용되는 조건식은 정수형식과 문자열만 지원합니다.

```csharp
namespace _05_FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //switch 문
            int number = 1;

            switch (number)
            {
                case 1:
                    Console.WriteLine("하나");
                    break;
                case 2:
                    Console.WriteLine("둘");
                    break;
                case 3:
                    Console.WriteLine("셋");
                    break;
                case 4:
                    Console.WriteLine("넷");
                    break;
                default:
                    Console.WriteLine("포함 안돼 !");
                    break;

            } // number 가 1이므로 "하나" 출력
        }
    }
}
```

<br>

> 데이터 형식에 따른다면 case 뒤에 데이터 형식을 무조건 지정해야한다.

```csharp
switch ()
    case int i:
        ...
        break;
    case float f:
        ...
        break;
```

<br>
> when 조건문을 넣을 수 있다.

```csharp
switch ()
    case int i:
        ...
        break;
    case float f when f > 0:
        ...
        break;
    case float f:
        ...
        break;
```

<br>

### switch 식

switch 문과 달리 더 쉽게 쓸 수 있다.

```csharp
namespace _05_FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //switch 식
            int score = 30;
            string grade = (int) (Math.Truncate(score / 10.0) * 10) switch
            {
                90 => "A입니다.",
                80 => "B입니다.",
                70 => "C입니다.",
                60 => "D입니다.",
                50 => "E입니다.",
                _ => "F입니다.",
            };
            Console.WriteLine($"{grade}"); //F입니다.
        }
    }
}
```

---

<br>

## 2. 반복문

흔히 (LOOP) 루프문이라고 하며 특정 조건을 만족하면 계속 실행되는 형태입니다.

### while

```csharp
namespace _05_FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // while
            int ten = 10;
            while (ten > 0)
            {
                Console.WriteLine(ten--);
            }
            // 10 -> 9 ->  ---  -> 1
        }
    }
}
```

### do while

do 의 한번 실행 후 조건에 따라 while문 진입

> 원래라면 while 을 통해 조건을 검사하고 코드를 실행하겠지만, do while은 최소 한번의 코드를 실행한다.

```csharp
namespace _05_FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //do while
            int dowhile = 10;
            do
            {
                Console.WriteLine(dowhile);
                dowhile--;
            }
            while ( dowhile >5 );
        }
    }
}
```

### for문, 2중 for문, foreach

```csharp
for (초기화식; 조건식; 반복식)
    {반복실행 코드}
```

```csharp
namespace _05_FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for
            for (int i =0; i < 5; i++)
            {
                Console.WriteLine(i); // 0 1 2 3 4
            }

            // 중첩
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine(j); // 0 1 2 3 4 0 1 2 3 4 0 1 2 3 4 --- 4
                }
            }

            //foreach
            int[] arr = new int[5] { 0, 1, 2, 3, 4 };

            foreach (int i in arr)
            {
                Console.WriteLine(i); // 0 1 2 3 4
            }
        }
    }
}
```

### 무한 반복문

특정 조건을 통해 무한 반복이 실행된다.

```csharp
for (;;)
{
    // 반복 실행 코드
}

while (true)
{
    //반복 실행 코드
}
```

---

<br>

## 3. 점프문

`break` ` continue` `goto` `return` `throw` 가 있다.

```csharp
namespace _05_FlowControl
{
    internal class Program
    {
            // 점프문

            int bk = 50;

            JUMP:
                Console.WriteLine("k");
            while (true)
            {
                if (bk > 105)
                {
                    break; // 105 이상이면 while 멈춤
                }
                else if (bk < 100)
                {
                    bk++;
                    goto JUMP; //1 더하고 Jump 로 이동
                }
                else if (bk == 100)
                {
                    bk++;
                    continue; //1 더하고 while 첫 부분 강제 이동
                }
            }
    }
}
```
