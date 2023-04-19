using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

// MultiThreading Programming

namespace ConsoleApp1 
{
    internal class Program
    {
        public static void TestMethod()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"test method  Thread 1:{threadId}");
        }
        public static void GiveMeNumber()
        {
            var rnd = new Random();
            int num = rnd.Next(10);
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"Random Number = {num} thread 2:{threadId}");
        }

        public static void PrintNumbers() 
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            
            for ( int i = 0; i < 10; i++ )
            {
                Console.WriteLine($"Number = {i}  thread 3 :{threadId}");
            }
        }

        public static async Task<int> GetWebPageLength(string url)
        {
            var content = await new HttpClient().GetStringAsync(url);
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"Content length = {content.Length} thread id:{threadId}");

            return content.Length;

        }
        public static void PrintNames(List<string> names )
        {
            int thredId = Thread.CurrentThread.ManagedThreadId;
            foreach ( string name in names )
            { 
                Console.WriteLine(name);
            }

        }
        static void Main(string[] args)
        {
            List<string> names = new List<string>() {"Kaan","Furkan"};

            Console.WriteLine("UI Thread id         : "+Thread.CurrentThread.ManagedThreadId);

            var url = "https://www.google.com.tr/?hl=tr";

            Thread thread1 = new Thread(TestMethod);
            Thread thread2 = new Thread(GiveMeNumber);
            Thread thread3 = new Thread(PrintNumbers);
            Thread thread4 = new Thread(() => PrintNames(names));


            thread3.Start();
            thread1.Start();
            thread2.Start();
            thread4.Start();

            var data = GetWebPageLength(url);
            Console.WriteLine(data);
        }
    }
}