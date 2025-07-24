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

        class M_Class
        {
            public int a;
            public int b;

            public static int c;
            public static int d;
        }
        class Global
        {
            public static int count = 0;            //정적 필드
            public static void voice()
            {
                Console.WriteLine("노래하라!");     // 정적 메서드,
            }
        }

        class GA
        {
            public GA()
            {
                Global.count++;
            }
        }
        class GB
        {
            public GB()
            {
                Global.count++;
            }
        }
        static void Main(string[] args)
        {
            Cat kitty = new Cat("kitty", "화이트");              //객체 생성
            kitty.Name = "kitty";               //필드
            kitty.Meow();                       //메서드

            M_Class m = new M_Class();      //인스턴스(객체) 1
            m.a = 1;
            m.b = 2;

            M_Class n = new M_Class();      //인스턴스(객체) 2
            n.a = 1;
            n.b = 2;

            M_Class.c = 3;                  //static: 정적 필드
            M_Class.d = 4;

            Console.WriteLine($"count = {Global.count}");       //0

            GA a = new GA();
            GB b = new GB();
            GA c = new GA();
            GB d = new GB();

            Console.WriteLine($"count = {Global.count}");       //4
            Global.voice();     //노래하라!
        }

    }
}