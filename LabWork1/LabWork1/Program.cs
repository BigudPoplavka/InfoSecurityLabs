using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace LabWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            ChipherMachine chipherMachine = new ChipherMachine(new CesarCipher());

            chipherMachine.Init();
            chipherMachine.Encode();
            chipherMachine.Decode();

            Console.ReadKey();
        }
    }
}
