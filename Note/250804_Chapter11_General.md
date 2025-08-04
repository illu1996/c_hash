# 일반화

```txt
일반화 메서드 --> 일반화 클래스 --> 형식 매개변수 제약 --> 일반화 컬렉션 --> foreach 사용 가능한 일반화 클래스
```

## 1. 일반화 프로그래밍

일반화란 공동된 개념을 묶어 사용하는 기법입니다.  
C# 에서는 데이터 형식을 일반화 합니다.

매개변수로 int를 받는 Copy()라는 함수를 만들었는데, 갑자기 string 도 필요하고, 실수도 필요하다면 또 오버라이딩을 해야겠지요.
이걸 쉽게 만들기 위해서 `T[]`라는 것을 이용합니다. `T` 는 `Type`를 뜻합니다

## 2. 일반화 메서드

```csharp
namespace General
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //메서드
            void Copy(int[] array, int[] target) { }
            void Copy(string[] array, int[] target) { }

            int[] ints = { 1, 2, 3 };
            //일반화
            void Copy<T>(T[] array) { }

            Copy<int>(ints);
        }
    }
}

```

## 3. 일반화 클래스

일반화 클래스 또한 데이터 형식에 얽메이지 않고, 지정만 해주며 사용할 수 있습니다.  
필요할때, T 부분의 형식만 바꾸어서 사용하면 됩니다.

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        class Array_Int
        {
            private int[] ints;
            public int GetInts(int[] ints) { return ints[0]; }
        }
        class Array_Double
        {
            private double[] doubles;
            public double GetDoubles(double[] doubles) { return doubles[0]; }
        }
        class Array_Generic<T>
        {
            private T[] generics;
            public T GetGenerics(T[] T) { return generics[0]; }
        }
    }
}
```

---

## 4. 데이터 형식 메개변수 제약 시키기

일반화를 사용하실때, 모든 데이터 형식이 아닌 우리가 원하는 형식만 제약시킬 수도 있습니다.

```csharp
class MyList<T> where T:MyClass{}
class CopyArray<T> (T[] source, T[] target) where T:struct {}
//where 형식 매개변수 : 제약조건을 이용하여 사용합니다.
```

| 제약                       | 설명                                           |
| -------------------------- | ---------------------------------------------- |
| where T:struct             | T는 값형식                                     |
| where T:class              | T는 참조 형식                                  |
| where T:new()              | T 반드시 매개변수가 없는 생성자 필수           |
| where T:기반\_클래스\_이름 | T는 명시한 기반 클래스의 파생클래스            |
| where T:인터페이스\_이름   | T는 명시한 인터페이스 필수 구현                |
| where T:U                  | T는 다른 형식 매개변수 U로부터 상속받은 클래스 |

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        class StructArray<T> where T:struct     //값형식인 struct
        {
            public T[] Array {get;set;}
            public StructArray(int size){}
        }

        class RefArray<T> where T : class       //참조형식인
        {
            public T[] Array { get; set; }
            public RefArray(int size) { }
        }
    }
}
```

## 5. 일반화 컬렉션

많이 사용하는 `List<T>`, `Queue<T>`, `Stack<T>`, `Dictionary<TKey, TValue>` 만 설명하고 넘어가겠습니다.

### List<T>

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<T>
            List<int> lst = new List<int>();
            lst.Add(1);
            lst.Add(2);

            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }
            lst.RemoveAt(1);
            lst.Insert(0,2);
        }
    }
}
```

### Queue<T>

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Queue<T>
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("a");
            queue.Enqueue("b");

            string strings = queue.Dequeue();

            Console.WriteLine(strings);
        }
    }
}
```

### Stack<T>

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stack<T>
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Pop();
        }
    }
}
```

### Dictionary<Tkey,TValue>

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<Tkey,TValue>
            Dictionary<string, string> dicts = new Dictionary<string, string>();
            dicts["a"] = "b";
            dicts["b"] = "c";
            Console.WriteLine(dicts["a"]);
        }
    }
}
```
