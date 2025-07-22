namespace _05_FlowControl
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //분기문
            int a = 10;
            if (( a %10) == 0)
            {
                Console.WriteLine("짝수");
            }
            else
            {
                Console.WriteLine("홀수");
            }

            //if 중첩
            
            int b = 10;
            if ((a % 10) > 0)
            {
                if (a % 2 == 0)
                {
                    Console.WriteLine("0보다 큰 짝수");
                }
                else
                {
                    Console.WriteLine("0보다 큰 홀수");
                }
            }
            else
            {
                Console.WriteLine("0보다 작거나 같은 수");
            }

            //switch 문
            int number = 1;

            switch (number)
            {
                case 1:
                    Console.WriteLine("하나");
                    break;
                case 2:
                    Console.WriteLine("둘");
                    break;
                case 3:
                    Console.WriteLine("셋");
                    break;
                case 4:
                    Console.WriteLine("넷");
                    break;
                default:
                    Console.WriteLine("포함 안돼 !");
                    break;
            }
            //switch 식
            int score = 30;
            string grade = (int)(Math.Truncate(score / 10.0) * 10) switch
            {
                90 => "A",
                80 => "B",
                70 => "C",
                60 => "D",
                50 => "E",
                _ => "F",
            };
            Console.WriteLine($"{grade}");


            // 반복문
            // while 
            int ten = 10;
            while (ten > 0)
            {
                Console.WriteLine(ten--);
            }

            //do while
            int dowhile = 10;
            do
            {
                Console.WriteLine(dowhile);
                dowhile--;
            }
            while (dowhile > 5);

            // for
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }

            // 중첩
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine(j);
                }
            }

            //foreach
            int[] arr = new int[5] { 0, 1, 2, 3, 4 };

            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }


            // 점프문

            int bk = 50;

            JUMP:
                Console.WriteLine("k");
            while (true)
            {
                if (bk > 105)
                {
                    break;
                }
                else if (bk < 100)
                {
                    bk++;
                    goto JUMP;
                }
                else if (bk == 100)
                {
                    bk++;
                    continue;
                }
            }
        }
    }
}
