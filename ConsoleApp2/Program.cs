using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding=Encoding.UTF8;
            Thread thread1 = new Thread(() => RoadThread.Method("виконуется 1 потік", 1));
            Thread thread2 = new Thread(() => RoadThread.Method("виконуется 2 потік ", 2));
            Thread thread3 = new Thread(()=> RoadThread.Method("виконуется 3 потік ",3));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();

            thread2.Join();
            thread3.Join();

            if (!thread1.IsAlive && !thread2.IsAlive && !thread3.IsAlive)
            {
                Console.WriteLine("Усі потоки завершили виконання.");
            }
            else
            {
                Console.WriteLine("Деякі потоки ще виконуються.");
            }
        }
    }
}
