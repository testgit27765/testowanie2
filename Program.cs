using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApka1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab1 = new int[] { 1, 2, 8, -5, 4, 7 };
            MergeSorter.DoMergeSort(tab1);
            for (int i = 0; i < tab1.Length; i++)
            {
                Console.WriteLine(tab1[i]);
            }
            
        }
    }

    static class MergeSorter
    {
        public static void DoMergeSort(this int[] tab1)
        {
            var sortedNumbers = MergeSort(tab1);

            for (int i = 0; i < sortedNumbers.Length; i++)
            {
                tab1[i] = sortedNumbers[i];
            }
        }
        public static int[] MergeSort(int[] tab1)
        {
            if (tab1.Length <= 1)
            {
                return tab1;
            }

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < tab1.Length; i++)
            {

                if (i % 2 > 0)
                {
                    left.Add(tab1[i]);
                }
                else
                {
                    right.Add(tab1[i]);
                }

            }

            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();

            return Merge(left, right);

        }
        public static int[] Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First())
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right.First());
                    right.RemoveAt(0);
                }
            }
                while(left.Count > 0)
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }

                while (right.Count > 0)
                {
                    result.Add(right.First());
                    right.RemoveAt(0);
                }

                return result.ToArray();
        }
    }
}

