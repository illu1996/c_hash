using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

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
            public virtual void initalize()
            {
                Console.WriteLine($"mammal 시작");
            }
        }
        class Dog : Mammal
        {
            public void Bark()
            {
                Console.WriteLine($"{this.Name}: Bark()");
            }
            public override void initalize()
            {
                base.initalize();
                Console.WriteLine($"Dog 시작");
            }
        }
        class Caty : Mammal
        {
            public void Meow()
            {
                Console.WriteLine($"{this.Name}: Meow()");
            }
            public override void initalize()
            {
                base.initalize();
                Console.WriteLine($"Caty 시작");
            }
        }

        //structure
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

            Myclass mc = new Myclass();
            mc.MyField1 = 10;
            mc.MyField2 = 20;

            Myclass tg = mc;
            tg.MyField2 = 30;

            Console.WriteLine($"{mc.MyField1}, {mc.MyField2}");
            Console.WriteLine($"{tg.MyField1}, {tg.MyField2}");

            Myclass mc1 = new Myclass();
            mc1.MyField1 = 10;
            mc1.MyField2 = 20;

            Myclass tg1 = mc1.DeepCopy();
            tg1.MyField2 = 30;

            Console.WriteLine($"{mc1.MyField1}, {mc1.MyField2}");
            Console.WriteLine($"{tg1.MyField1}, {tg1.MyField2}");

            Emp pooh = new Emp();
            pooh.SetName("Pooh");
            string pooh_name = pooh.GetName();
            Console.WriteLine(pooh_name);       //Pooh

            //접근 한정자
            WaterHeater bithe = new WaterHeater();
            try
            {
                bithe.SetTemp(20);
                bithe.TurnOnWater();
                bithe.SetTemp(50);
                bithe.TurnOnWater();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //상속
            Mammal mammal1 = new Dog();
            Dog dog;
            if (mammal1 is Dog)
            {
                dog = (Dog)mammal1;
                dog.initalize();
                dog.SetName("멍멍이");
                dog.Bark();     //멍멍이: Bark()
            }

            Mammal mammal2 = new Caty();
            Caty caty = mammal2 as Caty;
            if (caty != null)
            {
                caty.initalize();
                caty.SetName("냥냥이");
                caty.Meow();        //냥냥이: Meow()
            }

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

            ACSetting acs;
            acs.cr = 25;
            acs.cr2 = 25;

            Console.WriteLine($"{acs.GetF()}");
            Console.WriteLine($"{acs.cr2}");

        }
        struct ACSetting
        {
            public double cr; public double cr2;

            public readonly double GetF()
            {
                return cr * 1.8 + 32;
            }
        }
    }
}