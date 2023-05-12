using System;
using System.IO;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path to the file to encrypt: ");
            string filePath = Console.ReadLine();

            Console.Write("Enter the shift value: ");
            int shift = int.Parse(Console.ReadLine());

            string encryptedText = string.Empty;
            bool isSuccess = true;
            try
            {
                encryptedText = EncryptText(File.ReadAllText(filePath), shift);
                
            }
            catch
            {
                isSuccess = false;
                Console.WriteLine("Unable to process text. Make sure the file path is correct.");
            }

            if (isSuccess)
            {
                Console.Write("Encrypted text:");
                Console.WriteLine(encryptedText);

                Console.Write("Enter the path to save the encrypted text:");
                string encryptedFilePath = Console.ReadLine();
            
                try
                {
                    File.WriteAllText(encryptedFilePath, encryptedText);
                }
                catch
                {
                    Console.WriteLine("Unable to process text. Make sure the file path is correct.");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static string EncryptText(string text, int shift)
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
            int n = alphabet.Length;
            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                int index = alphabet.IndexOf(letter);

                if (index == -1)
                {
                    result[i] = letter;
                }
                else
                {
                    int encryptedIndex = (index + shift) % n;
                    result[i] = alphabet[encryptedIndex];
                }
            }

            return new string(result);
        }
    }
}