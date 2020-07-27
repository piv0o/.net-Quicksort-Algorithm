using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sorting_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();
        }


        private static List<int> QuickSort(List<int> list, int low, int high)
        {
            if(list.Count > 1)
            {
                //---------------------------
                // partition the array
                //---------------------------
                int index = Partition(list, low, high);
                //---------------------------
                // recursive branch the next elements in the array
                //---------------------------
                if(low < index - 1)
                {
                    QuickSort(list, low, index - 1);
                }
                if(index < high)
                {
                    QuickSort(list, index, high);
                }
            }
            return list;
        }

        private static int Partition(List<int> list, int low, int high)
        {
            int pivot = list[GetPivotIndex((low + high) / 2)];
            int i = low;
            int j = high;
            while (i <= j)
            {
                while(list[i] < pivot)
                {
                    i++;
                }

                while(list[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    list = Swap(list, i, j);
                    i++;
                    j--;
                }
            }
            return i; 
        }

        private static List<int> Swap(List<int> list, int index1, int index2)
        {
            if(index1 == index2)
            {
                return list;
            }
            int firstElement = list[index1];
            list.RemoveAt(index1);

            int secondElement = list[index2-1];
            list.RemoveAt(index2-1);

            list.Insert(index1, secondElement);
            list.Insert(index2, firstElement);

            return list;
        }

        private static int GetPivotIndex(double v)
        {
            return Convert.ToInt32(Math.Floor(v));
        }

        private static List<int> CreateList(int v)
        {
            List<int> list = new List<int>();
            var rand = new Random();

            for(int i = 0; i < v; i++)
            {
                list.Add(rand.Next(0, 100));
            }
           
            return list;
        }

        private static void Initialize()
        {
            var stopwatch = new Stopwatch();
            Console.WriteLine("Please Input the ammount of entries into the list you wish to sort.");
            int input = Convert.ToInt32(Console.ReadLine());

            List<int> randomList = CreateList(input);
            Console.WriteLine("{ " + string.Join(", ", randomList) + " }");
            stopwatch.Start();
            List<int> sortedList = QuickSort(randomList, 0, randomList.Count - 1);
            stopwatch.Stop();
            Console.WriteLine("{ " + string.Join(", ", sortedList) + " }");
            Console.WriteLine("Function performed sort in " + stopwatch.ElapsedMilliseconds.ToString() + "ms");
            Console.WriteLine("Please press enter to exit the program...");
            Console.ReadLine();
        }
    }
}
