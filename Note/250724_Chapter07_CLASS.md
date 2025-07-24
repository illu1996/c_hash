# 클래스

```txt
객체지형 --> 클래스 선언 및 객체 생성 --> 정적 필드와 메서드 --> 객체 복사 --> this --> 접근 한정자 --> 상속 --> 기반 클래스, 파생클래스 --> 오버라이딩 및 다형성 --> 메서드 숨기기 --> 오버라이딩 봉인 --> 중첩클래스 --> 분할 클래스 --> 확장 메소드 --> 구조체
```

## 1. 객체 지향 프로그래밍 OOP

객체 지향 프로그래밍은 고드의 모든 것을 객체로 표한하고자 하는 프로그래밍 패러다임입니다.  
`객체`란 세상의 모든 것을 객체로 표현 가능합니다.
`객체`라고 말할 수 있는 것은 두가지 `속성(데이터), 메서드(기능)`을 가지고 있습니다.
사람이라면 피부색, 키 등의 속성을 가지고 있고, 걷기 뛰기 등의 기능을 가지고 있습니다.  
여기서 등장하는 것이 `클래스`입니다.
`클래스`란 객체를 만들기 위한 청사진입니다. 3개의 객체를 만들었다면 메모리공간을 각각 다르게, 3개를 가지고 있습니다. 이런 이유들로 객체가 무한히 만들어진다면 `메모리는 무한하지 않으니 메모리 관리를 해야한다` 등의 이야기가 나오는 것입니다.

---

## 2. 클래스

### 클래스 선언

클래스는 `class` 키워드를 사용해 선언합니다.

```csharp
namespace _07_Class
{
    internal class Program
    {
        class Cat
        {
            public string Name;     //필드;속성;데이터
            public string Color;    //필드;속성;데이터
            public void Meow()      //메서드
            {
                Console.WriteLine($"{Name}, 야옹");
            }
        }
        static void Main(string[] args)
        {
            Cat kitty = new Cat();              //객체 생성
            kitty.Name = "kitty";               //필드
            kitty.Meow();                       //메서드
        }
    }
}
```

위처럼 클래스(설계도)를 미리 만들어 놓고, 객체(인스턴스)를 형성하여, 이름을 넣고, 메서드들을 실행할 수 있습니다.  
C# 에서는 `new` 키워드를 이용하여 객체를 생성하는데, `Cat()`이라는 생성자를 통해 `클래스의 이름`과 `()`를 통해 `객체`를 생성합니다.
`Cat`이라는 데이터 형태를 가지며, kitty라는 변수로 네이밍을 했습니다.  
kitty는 메모리주소공간을 참조하는 `new Cat()`이라는 객체를 담고 있는 메모리공간을 참조할 뿐입니다.

### 생성자와 종료자

`생성자 : Constructor`  
`소멸자 : Finalizer`

생성자는 `클래스`의 이름과 같으며, 반환 형식이 없이 클래스의 인스턴스(객체)를 생성하는 것 뿐입니다.
클래스를 선언할때, 명시적으로 구현하지 않아도 컴파일러에서 생성자를 자동으로 만들어주는 기능도 있습니다.  
다만 더 큰 범위의 여러 객체들을 다루다보면 필요한 시점에 원하는 값으로 지정(초기화)해 줄 때가 있어 사용합니다.
이전의 코드를 조금 수정하여 예시를 보겠습니다.

```csharp
namespace _07_Class
{
    internal class Program
    {
        class Cat
        {

            public string Name;     //필드;속성;데이터
            public string Color;    //필드;속성;데이터

            public Cat(string _Name, string _Color)         //원할때 초기화 하는 생성자
            {
                this.Name = _Name;
                this.Color = _Color;
            }
            public void Meow()      //메서드
            {
                Console.WriteLine($"{Name}, 야옹");
            }
        }
        static void Main(string[] args)
        {
            Cat kitty = new Cat();              //객체 생성
            kitty.Name = "kitty";               //필드
            kitty.Meow();                       //메서드
        }
    }
}
```

