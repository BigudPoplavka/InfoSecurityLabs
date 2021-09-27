using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    public class ChipherMachine
    {
        public IAlgorithm algorithm;
        private string _message, _key, _encoded;

        public ChipherMachine(IAlgorithm _algorithm)
        {
            algorithm = _algorithm;
        }

        public void Init()
        {
            _message = FileManager.Read(FileManager.messagePath);
            Console.WriteLine(_message);
            EnterKeyMenu();
        }

        public string Encode()
        {
            _encoded = algorithm.Encode(_message, _key);
            return _encoded;
        }

        public string Decode()
        {

            return algorithm.Decode(_encoded, _key);
        }

        public void EnterKeyMenu()
        {
            Console.WriteLine("Enter key or generate? [ e / g ] ");
            string answer = Console.ReadLine();

            if(answer == "e" || answer == "E")
            {
                Console.WriteLine("Enter key: ");
                _key = Console.ReadLine();
                FileManager.Write(FileManager.keyPath, _key);
            }
            else if(answer == "g" || answer == "G")
            {
                _key = KeyGenerator.GenerateKey(algorithm);
                Console.WriteLine("Key: ", _key);
            }
            else
            {
                Console.WriteLine("INCORRECT OPTION!");
                return;
            }
        }
    }
}
