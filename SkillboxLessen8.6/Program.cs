using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkToList workToList = new WorkToList();
            workToList.ShowInfo("Всего чисел -");
            Console.WriteLine("\nНажмите Enter для сортировки");
            Console.ReadLine(); Console.Clear();
            workToList.FilterList(25, 50);
            workToList.ShowInfo("Всего чисел, после сортировки -");
            Console.ReadLine(); Console.Clear();
        }

        class WorkToList
        {
            private List<int> _numbersCompletionRundomlist = new List<int>();

            public WorkToList()
            {
                RundomCompletionList(_numbersCompletionRundomlist);
            }

            private void RundomCompletionList(List<int> list)
            {
                Random random = new Random();
                for (int i = 0; i < 100; i++)
                    list.Add(random.Next(0, 101));
            }

            public void ShowInfo(string text)
            {
                int counterNumbers = 1;
                Console.WriteLine($"{text} {_numbersCompletionRundomlist.Count}\n");
                foreach (int i in _numbersCompletionRundomlist)
                    Console.WriteLine($"Число # {counterNumbers++}  {i}");
            }

            public void FilterList(int numberIsLess, int numberIslarger)
            {
                var filter = from int number in _numbersCompletionRundomlist where number <= numberIsLess || number >= numberIslarger select number;
                _numbersCompletionRundomlist = filter.ToList();
            }
        }
    }
}
