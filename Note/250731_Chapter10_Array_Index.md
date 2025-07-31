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
