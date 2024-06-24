using System;
using System.IO;

namespace SteamKeys
{
    internal class Program
    {

        private static int InputQuantidade()
        {
            string title = @"

░██████╗████████╗███████╗░█████╗░███╗░░░███╗██╗░░██╗███████╗██╗░░░██╗░██████╗░░░░░░░░░░░░░░
██╔════╝╚══██╔══╝██╔════╝██╔══██╗████╗░████║██║░██╔╝██╔════╝╚██╗░██╔╝██╔════╝░░██╗░░░░██╗░░
╚█████╗░░░░██║░░░█████╗░░███████║██╔████╔██║█████═╝░█████╗░░░╚████╔╝░╚█████╗░██████╗██████╗
░╚═══██╗░░░██║░░░██╔══╝░░██╔══██║██║╚██╔╝██║██╔═██╗░██╔══╝░░░░╚██╔╝░░░╚═══██╗╚═██╔═╝╚═██╔═╝
██████╔╝░░░██║░░░███████╗██║░░██║██║░╚═╝░██║██║░╚██╗███████╗░░░██║░░░██████╔╝░░╚═╝░░░░╚═╝░░
╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚══════╝░░░╚═╝░░░╚═════╝░░░░░░░░░░░░░░░
                                    
                                    
";
            Console.WriteLine(title, Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine();
            Console.ResetColor();
            Console.Write("Insert how many keys you want to generate: ");
            int qtdKeys = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return qtdKeys;
        }
        private static void GeraSalvaKeys(Random random, string chars, int keyLength, int qtdKeys, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < qtdKeys; i++)
                {
                    char[] keyChars = new char[keyLength];

                    for (int j = 0; j < keyLength; j++)
                    {
                        keyChars[j] = chars[random.Next(chars.Length)];
                    }

                    string key = new string(keyChars);
                    string formattedKey = string.Format("{0}-{1}-{2}", key.Substring(0, 5), key.Substring(5, 5), key.Substring(10, 5));
                    Console.WriteLine(formattedKey, Console.ForegroundColor = ConsoleColor.Magenta);
                    writer.WriteLine(formattedKey);
                }
            }
        }
        private static void EscreverOutput(string fileName)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Keys saved to file: " + fileName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press ENTER to exit");
            Console.ResetColor();
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.Title = "SteamKeys++"; // Название окна потому что я тупой
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int keyLength = 15;
            string fileName = "keys.txt";  
            int qtdKeys = InputQuantidade();

            GeraSalvaKeys(random, chars, keyLength, qtdKeys, fileName);

            EscreverOutput(fileName);
        }

    }
}
