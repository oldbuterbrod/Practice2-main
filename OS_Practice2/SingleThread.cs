using System;
using System.IO;
using System.Text;

namespace OS_Practice2
{
    internal static class SingleThread
    {
        private static readonly char[] CharacterSet =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
            'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
            's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        internal static void BruteForceHash(string targetHash)
        {
            DateTime startTime = DateTime.Now;
            int characterSetLength = CharacterSet.Length;
            for (int char1 = 0; char1 < characterSetLength; char1++)
            {
                string a = Convert.ToString(CharacterSet[char1]);
                for (int char2 = 0; char2 < characterSetLength; char2++)
                {
                    string b = Convert.ToString(CharacterSet[char2]);
                    for (int char3 = 0; char3 < characterSetLength; char3++)
                    {
                        string c = Convert.ToString(CharacterSet[char3]);
                        for (int char4 = 0; char4 < characterSetLength; char4++)
                        {
                            string d = Convert.ToString(CharacterSet[char4]);
                            for (int char5 = 0; char5 < characterSetLength; char5++)
                            {
                                string e = Convert.ToString(CharacterSet[char5]);
                                string password = a + b + c + d + e;
                                string hashed = Hash.CalculateSha256Hash(password);
                                if (targetHash == hashed)
                                {
                                    Console.WriteLine($"Найден пароль {password}, hash {hashed}");
                                    Console.WriteLine(DateTime.Now - startTime);
                                    char1 = char2 = char3 = char4 = char5 = characterSetLength;
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static void BruteForceHashFromFile(string filePath)
        {
            DateTime startTime = DateTime.Now;
            int characterSetLength = CharacterSet.Length;
            int count = 0;
            for (int char1 = 0; char1 < characterSetLength; char1++)
            {
                string a = Convert.ToString(CharacterSet[char1]);
                for (int char2 = 0; char2 < characterSetLength; char2++)
                {
                    string b = Convert.ToString(CharacterSet[char2]);
                    for (int char3 = 0; char3 < characterSetLength; char3++)
                    {
                        string c = Convert.ToString(CharacterSet[char3]);
                        for (int char4 = 0; char4 < characterSetLength; char4++)
                        {
                            string d = Convert.ToString(CharacterSet[char4]);
                            for (int char5 = 0; char5 < characterSetLength; char5++)
                            {
                                string e = Convert.ToString(CharacterSet[char5]);
                                string password = a + b + c + d + e;
                                string hash = Hash.CalculateSha256Hash(password);
                                foreach (string line in File.ReadLines(filePath, Encoding.Default))
                                {
                                    if (!line.ToUpper().Contains(hash)) continue;

                                    Console.WriteLine($"Найден пароль {password}, hash {hash}");
                                    Console.WriteLine(DateTime.Now - startTime);
                                    count++;
                                    break;
                                }

                                if (count == File.ReadAllLines(filePath).Length)
                                {
                                    char1 = char2 = char3 = char4 = char5 = characterSetLength;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
