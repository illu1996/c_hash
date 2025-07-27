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

## 4. 객체 복사하기 : 얕은 복사와 깊은 복사

```csharp
namespace _07_Class
{
    class Myclass
    {
        public int MyField1;
        public int MyField2;
    }

    internal class Program
    {
        Myclass mc = new Myclass();
        mc.MyField1 = 10;
        mc.MyField2 = 20;

        Myclass tg = mc;        //복사하여 사용
        mc.MyField2 = 30;

        Console.WriteLine($"{mc.MyField1}, {mc.MyField2}");     //10,30
        Console.WriteLine($"{tg.MyField1}, {tg.MyField2}");     //10,30
    }
}
```

원래 생각대로라면 `10,20`이 출력되어야 했지만, `10,30`이 출력되는 것을 볼 수 있다.  
이는 클래스가 참조형식이라 메모리에 할당되고, `tg`가 메모리를 참조해서 그 값 자체를 바꿔버려 둘 다 `10,30`이 출력되는 것이다.  
이처럼 메모리 주소를 참조하여, 같은 값을 바라보는 것을 `얕은 복사` 라고 합니다.  
이와 반대로 값을 바라보고 새로운 메모리 공간에 지정되어 복사되는 것을 `깊은 복사` 라고 합니다.  
클래스를 새로 선언하여 메모리 주소를 다시 할당 받아야합니다.

```csharp
namespace _07_Class
{
    class Myclass
    {
        public int MyField1;
        public int MyField2;
        public Myclass DeepCopy()
        {
            Myclass newCopy = new Myclass();
            newCopy.MyField1 = this.MyField1;
            newCopy.MyField2 = this.MyField2;
            return newCopy;
        }
    }
    internal class Program
    {
        Myclass mc = new Myclass();
        mc.MyField1 = 10;
        mc.MyField2 = 20;

        Myclass tg = mc;        //복사하여 사용
        mc.MyField2 = 30;

        Console.WriteLine($"{mc.MyField1}, {mc.MyField2}");     //10,30
        Console.WriteLine($"{tg.MyField1}, {tg.MyField2}");     //10,30

        Myclass mc1 = new Myclass();
        mc1.MyField1 = 10;
        mc1.MyField2 = 20;

        Myclass tg1 = mc1.DeepCopy();       //구현했던 딥카피
        tg1.MyField2 = 30;

        Console.WriteLine($"{mc1.MyField1}, {mc1.MyField2}");       //10,20
        Console.WriteLine($"{tg1.MyField1}, {tg1.MyField2}");       //10,30
    }
}
```

이처럼 C#에서는 깊은 복사를 하여 아예다른 메모리 공간에 클래스를 할당받았습니다.  
이러면 값을 바꿔도 아예 다른 값을 참조하기때문에 원본에 영향을 미치지 않습니다.  
다만, 다수의 객체가 생길때마다 메모리를 사용하므로 유의하고 복사해야합니다.

---

## 5. this 키워드

`this`는 자기 자신을 지칭할 때, 사용하는 키워드입니다.  
객체 외부에서 객체의 필드나 메소드에 접근 시 `MyObj.name`형태로 접근하지만  
객체 내부에서 필드나 메서드에 접근 시 `this.name` 형태로 접근합니다.

```csharp
namespace _07_Class
{
    class Emp
    {
        private string Name;
        public void SetName(string _Name)
        {
            this.Name = _Name;
        }
        public string GetName()
        {
            { return this.Name; }
        }
    }
    internal class Program
    {
        Emp pooh = new Emp();
        pooh.SetName("Pooh");
        string pooh_name = pooh.GetName();
        Console.WriteLine(pooh_name);       //Pooh
    }
}
```

이처럼 객체 내부에서 값을 숨기기 위해 `private` 한정자를 이용했고, `this`를 사용하여 접근하도록 했습니다.

---

## 6. 접근한정자 private

객체지향 프로그래밍에서 필요한 최소의 기능만 노출하고 내부로 감추는 것을 은닝성이라고 합니다.  
클래스로 선언된 것 들 중에 노출해야하는 것과 반드시 노출하지 말아야 할 것들이 있습니다.  
그래서 접근한정자 `private`를 이용해 감추는 것입니다.

| 접근 한정자        | 설명                                                                  |
| ------------------ | --------------------------------------------------------------------- |
| public             | 클래스 내외부 모든 곳 접근 가능                                       |
| protected          | 클래스 외부에서 접근 불가능 하지만, 파생클래스에서 접근 가능          |
| private            | 클래스 내부에서만 접근 가능, 파생클래스에서 접근 불가능               |
| internal           | 같은 어셈블리에 있는 코드만 public으로 접근 가능                      |
| protected internal | 같은 어셈블리에 있는 코드만 protected으로 접근 가능                   |
| pivate protected   | 같은 어셈블리에 있는 클래스에서 상속 받은 클래스 내부에서만 접근 가능 |

