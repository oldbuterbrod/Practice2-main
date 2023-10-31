using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OS_Practice2
{
    internal static class MultiThreading
    {
        internal static void BruteForceHash(string targetHash)
        {
            DateTime startTime = DateTime.Now;
            bool isFound = false;
            Parallel.For(0, 26, a =>
            {
                byte[] password = new byte[5];
                password[0] = (byte)(97 + a);
                for (password[1] = 97; password[1] < 123; password[1]++)
                {
                    for (password[2] = 97; password[2] < 123; password[2]++)
                    {
                        for (password[3] = 97; password[3] < 123; password[3]++)
                        {
                            for (password[4] = 97; password[4] < 123; password[4]++)
                            {
                                string passwordString = Encoding.ASCII.GetString(password);
                                string hashed = Hash.CalculateSha256Hash(passwordString);
                                if (targetHash != hashed) continue;

                                Console.WriteLine($"Пароль найден: {passwordString}, хэш: {hashed}");
                                Console.WriteLine(DateTime.Now - startTime);
                                isFound = true;
                                break;
                            }

                            if (isFound) break;
                        }

                        if (isFound) break;
                    }

                    if (isFound) break;
                }
            });
        }

        internal static void BruteForceHashFromFile(string filePath)
        {
            bool isFound = false;
            DateTime startTime = DateTime.Now;
            Parallel.For(0, 26, a =>
            {
                byte[] password = new byte[5];
                int count = 0;
                password[0] = (byte)(97 + a);
                for (password[1] = 97; password[1] < 123; password[1]++)
                {
                    for (password[2] = 97; password[2] < 123; password[2]++)
                    {
                        for (password[3] = 97; password[3] < 123; password[3]++)
                        {
                            for (password[4] = 97; password[4] < 123; password[4]++)
                            {
                                string passwordString = Encoding.ASCII.GetString(password);
                                string hash = Hash.CalculateSha256Hash(passwordString);
                                foreach (string line in File.ReadLines(filePath, Encoding.Default))
                                {
                                    if (!line.ToUpper().Contains(hash)) continue;

                                    Console.WriteLine($"Пароль найден: {passwordString}, хэш: {hash}");
                                    Console.WriteLine(DateTime.Now - startTime);
                                    count++;
                                    if (count == File.ReadAllLines(filePath).Length) isFound = true;
                                    break;
                                }

                                if (isFound) break;
                            }

                            if (isFound) break;
                        }

                        if (isFound) break;
                    }

                    if (isFound) break;
                }
            });
        }
    }
}
