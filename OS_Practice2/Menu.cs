using System;
using System.IO;
using System.Text.RegularExpressions;

namespace OS_Practice2
{
    internal static class Menu
    {
        internal static void Display_Show()
        {
            bool flag = ModeChoiceShow();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберете режим работы:");
                Console.WriteLine("1. Однопоточный");
                Console.WriteLine("2. Многопоточный");
                Console.WriteLine("3. Вернуться");
                string choice = Console.ReadLine();

                Console.Clear();
                switch (choice)
                {
                    case "1":
                        if (flag)
                        {
                            string hash = HashEnter();
                            SingleThread.BruteForceHash(hash.ToUpper());
                        }
                        else
                        {
                            string path = HashesReadFromFile();
                            SingleThread.BruteForceHashFromFile(path);
                        }

                        break;
                    case "2":
                        if (flag)
                        {
                            string hash = HashEnter();
                            MultiThreading.BruteForceHash(hash.ToUpper());
                        }
                        else
                        {
                            string path = HashesReadFromFile();
                            MultiThreading.BruteForceHashFromFile(path);
                        }

                        break;
                    case "3":
                        Display_Show();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Неверное значение");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для повторного выбора");
                Console.ReadKey();
            }
        }

        private static bool ModeChoiceShow()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберете способ вывода хэшей");
                Console.WriteLine("1. Ввести хэш");
                Console.WriteLine("2. Считать хэши из файла");
                Console.WriteLine("3. Выход");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return true;
                    case "2":
                        return false;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Неверное значение");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для повторного выбора");
                Console.ReadKey();
            }
        }

        private static string HashEnter()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите хэш");
                string hash = Console.ReadLine();
                while (string.IsNullOrEmpty(hash) || hash.Trim() == string.Empty)
                {
                    Console.Clear();
                    Console.WriteLine("Введите хэш");
                    hash = Console.ReadLine();
                }

                if (Regex.IsMatch(hash, @"^[A-Za-z0-9]*$"))
                    return hash;
                Console.WriteLine("Ошибка! Хэш может содержать только цифры и буквы от A до F в любом регистре");
                Console.WriteLine("Нажмите любую клавишу для повторного ввода");
                Console.ReadKey();
                HashEnter();
            }
        }

        private static string HashesReadFromFile()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите путь файла с хэшами");
                string path = Console.ReadLine()?.Trim('"');
                while (string.IsNullOrEmpty(path) || path.Trim() == string.Empty)
                {
                    Console.Clear();
                    Console.WriteLine("Введите путь файла с хэшами");
                    path = Console.ReadLine()?.Trim('"');
                }

                if (File.Exists(path)) return path;

                Console.WriteLine("Ошибка! Такого пути не существует");
                Console.WriteLine("Нажмите любую клавишу для повторного ввода");
                Console.ReadKey();
                HashesReadFromFile();
            }
        }
    }
}