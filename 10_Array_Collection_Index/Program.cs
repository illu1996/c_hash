using System;
using System.Collections;

namespace _10_Array_Collection_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //배열 선언
            int sumScore =0;
            int[] scores = new int[5]{ 10, 20, 30, 40, 50 };
            foreach (int i in scores)
            {
                sumScore += i;
            }
            Console.WriteLine(sumScore);        //150

            //배열 인덱스
            Console.WriteLine(scores[0]);       //10
            Console.WriteLine(scores[3]);       //40
            Console.WriteLine(scores[scores.Length - 1]);       //50
            System.Index last = ^1;             //^1 == Length-1 == score.Length-1, ^2 == Length-2
            Console.WriteLine(scores[last]);    //50

            //배열 초기화
            string[] array2 = new string[] { "안녕", "hello", "Halo" };       //3개의 길이
            string[] array3 = { "안녕", "hello", "Halo" };

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

            //슬라이싱
            int[] ints = new int[10];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i;
            }
            int[] ints1 = ints[0..1];       //0번부터 1번 전까지 복사
            int[] ints2 = ints[1..7];       //1번부터 7번 전까지 복사

            // 다차원 배열
            int[,] ints3 = new int[2, 3];       //2차원
            int[,,] ints4 = new int[2, 4, 5];   //3차원

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

            //ArrayList
            ArrayList lst = new ArrayList();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);

            lst.RemoveAt(1);
            lst.Insert(1, 25);

            //Queue
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue(); //1이 먼저 나옵니다.

            //Stack
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();        //3이 꺼내짐
            stack.Pop();        //2가 꺼내짐

            //Hashtable
            Hashtable hata = new Hashtable();
            hata["하나"] = "one";
            hata["둘"] = "two";
        }
    }
}