아까와 달리 이번엔 `Public Cat(string _Name, string _Color)` 가 생겼습니다.  
다만 생성자를 코드로 입력하지 않고 사용하는 컴파일러가 제공하는 기본 생성자 `new Cat()` 와 원할때 쓰는 `new Cat(string _Name, string _Color)` 중에 선택하여 코드를 입력하여 사용하면 됩니다.

설명의 제목은 생성자와 종료자인데, 종료자는 그냥 사용하지 마세요... 정말 궁금하시면 ~~살짜쿵 인터넷에~~ 검색해보기

---

## 3. 정적 필드와 정적 메서드

프로그래밍을 하다 보면 `전역 변수`라는 것을 여러번 들어보았을 겁니다.  
어디에 속해있지 않고 전역에서 불러 쓸 수 있는 변수를 말하는데,
`Static`과 비교해보겠습니다.  
`클래스`는 `필드`와 `메서드`를 가지고 있기에, 각각의 `인스턴스(객체)`들은 클래스의 `필드`와 `메서드`를 참고하여 각각의 `필드`와 `인스턴스`를 가져 다른 값을 가지고 있습니다.  
하지만 공통의 필드와 메서드들도 필요할때가 있으면 `static`을 사용하면 됩니다.  
코드로 봅시다.

#### 정적 필드

```csharp
namespace _07_Class
{
    internal class Program
    {
        class M_Class
        {
            public int a;
            public int b;

            public static int c;
            public static int d;
        }

        static void Main(string[] args)
        {
            M_Class m = new M_Class();      //인스턴스(객체) 1
            m.a = 1;
            m.b = 2;

            M_Class n = new M_Class();      //인스턴스(객체) 2
            n.a = 1;
            n.b = 2;

            M_Class.c = 3;                  //static: 정적 필드
            M_Class.d = 4;
        }
    }
}
```

위처럼 각각의 `m, n`은 인스턴스들로 자기만의 `필드`가 있는데, `M_Class.c`, `M_Class.d` 로 지정한 필드들은
`클래스 이름`을 통해 접근할 수 있습니다.

```csharp
namespace _07_Class
{
    internal class Program
    {
        class Global
        {
            public static int count = 0;
        }

        class GA
        {
            public GA()     //GA의 인스턴스를 생성할때마다 Global Class의 count 증가
            {
                Global.count++;
            }
        }
        class GB
        {
            public GB()     //GB의 인스턴스를 생성할때마다 Global Class의 count 증가
            {
                Global.count++;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"count = {Global.count}");       //0
            GA a = new GA();
            GB b = new GB();
            GA c = new GA();
            GB d = new GB();
            Console.WriteLine($"count = {Global.count}");       //4
        }
    }
}
```

정적 필드를 이런식으로 사용도 할 수 있드아...

#### 정적 메서드

`정적 메서드`도 `정적 필드`와 비슷하다. 인스턴스(객체) 없이 불러서 쓸수 있다

```csharp
namespace _07_Class
{
    internal class Program
    {
        class Global
        {
            public static void voice(){
                Console.WriteLine("노래하라!");
            }
        }

        static void Main(string[] args)
        {
            Global.voice();     //인스턴스 없이 접근
        }
    }
}
```

---

## 4. 객체 복사하기

```csharp
namespace _06_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = Calc.Plus(4, 3);
            Console.WriteLine(k);     //7

            //메서드 없이 구현
            int a = 3; int b = 4;
            int x = a+b;
            Console.WriteLine(x); // 7
        }
    }
    class Calc  //Calc 클래스 선언
    {
        public static int Plus(int x, int y) //메서드 생성
            {
                return x + y; //반환값
            }
    }
}
```

위 코드에서 `메서드`의 사용과 미사용이 결과가 다르지 않다.<br>
물론 직접 구현하는 것도 틀린 것은 아니며, 코드의 가독성은 좋다.<br>
하지만 프로그램이 커진다거나 혹은 매번 값이 변경될때마다 바꿔주어야 한다거나 어려운 일이 생긴다.

`메서드`를 이용하면 매번 불러와 사용하면 코드가 깔끔해질 수 있다.

---

## 2. return

`JUMP문`을 기억하시나요? <br>
기억이 나지 않아도 괜찮습니다. ㅋㅋㅋㅋㅋㅋㅋㅋ이렇게 쓰고 있는 저도 기억이 나지 않으니까요.  
그냥 말그대로 점프하는 느낌으로다가 기억해놨습니다.

