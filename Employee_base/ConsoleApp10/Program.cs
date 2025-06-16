using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAdd = "add";
            const string CommandDelite = "delite";
            const string CommandSearch = "search";
            const string CommandPrint = "print";
            const string CommandExit = "exit";

            List<string> name = new List<string>();
            List<string> surname = new List<string>();
            List<string> position = new List<string>();

            string UserCommand;
            bool isStart = true;

            while (isStart)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в базу данных сотрудников компании Сбербанк");
                Console.WriteLine($"Для добавление сотрудников введите {CommandAdd}");
                Console.WriteLine($"Для удаления сотрудников введите {CommandDelite}");
                Console.WriteLine($"Для поиска сотрудников введите {CommandSearch}");
                Console.WriteLine($"Для вывода сотрудников введите {CommandPrint}");
                Console.WriteLine($"Для выхода введите {CommandExit}");
                Console.Write("Ввод: ");
                UserCommand = Console.ReadLine();

                switch (UserCommand)
                {
                    case CommandAdd:
                        Add(name, surname, position);
                        break;
                    case CommandDelite:
                        Delite(name, surname, position);
                        break;
                    case CommandSearch:
                        Search(name, surname, position);
                        break;
                    case CommandPrint:
                        Print(name, surname, position);
                        break;
                    case CommandExit:
                        isStart = false;
                        break;
                    default:
                        Console.WriteLine("Я не знаю такой команды!");
                        break;
                }

                Console.WriteLine("Нажмите еще раз!");
                Console.ReadLine();
            }
        }

        static void Add(List<string> names, List<string> surnames, List<string> positions)
        {
            Console.WriteLine("Введите фамилию сотрудника");
            surnames.Add(Console.ReadLine());
            Console.WriteLine("Введите имя сотрудника");
            names.Add(Console.ReadLine());
            Console.WriteLine("Введите должность сотрудника");
            positions.Add(Console.ReadLine());
        }

        static void Print(List<string> names, List<string> surnames, List<string> positions)
        {
            for(int i = 0; i < names.Count; i++) 
                Console.WriteLine($"{i+1}Сотрудник - {surnames[i]} {names[i]} должность {positions[i]}");
        }

        static void Delite(List<string> names, List<string> surnames, List<string> positions)
        {
            Print(names, surnames, positions);
            Console.WriteLine("Введите индекс удаляемого сотрудника");
            int index = InputNumber();
            index--;

            if(index < names.Count)
            {
                names.RemoveAt(index);
                positions.RemoveAt(index);
                surnames.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Такого сотрудника нет");
            }
        }

        static int InputNumber()
        {
            int number = 0;
            bool isInputNumber = false;
            while(isInputNumber == false)
            {
                Console.WriteLine("Введите число: ");

                if (int.TryParse(Console.ReadLine(), out number))
                    isInputNumber = true;
            }

            return number;
        }

        static void Search(List<string> names, List<string> surnames, List<string> positions)
        {
            Console.WriteLine("Кого хотите найти");
            string text = Console.ReadLine();
            text = text.ToUpper();

            for (int i = 0;i < names.Count;i++) 
            {
                if (names[i].ToUpper() == text || 
                    surnames[i].ToUpper() == text ||
                    positions[i].ToUpper() == text)
                    Console.WriteLine($"{surnames[i]} {names[i]} {positions[i]}");
            }
        }
    }
}