```csharp
namespace _07_Class
{
    class WaterHeater
    {
        protected int temp;

        public void SetTemp(int _Temp)
        {
            if (_Temp <= -5 || _Temp > 42)
            {
                throw new Exception("Out of range.");
            }
            this.temp = _Temp;
        }
        internal void TurnOnWater()
        {
            Console.WriteLine($"Turn On :{temp}");
        }
    }
    internal class Program
    {
        //접근 한정자
        WaterHeater bithe = new WaterHeater();
        bithe.SetTemp(20);
        bithe.TurnOnWater(); //20

        bithe.SetTemp(50);
        bithe.TurnOnWater(); //에러 표시
    }
}
```

---

## 7. 상속과 오버라이닝과 다형성

클래스를 재사용 하기 위해 `상속`이라는 것을 지원합니다.  
부모의 클래스를 자식이 상속받아 재사용 할 수 있어, 코드의 재활용성을 높여줍니다.  
객체지향 프로그래밍에서 물려받는 클래스를 파생클래스(Derived Class) 혹은 자식 클래스라고 합니다.

```csharp
namespace _07_Class
{
    class Mammal
    {
        protected string Name;
        public void SetName(string _Name)
        {
            this.Name = _Name;
        }
        public void Nurse()
        {
            Console.WriteLine("Nulse()");
        }
        public
    }
    class Dog : Mammal
    {
        public void Bark()
        {
            Console.WriteLine($"{this.Name}: Bark()");
        }
    }
    class Caty : Mammal
    {
        public void Meow()
        {
            Console.WriteLine($"{this.Name}: Meow()");
        }
    }
    internal class Program
    {
        //상속
        Mammal mammal1 = new Dog();
        Dog dog;
        if (mammal1 is Dog)
        {
            dog = (Dog)mammal1;
            dog.SetName("멍멍이");
            dog.Bark();     //멍멍이: Bark()
        }

        Mammal mammal2 = new Caty();
        Caty caty = mammal2 as Caty;
        if (caty != null)
        {
            caty.SetName("냥냥이");
            caty.Meow();        //냥냥이: Meow()
        }
    }
}
```

`Mammal` 에 `Dog` 와 `Caty`가 상속을 받고, `Mammal`의 `인스턴스`를 상속받아서 이름을 각자 가지게 됩니다.

## 8. 중첩 클래스

`중첩 클래스`란 클래스 내부에 클래스를 다시 선언하는 것입니다.  
클래스를 외부에 공개하고 싶지 않거나, 클래스의 일부분처럼 표현하는 클래스를 만들고자 할때, 사용합니다.
또한 중첩 클래스는 상위클래스의 필드나 메서드에 자유롭게 접근가능합니다.

```csharp
namespace _07_Class
{
    class Configuration
    {
        private class Value{
            private string item;
            private int val;

            public Value(Configuration Config, string _item, int val)
            {

            }
        }

        public void setVal(string item, int val)
        {
            Value iv = new Value(Config, item, val);
        }
    }

    internal class Program
    {
        //중첩 클래스 Nested Class
        Configuration config = new Configuration();

    }
}
```

## 9. 분할 클래스

분할 클래스란 `Partial Class`로 같은 클래스이지만 여러번에 나누어 구현하는 클래스입니다.  
파일이 너무 길어 나누어 구현할 수 있도록 편의를 제공합니다.

클래스이름은 동일해야한다!

```csharp
partial class MyClass
{
    public void mt1(){}
    public void mt2(){}
}

partial class MyClass
{
    public void mt3(){}
    public void mt4(){}
}
```

## 10. 구조체

클래스와 사촌지간인 `구조체`가 있습니다. 구조체는 `Structure`로 선언하며, 필드와 메서드 가지는 것 등 상당 부분 비슷합니다.

| 특징     | 클래스             | 구조체             |
| -------- | ------------------ | ------------------ |
| 키워드   | class              | struct             |
| 형식     | 참조 형식(힙 할당) | 값 형식(스택 할당) |
| 복사     | 얕은 복사          | 깊은복사           |
| 인스턴스 | new연산자 사용     | 선언만으로 생성    |
| 생성자   | 매개변수 미필수    | 매개변수 필수      |
| 상속     | 가능               | 값형식이라 불가능  |

```csharp
namespace _07_Class
{
    struct Point3D
    {
        public int x;
        public int y;
        public int z;

        public Point3D(int x,int y,int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return string.Format($"{x},{y},{z}");
        }
    }

    internal class Program
    {
        //구조체
        Point3D p3d;
        p3d.x = 10;
        p3d.y = 20;
        p3d.z = 50;
        Console.WriteLine(p3d.ToString());      //10, 20, 50

        Point3D p3d2 = new Point3D(100,200,300);
        Console.WriteLine(p3d2.ToString());     //100,200,300

        Point3D p3d3 = p3d2;
        p3d3.y = 1000;
        Console.WriteLine(p3d3.ToString());     //100,1000,300
    }
}
```
