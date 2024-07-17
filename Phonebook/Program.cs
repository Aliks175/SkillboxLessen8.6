using System;
using System.Collections.Generic;

namespace Phonebook
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new Phone();
            bool isWork = true;
            string inputText;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Здравствуйте вам доступны следующие действия : \n\n" +
                    "1)Добавить новый контакт\n2)Найти контакт по номеру\n3)Вывести все номера");
                inputText = Console.ReadLine();
                if (int.TryParse(inputText, out int inputValue))
                {
                    if (inputValue > 3 || inputValue < 1)
                    {
                        Console.WriteLine($"Ошибка ввода |{inputText}| такой команды нет");
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"Ошибка ввода такой команды нет");
                    Console.ReadLine();
                    continue;
                }
                if (inputValue == 1)
                {
                    phone.TryAddNewContact();
                }
                else if (inputValue == 2)
                {
                    phone.FiendContact();
                }
                else if (inputValue == 3)
                {
                    Console.Clear();
                    phone.ShowInfo();
                }
                Console.ReadLine();
            }
        }

        class Phone
        {
            private Dictionary<int, string> _phoneBooks = new Dictionary<int, string>();

            public void TryAddNewContact()
            {
                string fullName;
                string tempInputText;
                while (true)
                {
                    Console.Clear();
                    PrintExitText();
                    Console.WriteLine("Введите номер телефона\n\n\nПример : 88005553535");
                    Console.Write("Новый номер : ");
                    tempInputText = Console.ReadLine();
                    if (int.TryParse(tempInputText, out int number)) { }
                    else
                    {
                        if (tempInputText == "")
                        {
                            break;
                        }
                        Console.WriteLine($"Ошибка ввода -{tempInputText}- Введите корректный номер");
                        Console.ReadLine();
                        continue;
                    }
                    Console.WriteLine("Введите имя\nПример : Иванов Иван Иваныч");
                    Console.Write("Новое имя : ");
                    fullName = Console.ReadLine();
                    AddContact(number, fullName);
                    Console.ReadLine();
                }
            }

            private void PrintExitText(int left = 0, int top = 10)
            {
                Console.SetCursorPosition(left, top);
                Console.Write("Для выхода нажмите Enter");
                Console.SetCursorPosition(0, 0);
            }

            public void ShowInfo()
            {
                if (_phoneBooks.Count == 0)
                    Console.WriteLine("Контактов нет");
                else
                {
                    foreach (var contact in _phoneBooks)
                    {
                        Console.WriteLine($"Имя : {contact.Value}\nТелефон : {contact.Key}");
                        Console.WriteLine("\n");
                    }
                }
            }

            private void AddContact(int number, string fullName)
            {
                Console.Clear();
                if (_phoneBooks.ContainsKey(number))
                {
                    Console.WriteLine("Данный номер уже зарегистрирован");
                    Console.WriteLine(new string('-', 48));
                    Console.WriteLine($"Имя : {_phoneBooks[number]}\nТелефон : {number}");
                    Console.WriteLine(new string('-', 48));
                }
                else
                {
                    _phoneBooks.Add(number, fullName);
                    Console.WriteLine("Регистрация прошла успешно");
                    Console.WriteLine(new string('-', 48));
                    Console.WriteLine($"Имя : {_phoneBooks[number]}\nТелефон : {number}");
                    Console.WriteLine(new string('-', 48));
                }
            }

            public void FiendContact()
            {
                string tempInputText;
                while (true)
                {
                    Console.Clear();
                    PrintExitText();
                    Console.WriteLine("Какой контакт вы ищете? Введите номер телефона...\n\n\nПример : 88005553535");
                    Console.Write("Искомый номер : ");
                    tempInputText = Console.ReadLine();
                    if (int.TryParse(tempInputText, out int number)) { }
                    else
                    {
                        if (tempInputText == "")
                        {
                            break;
                        }
                        Console.WriteLine($"Ошибка ввода -{tempInputText}- Введите корректный номер");
                        Console.ReadLine();
                        continue;
                    }
                    if (_phoneBooks.TryGetValue(number, out string name))
                    {
                        Console.WriteLine($"Номер найден\n");
                        Console.WriteLine(new string('-', 48));
                        Console.WriteLine($"Имя : {name}\nТелефон : {number}");
                        Console.WriteLine(new string('-', 48));
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка ввода -{tempInputText}- Данный номер не зарегистрирован");
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
