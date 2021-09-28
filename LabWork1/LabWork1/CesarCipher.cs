using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    class CesarCipher : IAlgorithm
    {
        private const int ALPHABET_LEN = 32;
        private string defauktAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.,:;- ";

        private List<char> alphabet = new List<char>();

        public CesarCipher()
        {
            Init();
        }

        string IAlgorithm.alphabet { get => defauktAlphabet; }

        public string Encode(string message, string key)
        {
            message = message.ToUpper();

            string encodedMessage = string.Empty;
            int curr = 0;

            for(int i = 0; i < message.Length; i++)
            {
                curr = alphabet.IndexOf(key[i % key.Length]) + alphabet.IndexOf(message[i]);
                curr %= ALPHABET_LEN;
        
                encodedMessage += alphabet[curr];
            }

            File.Delete(FileManager.encodedMessage);
            File.Create(FileManager.encodedMessage).Close();
            FileManager.Write(FileManager.encodedMessage, encodedMessage);
            Console.WriteLine("[ENCODER]: Encoded! ");

            return encodedMessage;
        }
        public string Decode(string message, string key)
        {
            string decodedMessage = string.Empty;
            int curr = 0;
            int t1, t2;

            for (int i = 0; i < message.Length; i++)
            {
                t1 = alphabet.IndexOf(message[i]);
                t2 = alphabet.IndexOf(key[i % key.Length]);

                curr = t1 - t2;
                curr = (curr >= 0 && curr < ALPHABET_LEN) ? curr : ALPHABET_LEN + curr;

                decodedMessage += alphabet[curr];
            }

            File.Delete(FileManager.decodedMessage);
            File.Create(FileManager.decodedMessage).Close();
            FileManager.Write(FileManager.decodedMessage, decodedMessage);
            Console.WriteLine("[ENCODER]: Decoded!");

            return decodedMessage;
        }

        public void Init()
        {
            foreach(char c in defauktAlphabet)
                alphabet.Add(c);
        }
    }
}
