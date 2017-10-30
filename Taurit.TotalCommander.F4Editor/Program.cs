using System;

namespace Taurit.TotalCommander.F4Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(args.Length);
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
            Console.ReadKey();
        }
    }
}
