using System;
using System.IO;
using System.Runtime.InteropServices;

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
                    if (temperature == "")
                    {
                        break;
                    }
                    _logger.Log($"현재 온도 : {temperature}");
                }
                
            }
        }
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
        //추상 클래스
        abstract class Name     //추상 클래스
        {
            public abstract void SomeMethod();      //추상 메서드
        }
        class NewName : Name
        {
            public override void SomeMethod()       //필수
            {
                //...
            }
        }

        static void Main(string[] args)
        {
            ClimateMonitor monitor = new ClimateMonitor(new FileLogger("MyLog.txt"));
            monitor.start();

            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();

            ILogger logger = new ConsoleLogger();
            logger.Log("System up");
            logger.ErrorLog("System down");

            ConsoleLogger clogger = new ConsoleLogger();
            clogger.Log("System up");
            //clogger.ErrorLog("System down");  //컴파일 에러
        }
    }
}
