# 배열, 컬렉션, 인덱스

```txt
배열의 초기화 --> System Array --> 2차원 배열 --> 다차원 배열 --> 가변 배열 --> 컬렉션 --> 인덱서
```

## 1. 배열의 선언

```html
데이터 형식 [] 배열 이름 = new 데이터 형식[용량]
```

`python`에서는 그냥 용량제한 없이 사용 가능하지만 `C#`이나 `Java`에서는 메모리를 관리를 위해 용량을 정해주는 편입니다. 물론 추후에 배울 가변 배열 또한 가능합니다.

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[5] { 10, 20, 30, 40, 50 };
            foreach (int i in scores)
            {
                sumScore += i;
            }
            Console.WriteLine(sumScore);        //150
        }
    }
}
```

위와 같이 선언하며, 처음에 값을 정해주는 것을 초기화 한다고 하는데, 초기화를 하지 않을 시 `int`형식은 0으로 초기화 됩니다.

## 2. 인덱스

방금 선언한 배열의 데이터에 접근하려면 여러가지 방법이 존재합니다. 접근하는 방법이 없다면 일일히 조회해서 값을 찾는 방법밖에 없습니다.  
이를 쉽게 해주기 위해서 `인덱스`라는 것이 존재합니다.

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //배열 선언
            int[] scores = new int[5] { 10, 20, 30, 40, 50 };
            foreach (int i in scores)
            {
                sumScore += i;
            }
            Console.WriteLine(sumScore);        //150

            //배열 인덱스
            Console.WriteLine(scores[0]);       //10
            Console.WriteLine(scores[3]);       //40
            Console.WriteLine(scores[-1]);      //50
            System.Index last = ^1;             //^1 == -1 == score.Length-1, ^2 == -2
            Console.WriteLine(scores[last]);    //50
            Console.WriteLine(scores[scores.Length - 1]);       //50
        }
    }
}
```

---

## 2. 배열의 초기화

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //배열 초기화
            string[] array2 = new string[] { "안녕", "hello", "Halo" };       //3개의 길이
            string[] array3 = { "안녕", "hello", "Halo" };
        }
    }
}
```

## 3. System.Array

C# 에서 모든 것은 객체인데, 배열도 마찬가지입니다.  
`System.Array` 의 클래스로부터 대응되는 객체입니다. 그러므로 `System.Array` 클래스의 특성과 메서드를 알고 있으면 모든 Array를 쉽게 다룰 수 있습니다.

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.Array
            int[] array4 = { 10, 30, 20, 7, 1 };
            Console.WriteLine(array4.GetType());                //System.Int32[]
            Console.WriteLine(array4.GetType().BaseType);       //System.Array
            Console.WriteLine(array4.Length);       //5 --> 길이반환 프로퍼티
            Console.WriteLine(array4.Rank);         //1 --> 차원반환 프로퍼티
            Array.Sort(array4);                     //배열정렬 메서드
            Array.BinarySearch(array4, 50);         //이진탐색 메서드
            array4.GetLength(0);                    //지정한 차원의 길이 반환 --> 인스턴스메서드
            Array.IndexOf(array4, 40);              //찾고자 하는 인덱스 반환 정적메서드
            bool trueOrFalse = Array.TrueForAll(array4, (array4) => array4 >= 10 );           //모든 요소들에 대한 검사
            int index = Array.FindIndex<int>(array4, (array4) => array4 >30);            //각각의 요소들에 대한 검사를 진행하여 첫번째 만족하는 인게스
            Console.WriteLine($"index = {index}");
            Array.Resize(ref array4, 10);               //참조하는 어레이의 용량 리사이징
            Array.Clear(array4,0,1);                //배열 초기화
            Array.ForEach(array4, (array4) => array4++);            //각각의 요소에 식을 적용
            int[] array5 = new int[3];
            Array.Copy(array4, 0, array5, 0, 3);                 //원하는 길이만큼 복사
        }
    }
}
```

엄청많은 메서드와 프로퍼티 들이 있는데, 다 외울 필요없이 필요한 것들을 사용하는 것이 좋습니다.

## 4. 배열 분할하기

위에서 본 `Array.Copy()` 메서드도 있지만 배열을 분할 하는 방법이 또 있습니다. 이를 많이 사용하는 용어로는 `슬라이싱`이라고 합니다.

```csharp
namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //슬라이싱
            int[] ints = new int[10];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i;
            }
            int[] ints1 = ints[0..1];       //0번부터 1번 전까지 복사
            int[] ints2 = ints[1..7];       //1번부터 7번 전까지 복사
        }
    }
}
```

## 5. 다차원 배열

