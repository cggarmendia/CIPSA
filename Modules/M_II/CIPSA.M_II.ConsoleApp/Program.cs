using System;

namespace CIPSA.M_II.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Por favor, escriba su nombre: ");
            var name = Console.ReadLine();
            Console.WriteLine($"Hola {name}");
            Console.ReadLine();
        }
    }
}
