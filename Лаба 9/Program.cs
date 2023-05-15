using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_9
{
    public class ListNode<T>
    {
        public T data;
        public ListNode<T> next;
    }

    public class CircularLinkedList<T> : ListNode<T>
    {
        ListNode<T> head = null;
        ListNode<T> tail = null;

        public ListNode<T> First()
        {
            return head;
        }

        public void Append(T elem)
        {
            ListNode<T> node = new ListNode<T>();
            node.data = elem;
            node.next = null;

            if (head == null)
            {
                head = node;
                head.next = node;
            }
            else
            {
                tail.next = node;
            }
            tail = node;
            tail.next = head;
        }

        public ListNode<T> Find(T elem)
        {
            ListNode<T> node = head;
            while (!node.data.Equals(elem))
            {
                node = node.next;
            }
            return node;
        }
    }
    internal class Program
    {
        public static string Select(CircularLinkedList<string> names, int countingLength, string person)
        {
            var name = names.Find(person);
            for (int i = 0; i < countingLength; i++)
                name = name.next;

            return name.data;
        }

        static void Main(string[] args)
        {
            string Main = "Задание 1\nЗадание 2\nЗадание 3\nЗадание 4\nЗадание 5\nЗадание 6\nИндивидуальное задание + 7";
            Console.WriteLine(Main);
            bool Error = true;
            int i = Int32.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    {
                        Console.WriteLine("Упс, похоже тут ничего нет:(");
                        Error = false;
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Введите выражение: ");
                        string expression = Convert.ToString(Console.ReadLine());

                        Stack<char> stack = new Stack<char>();
                        foreach (char c in expression)
                        {
                            if (c == '(')
                            {
                                stack.Push(c);
                            }
                            else if (c == ')')
                            {
                                if (stack.Count > 0)
                                {
                                    stack.Pop();
                                }
                                else
                                {
                                    Console.WriteLine("Выражение некорректно");
                                    Console.ReadLine();
                                    return;
                                }
                            }
                        }

                        if (stack.Count == 0)
                        {
                            Console.WriteLine("Выражение корректно");
                            Console.ReadLine();
                        }  
                        else
                        {
                            Console.WriteLine("Выражение некорректно");
                            Console.ReadLine();
                        }
                        Error = false;
                        Console.ReadLine();

                    }
                    break;
                case 3:
                    {
                        CircularLinkedList<string> names = new CircularLinkedList<string>();
                        string[] namesArray = new string[] { "Маргарита", "Витя", "Рома", "Костя", "Мира", "Артур" };


                        Console.Write("Игроки: ");
                        foreach (string n in namesArray)
                        {
                            Console.Write(n + " ");
                            names.Append(n);
                        }
                        Console.WriteLine("\n");


                        Console.Write("Введите считалочку: ");
                        int length = Console.ReadLine().Split(new char[] { ' ' }).Length - 1;
                        Console.WriteLine();


                        bool correct = false;
                        string name = String.Empty;
                        Console.Write("Введите имя с которого начать счет: ");
                        while (!correct)
                        {
                            name = Console.ReadLine();
                            foreach (string n in namesArray)
                                if (n == name) correct = true;

                            if (!correct) Console.Write("Такого игрока нет, введите другое имя: ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Считалочка закончилась на игроке", Select(names, length, name));
                        Console.ReadLine();

                        Error = false;

                    } break;
                case 4:
                    {
                        int N = 50000;
                        int limit = (int)(Math.Pow(N, 0.33));

                        var Cibe = new Dictionary<int, int>();
                        for (int j = 0; j <= 50000; j++)
                            Cibe.Add(j, 0);


                        for (int x = 0; x <= limit; x++)
                        {
                            for (int y = 0; y <= limit; y++)
                            {
                                for (int z = 0; z <= limit; z++)
                                {
                                    int sum = (int)(Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3));

                                    if (sum <= N)
                                        Cibe[sum]++;
                                }
                            }
                        }

                        foreach (var key in Cibe.Keys)
                            if (Cibe[key] >= 3)
                                Console.WriteLine(key);
                        Console.ReadLine();

                        Error = false;
                    } break;
                case 5:
                    {
                        try
                        {
                            string text = string.Empty;
                            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\file.txt"))
                                while (sr.Peek() != -1)
                                    text = text + sr.ReadLine();

                            var Words_and_Counter = new Dictionary<string, int>();
                            if (text != null)
                            {
                                int value = 0;
                                var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                words = words.OrderBy(s => s).ToArray();
                                words = words.Reverse().ToArray();
                                foreach (var word in words)
                                {
                                    if (Words_and_Counter.TryGetValue(word, out value))
                                    {
                                        Words_and_Counter[word]++;
                                    }
                                    else
                                    {
                                        Words_and_Counter.Add(word, 1);
                                    }
                                }
                                Words_and_Counter = Words_and_Counter.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                                Words_and_Counter = Words_and_Counter.Reverse().ToDictionary(pair => pair.Key, pair => pair.Value);
                                int cnt = 0;
                                foreach (var word in Words_and_Counter)
                                {
                                    if (cnt < 10)
                                    {
                                        Console.WriteLine(word.Key + " - " + word.Value);
                                    }
                                    cnt++;
                                }
                                Console.ReadLine();

                                Error = false;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Файл со словами " + Directory.GetCurrentDirectory() + "\\file.txt\" отсутствует");
                            Console.ReadLine();
                            Error = false;
                        }
                    } break;
                case 6:
                    {
                        Console.WriteLine("Упс, похоже тут ничего нет:(");
                        Console.ReadLine();
                        Error = false;
                    } break;
                case 7:
                    {
                        Console.WriteLine("Упс, похоже тут ничего нет:(");
                        Console.ReadLine();
                        Error = false;
                    } break;
                default:
                    {
                        Error = true;
                        Console.WriteLine("Введите верное число");
                        Console.ReadLine();
                    }
                    break;
                    

            }
        }
    }
}
