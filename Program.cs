// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Lists;
using static System.Net.Mime.MediaTypeNames;
class HelloWorld
{
    static void Main()
    {

        Console.WriteLine("Добро пожаловать,выберите команду");
        string temp = "";
        while (temp != "exit") {
            Console.WriteLine("\nintersection — Поиск совподающих элементов\nAddBack — Добавить в конец списка его отражение\nTRC — Работа с торговыми центрами\nnumbers — Поиск количества уникальных букв в файле\ncompetition — Работа с соревнованием\nexit — выход");
            temp = Console.ReadLine();
            if (temp == "intersection")
            {
                L Lis = new L();
                L Lis2 = new L();
                int t = 1;
                string step = "";
                try
                {
                    Console.WriteLine("Введите длинну первого списка");
                    t = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, здано стандартное значение.");
                }
                for (int i = 0; i < t; i++)
                {
                    Console.WriteLine("Введите следующее значение");
                    step = Console.ReadLine();
                    Lis.AddList(step);
                }
                try
                {
                    Console.WriteLine("Введите длинну второго списка");
                    t = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, здано стандартное значение.");
                }
                for (int i = 0; i < t; i++)
                {
                    Console.WriteLine("Введите следующее значение");
                    step = Console.ReadLine();
                    Lis2.AddList(step);
                }
                Console.Write("Совподающие элементы в списках: ");
                Console.WriteLine(Lis.intersection(Lis, Lis2).print());
            }
            else if (temp == "AddBack")
            {
                L Lis = new L();
                L Lis2 = new L();
                int t = 1;
                string step = "";
                try
                {
                    Console.WriteLine("Введите длинну первого списка");
                    t = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, здано стандартное значение.");
                }
                for (int i = 0; i < t; i++)
                {
                    Console.WriteLine("Введите следующее значение");
                    step = Console.ReadLine();
                    Lis.AddLinked(step);
                }
                try
                {
                    Console.WriteLine("Введите длинну второго списка");
                    t = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, здано стандартное значение.");
                }
                for (int i = 0; i < t; i++)
                {
                    Console.WriteLine("Введите следующее значение");
                    step = Console.ReadLine();
                    Lis2.AddLinked(step);
                }
                Lis.AddBack(Lis);
                Console.Write("Обединённый список: ");
                Console.WriteLine(Lis.print(2));
            }
            else if (temp == "TRC") {
                L Lis = new L();
                L Lis2 = new L();
                L Lis3 = new L();
                List<string> Trc = new List<string>();    
                int t = 1;
                int t2 = 1;
                string step = "";
                try
                {
                    Console.WriteLine("Введите количество торговых центров");
                    t = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, здано стандартное значение.");
                }
                for (int i = 0; i < t; i++)
                {
                    Console.WriteLine("Введите следующий торговый центр");
                    step = Console.ReadLine();
                    Trc.Add(step);
                }
                try
                {
                    Console.WriteLine("Введите количество студентов");
                    t = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, здано стандартное значение.");
                    t = 1;
                }
                for (int i = 0; i < t; i++)
                {
                    try
                    {
                        Console.WriteLine("Введите количество торговых центров, которые посетил студент");
                        t2 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка, здано стандартное значение.");
                        t2 = 1;
                    }
                    for (int j = 0; j < t2; j++)
                    {
                        Console.WriteLine("Введите следующее значение");
                        step = Console.ReadLine();
                        if (Trc.Contains(step))
                        {
                            Lis.AddHash(step, i);
                            Lis2.AddHash(step, i);
                            Lis3.AddHash(step, i);
                        }
                        else {
                            Console.WriteLine("Такого торгового центра нет!");
                        }
                    }
                }
                HashSet<string> all = Lis.allStudent();
                Console.Write("Все студенты посетили следующие ТЦ: ");
                Console.WriteLine(Lis.printHash(all));
                Console.Write("Некоторые студенты(Не все) посетили следующие ТЦ: ");
                Console.WriteLine(Lis2.printHash(Lis2.someStudent(all)));
                Console.Write("Никто из студентов не посетили следующие ТЦ: ");
                Console.WriteLine(Lis3.printList(Lis3.notStudent(Trc)));
            }
            else if (temp == "numbers")
            {
                L Lis = new L();
                Console.Write("Количество уникальных букв в файле: ");
                Console.WriteLine(Lis.numbers());
            }
            else if(temp == "competition")
            {
                L Lis = new L();
                Lis.writeFile(3, 4);
                Lis.readeFile();
            }
        }    
    }
}