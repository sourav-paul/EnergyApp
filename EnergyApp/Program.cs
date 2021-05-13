using EnergyApp.Misc;
using System;

namespace EnergyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var data = new XmlParser();

            data.ReadInput();
        }
    }
}
