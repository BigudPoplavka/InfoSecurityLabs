using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    public static class FileManager
    {
        public const string messagePath = @"message.txt";
        public const string keyPath = @"key.txt";
        public const string encodedMessage = @"top_secret.txt";
        public const string decodedMessage = @"decoded.txt";

        public static string Read(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"[FILE MANAGER]: ERROR! Message file with name \"{path}\" not found!");

            using (StreamReader reader = new StreamReader(path))
            {
                string data = reader.ReadToEnd();
                return data;
            }
        }

        public static void Write(string path, string data)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"[FILE MANAGER]: ERROR! Message file with name \"{path}\" not found!");
            
            using(StreamWriter writer = new StreamWriter(path))
            {
                 writer.Write(data);
                 Console.WriteLine("[FILE MANAGER]: Data saved!");
            }
        }
    }
}
