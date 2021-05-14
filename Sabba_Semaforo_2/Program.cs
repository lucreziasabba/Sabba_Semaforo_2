using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sabba_Semaforo_2
{
    class Program
    {
        static int s = 0;
        public static SemaphoreSlim t = new SemaphoreSlim(0);
        static void Main(string[] args)
        {
            while (true)
            {
                Thread t1 = new Thread(() => Procedura1());
                Thread t2 = new Thread(() => Procedura2());
                t1.Start();
                t2.Start();
                while (t1.IsAlive) { }
                while (t2.IsAlive) { }
                Console.WriteLine(s);
            }

        }
        public static void Procedura1()
        {
            Console.WriteLine("Inserisci a:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci b:");
            int b = int.Parse(Console.ReadLine());
            s = a + b;
            Console.WriteLine($"{a}, {b}");
            t.Release();
        }

        public static void Procedura2()
        {
            Random n = new Random();
            int c = n.Next(10, 99);
            t.Wait();
            Console.WriteLine($"Random : {c}");
            s = s + c;
            Console.WriteLine($"Somma : {s}");
        }
    }
}
