using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabWork1
{
    public static class KeyGenerator
    {
        private const string keyPath = @"key.txt";
        private static int minKeyLength = 3,
                    maxKeyLength = 32;
        public static string GenerateKey(IAlgorithm algorithm)
        {
            string randomKey = string.Empty;
            Random randomizer = new Random();

            int keyLength = randomizer.Next(minKeyLength, maxKeyLength + 1);

            for (int i = 0; i < keyLength; i++)
                randomKey += algorithm.alphabet[randomizer.Next(0, algorithm.alphabet.Length - 1)];
            
            KreateKey(randomKey);
            return randomKey;
        }

        public static void KreateKey(string key)
        {
            if (File.Exists(FileManager.keyPath))
                File.Delete(FileManager.keyPath);
            File.Create(FileManager.keyPath).Close();
            FileManager.Write(FileManager.keyPath, key);
            Console.WriteLine("[KEY GENERATOR]: Key saved!"); 
        }
    }
}
