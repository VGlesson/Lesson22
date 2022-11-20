using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Func<object, int[]> func1 = new Func<object, int[]>(GetMassive);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Func<Task<int[]>, int[]> func2 = new Func<Task<int[]>, int[]>(SumMassive);
            Task<int[]> task2 = task1.ContinueWith(action);

            Func<Task<int[]>, int[]> func3 = new Func<Task<int[]>, int[]>(MaxInMassive);
            Task<int[]> task3 = task2.ContinueWith(action);

            task1.Start();
            Console.ReadKey();
        }


        static int[] GetMassive(object a)
        {
            int n = (int)a;
            int[] massive = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                massive[i] = random.Next(0, 100);
            }
            return massive;
        }
        static int[] SumMassive(Task<int[]> task, int n)
        {
            int[] massive = task.Result;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += massive[i];
            }
            Console.WriteLine("sum=");
            return massive;
        }

        static int [] MaxInMassive(Task<int[]> task, int n)
        {
            int[] massive = task.Result;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                if (massive[i] > max)
                    max = massive[i];
            }
            Console.WriteLine("max=");
        }
        static void PrintMassive(Task<int[]> task)
        {
            int[] massive = task.Result;
            for (int i=0; i < massive.Count(); i++)
            {
                Console.Write($"{massive[i] }");
            }
        }
    }
}
