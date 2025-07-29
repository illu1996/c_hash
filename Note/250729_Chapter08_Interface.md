# 인터페이스 및 추상클래스

```txt
인터페이스 선언 --> 인터페이스 상속하는 인터페이스 --> 여러개의 인터페이스, 한번에 상속하기 --> 추상 클래스
```

## 1. 인터페이스 선언

'인터페이스' 는 클래스 선언과 비슷하지만 '메소드', '이벤트', '인덱서', '프로퍼티' 만을 가질 수 있습니다.

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
using System;
using System.IO;

namespace _08_Interface
{
    internal class Program
    {
        interface ILogger       //인터페이스
        {
            void Log(string message);
        }
        class ConsoleLogger : ILogger       //상속
        {
            public void Log(string message)
            {
                Console.WriteLine($"{DateTime.Now.ToLocalTime()},{message}");
            }
        }
        class FileLogger : ILogger      //상속
        {
            private StreamWriter _writer;
            public FileLogger(string path)
            {
                _writer = new StreamWriter(path);
                _writer.AutoFlush = true;
            }
            public void Log(string message)
            {
                Console.WriteLine($"{DateTime.Now.ToLocalTime()},{message}");
            }
        }
        class ClimateMonitor
        {
            private ILogger _logger;
            public ClimateMonitor(ILogger logger)
            {
                this._logger = logger;
            }
            public void start()
            {
                while (true)
                {
                    Console.Write("온도를 입력하세요 : ");
                    string temperature = Console.ReadLine();
                    if (temperature == "") break;
                    _logger.Log($"현재 온도 : {temperature}");
                }
            }
        }
        static void Main(string[] args)
        {
            ClimateMonitor monitor = new ClimateMonitor(new FileLogger("MyLog.txt"));
            monitor.start();
        }
    }
}
```

---

## 2. 인터페이스를 상속하는 인터페이스

`인터페이스`는 클래스 말고도 또 다른 인터페이스와 구조체 등을 상속할 수 있습니다.  
인터페이스를 수정하지 않고 또 상속을 이용하여 인터페이스를 만드는 경우는

1. `상속하려는 인터페이스가 소스코드가 아닌 어셈블리로 제공되는 경우`
2. `상속하려는 인터페이스의 소스 코드가 있지만, 벌써 인터페이스를 상속한 클래스가 있는 경우`

이 두가지 상황은 인터페이스를 상속하는 인터페이스를 만들 수 밖에 없습니다.  
인터페이스를 상속 받는 방법은 클래스와 동일합니다.

```csharp
interface 파생인터페이스 : 부모인터페이스 {}

interface ILogger
{
    void Log(string message);
}
interface IFormattableLogger : ILogger
{
    void Log(string format, params Object[] args);
}
class ConsoleLogger2 : IFormattableLogger
{
    public void Log(string message) {}
    public void Log(string format, params Object[] args)
}
```

## 3. 여러개의 인터페이스 한번에 상속

`클래스`에서 한꺼번에 여러개를 상속받으면 **`죽음의 다이아몬드`**의 문제에 부딪히게 됩니다.  
죽음의 다이아몬드는 부모클래스의 메서드 이름이 모두 같은데, 어떤 부모의 메서드를 사용해야 하는지 정할 수 없습니다. 또한 **`업캐스팅`** 문제를 만날 수도 있습니다.  
이러한 이유들로 C#은 다중 상속이 불가능하며, 컴파일 단계에서 걸러지게 됩니다.

```csharp
using System;
using System.IO;

namespace _08_Interface
{
    internal class Program
    {
        //다중 인터페이스 상속
        interface IRunnable
        {
            void Run();
        }
        interface IFlyable
        {
            void Fly();
        }
        class FlyingCar : IRunnable, IFlyable
        {
            public void Run() { }
            public void Fly() { }
        }
        static void Main(string[] args)
        {
            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();
        }
    }
}
```

## 4. 인터페이스의 기본 구현 메서드

원래라면 인터페이스에 `구현부`는 존재하지 않아야합니다. 다만 인터페이스에 새로운 메서드를 추가하고 싶을때, 인터페이스를 수정하면 상속받고 있는 파생클래스의 모든 부분에 메서드 오버라이딩을 통해 정의해주어야 합니다.  
다만 지금 설명드릴 기본 구현 메서드를 만들면 파생클래스에서 메서드 오버라이딩 없이, 오류가 나지 않습니다.

```csharp
interface ILogger
{
    void Log(string message);
    void ErrorLog(string error)     //메서드 추가 및 기본 구현
    {
        Log($"Error : {error}")
    }
}
```

이렇게 하면 컴파일 오류가 나지 않습니다.
다만 `클래스`를 통해 인스턴스(객체)를 만들어도 인스턴스에서 `ErrorLog`를 직접 불러오면 오버라이딩을 하지 않아 불러 올 수 없습니다.

```csharp
using System;
using System.IO;

namespace _08_Interface
{
    internal class Program
    {
        interface ILogger       //인터페이스
        {
            void Log(string message);
            void ErrorLog(string error)
            {
                Log(error);
            }
        }
        class ConsoleLogger : ILogger       //상속
        {
            public void Log(string message)
            {
                Console.WriteLine($"{DateTime.Now.ToLocalTime()},{message}");
            }
            // ErrorLog 미구현
        }
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.Log("System up");
            logger.ErrorLog("System down");     //에러없음

            ConsoleLogger clogger = new ConsoleLogger();
            clogger.Log("System up");
            clogger.ErrorLog("System down");      //컴파일 에러
        }
    }
}
```

## 5. 추상클래스 : 인터페이스와 클래스의 사이

**`인터페이스`**와는 다르게 **`추상클래스`** 는 **구현부**를 가질 수 있습니다.  
하지만 **`클래스`** 와는 다르게 인스턴스를 생성하지 못합니다. **`abstract`**를 통해 선언합니다.

```csharp
abstract class Name
{
    //...
}
```

인터페이스는 모든 메서드가 `public`으로 선언되는 반면, 추상클래스는 클래스처럼 한정자를 명시하지 않으면 `private`로 선언됩니다. 추상 클래스에서는 추상메서드를 가져 반드시 파생클래스에서 구현하도록 강제합니다.

```csharp
abstract class Name     //추상 클래스
{
    public abstract void SomeMethod()       //추상 메서드
}
class NewName : Name
{
    public override void SomeMethod()       //필수
    {
        //...
    }
}
```
