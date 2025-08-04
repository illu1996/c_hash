namespace _11_General
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //메서드
            //void Copy(int[] array, int[] target) { }
            //void Copy(string[] array, int[] target) { }

            int[] ints = { 1, 2, 3 };
            //일반화
            void Copy<T>(T[] array) { }

            Copy<int>(ints);

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

            //Queue
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("a");
            queue.Enqueue("b");

            string strings = queue.Dequeue();

            Console.WriteLine(strings);

            //Stack
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Pop();

            //Dictionary<Tkey,TValue>
            Dictionary<string, string> dicts = new Dictionary<string, string>();
            dicts["a"] = "b";
            dicts["b"] = "c";
            Console.WriteLine(dicts["a"]);
        }
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

        //형식 매개변수 제약
        class StructArray<T> where T : struct
        {
            public T[] Array { get; set; }
            public StructArray(int size) { }
        }
        class RefArray<T> where T : class
        {
            public T[] Array { get; set; }
            public RefArray(int size) { }
        }
    }
}