다시 `return` 으로 돌아와서, `return` 은 `JUMP문` 의 일종이라고 보아도 좋습니다.  
`메서드`를 끝내고 다시 `호출자`에게 흐름을 바꿔놓는 역할을 합니다.

~~코드 쓰기 귀찮으니까 아까 써놓은걸 다시보자면~~

```csharp
namespace _06_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = Plus(4, 3); //return 받은 k를 int로 변수 선언
            Console.WriteLine(k);
        }
    }
    class Calc  //Calc 클래스 선언
    {
        public static int Plus(int x, int y) //반환값 형식 int
            {
                return x + y; //반환값
            }
    }
}
```

~~약간 다르게 썼으니까 모라 하지 않기~~

`return` 을 통해 `x + y` 를 돌려주고 있습니다.  
그러니까 정리하자면

> 1. `Class: Program`의 `Main`에서 `Class: Calc`의 `Method: Plus`를 `호출`했다!
> 2. 그랬더니 `Plus`가 `int`를 `return` 했다!

그래서 메서드를 선언할때, 반환값 형식인 int를 지정해줬습니다.  
또한 아래 코드 처럼 메서드를 언제든지 끝낼 수 있게 만들어 줍니다.

```csharp
//하나의 메서드
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
```

---

## 3. 매개변수

### 값에 의한 전달

> 본 ~~응애~~개발자는 그래도 개발 언어를 접해서 사용한지, 3년이 넘었다.......  
> 근데 매개변수에 대한 공부를 하면서 처음 접하는 내용이 있어서 깜짝깜짝 놀랐습니다.  
> 그래서 조금 설명이 길수도..... ~~귀찮아서 아닐수도~~....

`매개변수`란 우선 내가 기억하는건 함수나 메서드에 들어가는 인자,  
선언하면 받아야만 하거나 default로 정해줘야 하는것 정도로 알고 있었다.
그냥 가볍게 생각했다.

`이 매개변수라는게 어떻게 전달되는가?` 에 대해 고민해본적이 없다..... 실화?

맨날 deepcopy, 스웰로우 카피, 주소 참조, 값 형식 이런거만 그냥 이론으로 알지, 매개변수는 생각도 못해봤다.  
정답부터 알고 가자면 `값에 의한 전달`이라고 알고 넘어가자....  
~~사실 제가 저 말만 보고 바로 이해를 못했....~~

조금 더 자세히 설명하면 내가 넣어주는 매개변수`int a`가 값이 무엇이든 상관없이, a에 그냥 복사되서 들어간대요!!!! 똑같은 데이터를 갖지만 별개의 메모리 공간을 차지해서 복사해주는 거죠...

아 !!! 그래서 매개 `변수` 구나 라는걸 ~~응애~~개발자가 깨닫고 갑니다.

### 참조에 의한 매개변수 전달

근데 또 값만 전달하면 불만이 생기는 ~~저같은~~ 개발자가 분명 나올거란 말이죠??  
그러니까 `참조에 의한 매개변수`가 등장합니다.  
매개변수로 `ref`를 통해서 주소를 전달하는 일입니다.  
코드를 먼저 봅세 !!!

```csharp
//하나의 메서드
public static bool swap(ref int k, ref int l) //ref로 전달하기!
{
    ...
}
```

이런식으로 사용되어 메모리 주소공간을 선언한 변수 자체가 바뀌는거죱!!!!!  
예를 들어, `int a`라는 메모리 주소`x23q`에 `10`을 저장하고 있었고,  
`int b`라는 메모리 주소`x23w`에 `20`을 저장하고 있었는데,  
swap하면 a가 20, b가 10이 되어버린다는 사실!!!!

### 에엥? return값을 ref를 준다고?????

> ~~저같은~~ 개발자가 또 불만이 있었나봐요.....  
> 무슨... return을 ref 같은걸 줘.... 코드 읽기 넘나 불편해....

이제는 `ref` 또한 `return`으로 줄 수 있습니다!  
다만, `static` 한정자를 사용하지 못해서, `class`를 꼭 생성하고 사용!!!

