using System;
using System.Collections.Generic;

namespace Sorting_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> randomList = CreateList(10);
            Console.WriteLine(string.Join(", ",randomList));
            List<int> sortedList = QuickSort(randomList,0,randomList.Count-1);
            Console.WriteLine(string.Join(", ", sortedList));
            Console.ReadLine();
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

            while(i <= j)
            {
                while(list[i] < pivot)
                {
                    i++;
                }

                while(list[j] > pivot)
                {
                    j--;
                }

                if(i <= j)
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
            Console.WriteLine("index: "+index1.ToString()+", "+ index2.ToString()+", "+list.Count.ToString());
            int firstElement = list[index1];
            int secondElement = list[index2];

            list.RemoveAt(index1);
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
            list.Add(rand.Next(0,100));
            list.Add(rand.Next(0,100));
            list.Add(rand.Next(0,100));
            list.Add(rand.Next(0,100));
            list.Add(rand.Next(0,100));
            list.Add(rand.Next(0,100));
            list.Add(rand.Next(0,100));
            list.Add(rand.Next(0,100));
            return list;
        }
    }
}