단순 하나의 배열은 1차원 배열, 즉 선의 형태입니다.  
2차원 배열은 사각형의 형태입니다.  
마찬가지로 3차원 배열은 6면체의 형태를 가지고 있습니다.

```csharp
// 다차원 배열
int[,] ints3 = new int[2, 3];       //2차원
int[,,] ints4 = new int[2, 4, 5];   //3차원
```

용량[2,3]은 2행 3열, 즉 가로로 2줄 세로로 3줄을 말합니다.

## 6. 가변베열

`가변 배열`이란 길이가 변할 수 있는 배열을 말합니다.  
2차원 배열 선언자인 `[,]` 와는 조금 다르게 `[][]`로 선언합니다.

```csharp
// 가변 배열
int[][] jagged = new int[3][];
jagged[0] = new int[5] { 1, 2, 3, 4, 5 };
jagged[1] = new int[] { 1, 2, 3 };
jagged[2] = new int[] { 100, 200 };

int[][] jagged2 = new int[2][]
{
    new int[] { 1, 2 },
    new int[] { 100, 200,300 }
};
```

## 7. 컬렉션

`컬렉션`이란 같은 성격을 띄고 있는 데이터의 모음을 담는 자료구조를 말합니다. C# 에서 모든컬렉션들은 `ICollection인터페이스`를 상속하고 있습니다.

```csharp
public abstract class Array: ICloneable, IList, ICollection, IEnumerabe
```

이를 제외하고도 **`ArrayList`**, **`Queue`**, **`Stack`**, **`Hashtable`** 등의 자료구조에서 자주 등장하는 아이들이 Collection 그룹을 이루고 있습니다.

#### ArrayList

Array 인 배열과 가장 닮은 컬렉션으로, 배열과 달리 가변으로 길이가 조절되며 메서드를 통해 사용합니다.  
ArrayList는 Object 형식의 매개변수를 받고 있어 모든 형식의 데이터가 들어갑니다.

다만, 주의할 것은 정수를 넣으면 Object 형식으로 박싱과 언박싱을 진행하여, 성능이 낮음에 주의하셔야 합니다.

```csharp
using System.Collections;

namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList
            ArrayList lst = new ArrayList();
            lst.Add(1);     //1추가
            lst.Add(2);
            lst.Add(3);

            lst.RemoveAt(1);        //인덱스 1번값제거
            lst.Insert(1, 25);      //인덱스 1번에 25삽입
        }
    }
}
```

#### Queue

`Queue` 라는 대기열이라는 뜻을 가지고 있습니다. Queue 는 선입 선출의 개념을 가지고 있습니다.
먼저 들어가서 기다리는 사람이 먼저 밖으로 나간다를 의미합니다.  
넣어줌은 `Enqueue`, 빼줌은 `Dequeue`

```csharp
using System.Collections;

namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Queue
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue(); //1이 먼저 나옵니다.
        }
    }
}
```

#### Stack

`Stack`은 `Queue`와 다르게 선입 후출의 개념을 가지고 있습니다. 배에 자동차를 싣고, 다른 섬으로 가는데 내가 가장먼저 차를 싣고 도착하니, 꼴찌로 나와서 3시간 기다리는 경험은  
으악!!!! 생각만 해도 지칩니다.  
넣어줌은 `Push`, 빼줌은 `Pop` 을 이용합니다.

```csharp
using System.Collections;

namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stack
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();        //3이 꺼내짐
            stack.Pop();        //2가 꺼내짐
        }
    }
}
```

#### Hashtable

`Hashtable`은 키와 값이 한 쌍으로 이루어진 데이트를 다룰 때, 사용합니다.  
이게 진짜 웃긴게.... 각 프로그래밍 언어마다 명명을 다르게 하는 게 웃깁니다.  
파이썬 같은 경우는 딕셔너리, 자바 같은 경우는 해쉬맵 등등..... 똑같은거면서 다르게 불러서 후...

~~혹시 읽으시면서 제가 틀린 지식을 가지고 있으면 바로 댓글로 지적해주세요~~

원래는 매번 인덱스를 알고 인덱스로 접근해야 했는데, 이는 키값만 알면 빠르게 접근가능합니다.

```csharp
using System.Collections;

namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hashtable
            Hashtable hata = new Hashtable();
            hata["하나"] = "one";
            hata["둘"] = "two";
        }
    }
}
```

이처럼 사용하여, 키값을 통해서 다시 접근할 수 있습니다. 여기서 주의해야할 점은 쌍따옴표냐 따옴표냐에 따라 컴파일러가 읽지 못하니 잘 주의하셔야 합니다.
