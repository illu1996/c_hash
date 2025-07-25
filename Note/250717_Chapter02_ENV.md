# C# 250717 Chapter02

##### C# 의 기본 파일과 환경설정

> 소스파일과 프로젝트

C --> .c 소스파일 ex hello.c
java --> .java 소스파일 es hello.java
C# --> .cs 소스파일 ex hello.cs

hello.cs(source code) --> 컴파일러 --> hello.exe(실행 파일)

`프로젝트`개념 도입
c# 프로젝트 파일은 확장자가 `.csproj`

`솔루션`개념 도입
프로젝트 여러개 관리 단위, 확장자는 `.sln`

hello project 콘솔 앱 생성

소스코드 입력

```csharp
namespace Hello
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("사용법 : Hello.exe <이름>");
                return;
            }
            Console.WriteLine("Hello, {0}", args[0]);

        }
    }
}
```

컴파일 빌드 --> `ctrl` + `shift` + `B`
컴파일 완성시 `bin/Debug` 디렉토리에 hello.exe 실행파일 생성

### using System;

using system; 은 크게

- using
- System
- ;

으로 이루어져 있다

`using` : c# 의 키워드 중 하나이다. 여기서 c# 키워드란 c#이 정해놓은 미리 정의되어 있는 특별한 단어 중 하나이다.<br>
`System`: c#이 기본적으로 필요로 하는 클래스<br>
`세미콜론`: 컴파일러에게 문장의 끝을 알리는 기호

`using`만 사용한다면 네임스페이스 전체를 사용<br>
`using static`을 사용하면 어떤 데이터(ex: 클래스)의 정적 멤버를 데이터 형식의 이름을 명시하지 않고 선언하는 기능

```csharp
using static System.Console;

    // Console.WriteLine();
    WriteLine();
    // Console.Read();
    Read();
```

위에 적어둔 주석부분 대신 생략하며 사용할 수 있다.

### `namespace`

`namespace` 는 성격이나 하는일이 비슷한 `클래스`,`구조체`,`인터페이스`, `열거형식`,`대리자` 등을 하나의 이름 아래 묶는다.
예를 들어 namespace:`System.IO`는 파일 입출력을 다루는 `클래스`,`구조체`등이 있는데, `.NET` 클래스 라이브러리에 1만개가 넘는 클래스가 있어도 프로그래머 들이 혼돈하지 않는다.

```csharp
namespace _namespace
{
  //class
  //structure
  //interface
}
```

`Hello`라는 `namespce`를 만들었고,
그 안에 `program`이라는 `class`를 가진다.

### `class`

`class`란 프로그램을 구성하는 기본 단위로서 `데이터`와 `데이터를 처리하는기능(메서드)`로 이루어져 있다.

### `static void Main(String[] args)`

이는 프로그램 진입점이라고 판단하는 `Main()`입니다.
반드시 Main()이 존재해야만 프로그램의 진입점을 판단합니다. 없다면 오류를 뱉습니다.
`static` : 한정자;
`void` : 반환형식;
`Main()` : 메서드 이름;
`args` : 매개변수

> `static`이 들어간다면 프로그램이 처음 구동될때 메모리에 할당되어 전역으로 사용한다. 그렇지 않다면
> 코드가 실행되는 시점에 메모리에 할당된다.

# CLR; Common Language Runtime

| C# / VB.NET / C++ / ... | 5th |
| ----------------------- | --- |
| .NET LIVERARY           | 4th |
| Common LANGUAGE RUNTIME | 3th |
| 운영체제                | 2th |
| 하드웨어                | 1th |

운영체제 위에 CLR이 동작하며 그 위에서 C# 프로그램이 동작합니다.
CRL은 엔진이다.
네이티브 코드만 운영체제 직접실행 가능하다.
C# 컴파일러가 만든 실행파일은 하드웨어가 이해할 수 없다.
C# --> IL이라는 중간언어 실행파일 --> CLR이 하드웨어가 읽을 수있는 네이티브 코드 컴파일
이를 JIT; Just In Time컴파일이라고 부른다. 코드를 실행할 때마다 실시간으로 컴파일해 실행한다.
CLR은 C#뿐만 아니라 다른 언어도 사용되도록 설계되었기 때문에 한번 더 거친다.

# C# 250717 Chapter03

데이터의 종류 / 변수 / 값-참조 형식 / 기본데이터형식 / 상수 및 열거/ Nullable / var

##### 데이터 종류

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

이를 이해하려면 `stack`과 `heap` 두가지 메모리 영역에 대해 알아야한다
`stack 메모리`는 값 형식을 가지며,
`heap 메모리`은 참조 형식을 가진다.
