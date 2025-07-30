# 프로퍼티

```txt
프로퍼티 --> 생성자 --> 무명 형식 --> 인터페이스의 프로퍼티 --> 추상클래스와 프로퍼티
```

## 1. 프로퍼티

프로퍼티란 `private`를 사용한 필드의 은닉성을 지키기 위해, public 메서드와 this를 통해 자신의 필드에 접근합니다. 일반적인 클래스의 `Get/Set` 메소드 대신 프로퍼티를 이용할 수 있습니다.

```csharp
interface ILogger
{
    void WriteLog(string message);
}
```

인터페이스는 `구현부`가 없습니다.
`public`으로 선언됩니다. 인터페이스는 그냥 사용할 수 없으며, 클래스에서 상속받아 파생클래스를 만들어야합니다.
또한 모든 메서드 및 프로퍼티를 구현해주어야만 합니다.

```csharp
namespace _09_Property
{
    internal class Program
    {
        class GeneralClass      //일반 클래스의 get/set
        {
            private int field;
            public int GetMyField(){return field;}
            public int SetMyField(int NewField){this.field = NewField;}
        }

        class PropertyClass      //프로퍼티를 이용
        {
            private int field;
            public int Field
            {
                get
                {
                    return field;
                }
                set
                {
                    field = value;
                }
            }
        }
    }
}
```

위처럼 훨씬 깔끔하고 원래 필드의 변수명을 대문자를 이용하여 사용하고 있어 개발자에게 간편하게 제공됩니다.

```csharp
namespace _09_Property
{
    internal class Program
    {
        //자동구현 프로퍼티
        class NameCard
        {
            private string name;
            private string phoneNumber;

            public string Name { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}
```

이처럼 자동 구현도 해주며, 개발자가 간편하게 사용할 수 있습니다.

---

## 2. 프로퍼티와 생성자

`클래스`를 통해 객체를 생성할때, 매개변수를 입력받아서 각 필드를 초기화 했었습니다.
이번에는 `프로퍼티`를 이용하여 객체의 각각의 필드를 초기화 할 수 있습니다.

```csharp
namespace _09_Property
{
    internal class Program
    {
        //생성자 프로퍼티
        class BirthdatInfo
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }

        }
        static void Main(string[] args)
        {
            BirthdatInfo info = new BirthdatInfo()
            {
                Name = "서현",
                Birthday = new DateTime(1995,03,02)
            };
        }
    }
}
```

new 키워드를 이용한 클래스를 선언함과 동시에 `{}`를 이용하여 각 프로퍼티를 이용합니다. `;`가 아닌 `,`를 이용하셔야 합니다.

**여기서 짚고 넘어가야 할것**
모든 class 나 record 는 `Equal()`이라는 메서드를 가지고 있습니다. 기본적으로 참조형식을 비교하여, `true` or `false`를 반환합니다. 그래서 클래스는 같지만 인스턴스(객체)가 메모리 주소를 따로 가지고 있기에, 비교하면 `false`가 반환됩니다.  
하지만 record의 형태를 가진 인스턴스(객체)는 Equal()을 하더라도 값형식으로 비교하기에, true가 나올 수 있습니다.

## 3. 이름이 없는 무명 형식

무명형식은 한번만 쓰고 다신 사용하지 않을때 사용하면 간편합니다.

```csharp
namespace _09_Property
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //무명 형식의 인스턴스
            var myInstance = new { Name = "나", Age = "16" };
        }
    }
}
```

이런식으로 아무것도 없이 변수에 담아 놓는 객체입니다.  
여기서 주의해야 할 것은 프로퍼티에 담긴 값들은 `불변`이라는 겁니다. 이렇게 만든 인스턴스는 읽기만 가능합니다.

## 4. 인터페이스의 프로퍼티

`인터페이스` 또한 프로퍼티와 인덱서를 가질 수 있습니다. 단 메서드처럼 상속받는 파생클래스에서 **`반드시`** 구현이 필수적입니다.

```csharp
namespace _09_Property
{
    internal class Program
    {
        //인터페이스 프로퍼티
        interface IProduct
        {
            string ProductName
            {
                get; set;
            }
        }
        class Product1 : IProduct        //파생 클래스에서 반드시 구현
        {
            private string productName;
            public string ProductName
            {
                get {  return productName; }
                set { productName = value; }
            }
        }
        class Product2 : IProduct       //두번째 방법
        {
            public string ProductName { get; set; }
        }
        class Product3 : IProduct       //세번째 방법
        {
            public string ProductName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }
    }
}
```
