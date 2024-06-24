 namespace SteamKeys
 {
    internal class Program
    {
        private static Random random = new Random();
        private static void Main(string[] args)
        {
            Console.Title = "SteamKeys++";
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int keyLength = 15; // Фиксированная длина ключа
            string fileName = "keys.txt"; // Путь текстовому файлу с ключами

            KeyGenerator(chars, keyLength, InputQuantidade(), fileName);

            EscreverOutput(fileName);
        }
        private static int InputQuantidade() // Изменяет интерфейс консоли и считывает количество ключей, которые вы хотите получить
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
            Console.Write("Insert how many keys you want to generate: ", Console.ForegroundColor = ConsoleColor.White);
            int numberOfKeys = Convert.ToInt32(Console.ReadLine()); // Считывание числа 
            Console.WriteLine();
            return numberOfKeys;
        }
        private static void KeyGenerator(string chars, int keyLength, int numberOfKeys, string fileName) // Генерирует ключи
        {
            StreamWriter writer = new StreamWriter(fileName, false); // Объект класса StreamWriter. Реализует запись ключей в текстовый файл
            for (int i = 0; i < numberOfKeys; i++)
            {
                char[] charsOfKey = new char[keyLength]; // Массив сгенерированных символов
                for (int j = 0; j < keyLength; j++)
                {
                    charsOfKey[j] = chars[random.Next(chars.Length)];
                }

                string key = new string(charsOfKey);
                string formattedKey = $"{key.Substring(0, 5)}-{key.Substring(5, 5)}-{key.Substring(10, 5)}"; // Ключ в нормальном виде
                Console.WriteLine(formattedKey, Console.ForegroundColor = ConsoleColor.Magenta);
                writer.WriteLine(formattedKey);
            }
            writer.Close();
        }
        private static void EscreverOutput(string fileName) // Изменяет интерфейс консоли и отображает в какой файл сохранились ключи
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Keys saved to file: " + fileName); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press ENTER to exit");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
