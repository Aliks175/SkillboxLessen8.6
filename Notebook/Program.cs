using System;
using System.Xml.Linq;

namespace Notebook
{
    public class Program
    {
        static public void Main(string[] args)
        {
            string patch = "tut.xml";
            SerializeXml serialize = new SerializeXml(patch);
            CompleateEntry compleateEntry = new CompleateEntry();
            compleateEntry.Compleate(out Person person);
            serialize.Serialize(person);
            Console.Clear();
            Console.WriteLine("Serialize Compleate");
            Console.ReadLine();
        }

        class CompleateEntry
        {
            private string _inputText;
            private string _fullName;
            private string _street;
            private bool _isWork = true;
            private int _houseNumber;
            private int _flatNumber;
            private double _mobilePhone;
            private string _flatPhone;

            public void Compleate(out Person person)
            {
                while (_isWork)
                {
                    Console.Clear();
                    Console.WriteLine("Заполните следующию информацию\n");
                    Console.WriteLine("ФИО:\nУлица:\nНомер дома(  ):\nНомер квартиры(  ):\n" +
                        "Мобильный телефон(  ):\nДомашний телефон:\n");
                    _fullName = SeamlessConclusion(5, 2);
                    _street = SeamlessConclusion(7, 3);
                    _inputText = SeamlessConclusion(16, 4);
                    if (int.TryParse(_inputText, out int houseNumber))
                    {
                        this._houseNumber = houseNumber;
                        Console.SetCursorPosition(11, 4);
                        Console.Write("OK");
                    }
                    else
                    {
                        Console.SetCursorPosition(11, 4);
                        Console.Write("--");
                        PruntError();
                        continue;

                    }
                    _inputText = SeamlessConclusion(20, 5);
                    if (int.TryParse(_inputText, out int flatNumber))
                    {
                        this._flatNumber = flatNumber;
                        Console.SetCursorPosition(15, 5);
                        Console.Write("OK");
                    }
                    else
                    {
                        Console.SetCursorPosition(15, 5);
                        Console.Write("--");
                        PruntError();
                        continue;
                    }
                    _inputText = SeamlessConclusion(23, 6);
                    if (double.TryParse(_inputText, out double mobilePhone))
                    {
                        this._mobilePhone = mobilePhone;
                        Console.SetCursorPosition(18, 6);
                        Console.Write("OK");
                    }
                    else
                    {
                        Console.SetCursorPosition(18, 6);
                        Console.Write("--");
                        PruntError();
                        continue;
                    }
                    _flatPhone = SeamlessConclusion(18, 7);
                    _isWork = false;
                }
                Console.WriteLine();
                person = new Person(_fullName, _street, _houseNumber, _flatNumber, _mobilePhone, _flatPhone);
            }

            private void PruntError()
            {
                Console.WriteLine();
                Console.WriteLine(new string('-', 45));
                Console.WriteLine("Ошибка ввода, некоректное значение");
                Console.WriteLine(new string('-', 45));
                Console.ReadLine();
            }

            private string SeamlessConclusion(int left = 0, int top = 0)
            {
                Console.SetCursorPosition(left, top);
                return Console.ReadLine();
            }
        }

        class SerializeXml
        {
            private string _patch;

            public SerializeXml(string patch)
            {
                _patch = patch;
            }

            public void Serialize(Person person)
            {
                XElement personElement = new XElement("Person",
                    new XAttribute("Name", person.FullName),
                    new XElement("Address",
                                  new XElement("Street", person.Street),
                                  new XElement("HouseNumber", person.HouseNumber),
                                  new XElement("FlatNumber", person.FlatNumber)),
                    new XElement("Phones",
                                  new XElement("FlatPhone", person.FlatPhone),
                                  new XElement("MobilePhone", person.MobilePhone))
                    );
                personElement.Save(_patch);
            }
        }

        public struct Person
        {
            public string FullName { get; private set; }

            public string Street { get; private set; }

            public int HouseNumber { get; private set; }

            public int FlatNumber { get; private set; }

            public double MobilePhone { get; private set; }

            public string FlatPhone { get; private set; }

            public Person(string name, string street, int houseNumber, int flatNumber, double mobilePhone, string flatPhone)
            {
                FullName = name;
                Street = street;
                HouseNumber = houseNumber;
                FlatNumber = flatNumber;
                MobilePhone = mobilePhone;
                FlatPhone = flatPhone;
            }
        }
    }
}