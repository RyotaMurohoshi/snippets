using System;
using System.Collections.Generic;

namespace ILExample
{
    class ForAndForeachExample
    {
        public static void Main(string[] args)
        {
            ShowArrayWithFor(new[] { 0, 1, 2, 3 });
            ShowArrayWithForeach(new[] { 0, 1, 2, 3 });
            ShowListWithFor(new List<int> { 0, 1, 2, 3 });
            ShowListWithForeach(new List<int> { 0, 1, 2, 3 });
        }

        public static void ShowArrayWithFor<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void ShowArrayWithForeach<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static void ShowListWithFor<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        public static void ShowListWithForeach<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
