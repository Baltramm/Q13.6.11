using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Q13._6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C://Users/Администратор/Downloads/Text1.txt";
            if (File.Exists(path))
            {
                static List<string> WriteToList(string path)
                {
                    var list = new List<string>();

                    foreach (string str in File.ReadLines(path))
                    {
                        list.Add(str);
                    }
                    return list;
                }

                static LinkedList<string> WriteToLinkedList(string path)
                {
                    var linkedList = new LinkedList<string>();

                    foreach (string str in File.ReadLines(path))
                    {
                        linkedList.AddLast(str);
                    }
                    return linkedList;
                }
                double sum1 = 0;
                double sum2 = 0;
                int runtime = 5;
                for (int i = 0; i <= runtime; i++)
                {
                    var Timer1 = Stopwatch.StartNew();
                    WriteToList(path);

                    sum1 += Timer1.Elapsed.TotalMilliseconds;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Запись в List: {Timer1.Elapsed.TotalMilliseconds}  мс");
                    Console.ResetColor();

                    var Timer2 = Stopwatch.StartNew();
                    WriteToLinkedList(path);

                    sum2 += Timer2.Elapsed.TotalMilliseconds;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Запись в LinkedList: {Timer2.Elapsed.TotalMilliseconds}  мс");
                    Console.ResetColor();

                    Console.WriteLine("  ");

                    Thread.Sleep(500);
                }
                double avg1 = sum1 / runtime;
                double avg2 = sum2 / runtime;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Среднее время записи в List: {avg1:f4}  мс");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Среднее время записи в LinkedList: {avg2:f4}  мс");
                Console.ResetColor();
            }
        }
    }
}