```csharp
class SOME
{
    int SomeValue = 10;
    public ref int SomeTHTHING()
    {
        return ref SomeValue; //ref 를
    }
}
```

### 출력전용 ref 매개변수 사용해보자....

> 배웠으니 써먹어봐야지

우선 필자는 a, b, c, d를 이용해볼라 합니다.

```csharp
namespace _06_Method
{
    class Calc
    {
        public static void Devide(int a, int b, out int qt, out int rd)
        {
            qt = a / b;
            rd = a % b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 3; int b = 4;
            int c;
            int d;
            Calc.Devide(a, b, out c, out d);
        }
    }
}
```

> ref 대신 out 키워드를 사용하면 똑같이 일하지만 <span style="color:red"> **컴파일선생님** </span>이 나대신 에러를 잡아준다.

내가 가진 a,b,c,d를 이용해 a / b, a % b를 한 값을 내가 알려준 주소 c,d에 넣어달라고 부탁하는 것 같다.  
사실 return 해서 받아온 값을 변수에 선언하는 거나, 메모리주소를 미리 지정해놓고 거기다가 넣어달라고 하는 것처럼 보이는 것인 똑같이 느껴지는 건 나만 그런걸까???  
아시는분 있으면 댓글에 좀....

드디어 매개 변수 끝 !!!!!

---

## 4. 메서드 오버로딩

개발자면 맨날 나오는 `오버로딩`과 `오버라이딩`.... 지겹다 너란자식.....  
~~로딩이 너무 심해서 오버 났네~~  
~~오토바이 라이딩하다가 오버 났네~~

#### 꼭 알고 넘어가야 할것

`오버라이딩` : 부모 - 자식 사이에서 부모에서 만들어놓은 메서드를 `재정의`하는것!  
`오버로딩` : 메서드 이름은 같되, 매개변수만 다르게 해서 `결과`가 다르게 하는것!

```csharp
int Plus(int a, int b)
{
    return a + b
}
//메서드 오버로딩
double Plus(double a, double b)
{
    return a + b
}
```

## 5. 매개변수의 가변, 명명 매개변수, 선택적 매개변수

`매개변수의 가변` : 매개변수를 다 다르게 하고 싶을때

```csharp
int Sum(Params int[] args){
    int sum = 0;
    foreach (int i in args)
    {
        sum += i;
    }
    return sum
}
int total = 0;
total = Sum(1,2); // 3
total = Sum(1,2,3,4); // 10
total = Sum(1,2,6,7,8); // 24
```

`명명 매개변수`: 매개변수 목록 중 순서에 상관없이 매개변수를 넣어주고 싶을때

```csharp
void PrintProfile(string name, string phone)
{
    Console.WriteLine($"name:{name}, phone:{phone}");
}

void Main(String[] agrs)
{
    PrintProfile(name:"박찬호", phone:"010-1234-1234");
}
```

`선택적 매개변수`: 매개변수가 기본값을 가질 수 있을 때

```csharp
void method(int a, int b =0)
{
    Console.WriteLine($"a = {a}, b = {b}");
}

void Main(String[] agrs)
{
    method(3); // a = 3, b = 0
    method(3,4) // a= 3, b = 4
}
```

## 6. 로컬 함수

메서드 내부에 함수를 선언하여 자신만 필요한 계산값을 지정할때, 메서드와 비슷하지만 메서드 내부에만 있는 로컬 함수를 쓸 수 있습니다.

```csharp
namespace _06_Method
{
    class Calc
    {
        public static void Devide(int a, int b, out int qt, out int rd)
        {
            k = "LEE"
            qt = a / b;
            rd = a % b;

            //로컬 함수
            double MinusOne(double db)
            {
                return db - 1
            }
        }
    }
}
```

---

이로써 오늘 메서드에 대해 알아보았습니다.
대부분이 아는 내용이라 빠르게 훑었지만 그래도 모르는 부분들도 나와서 좋은 ...시간이었습니다.

과연 필자는 내일 기억할 수 있을까요.....?
내일은 객체지향에 필수적인 `클래스`에 대해서 공부하도록 하겠습니다.
다들 안녕히 주무세요!!!!!
