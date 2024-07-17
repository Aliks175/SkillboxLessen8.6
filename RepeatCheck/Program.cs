using System;
using System.Collections.Generic;

namespace RepeatCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankOfNumbers bankOfNumbers = new BankOfNumbers();
            Console.Clear();
            bankOfNumbers.TrySetNumber();
            Console.ReadLine();
        }

        class BankOfNumbers
        {
            private HashSet<int> hashSet;

            public BankOfNumbers() { hashSet = new HashSet<int>(); }

            public void TrySetNumber()
            {
                string inputText;
                while (true)
                {
                    Console.Clear();
                    PrintExitText();
                    Console.WriteLine("Введите число");
                    Console.Write("Новое число : ");
                    inputText = Console.ReadLine();
                    if (int.TryParse(inputText, out int inputValue))
                        TryAddNumber(inputValue);
                    else
                    {
                        if (inputText == "")
                            break;
                        Console.WriteLine("Ошибка данные не корректны");
                        Console.ReadLine();
                    }
                }
            }

            private void TryAddNumber(int inputNumber)
            {
                if (hashSet.Contains(inputNumber))
                    Console.WriteLine($"Данное число ({inputNumber}) уже есть в колекции");
                else
                {
                    hashSet.Add(inputNumber);
                    Console.WriteLine($"Число : {inputNumber}\nУспешно добавлено");
                }
                Console.ReadLine();
            }

            private void PrintExitText(int left = 0, int top = 10)
            {
                Console.SetCursorPosition(left, top);
                Console.Write("Для выхода нажмите Enter");
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
