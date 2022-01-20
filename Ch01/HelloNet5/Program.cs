using System;

namespace HelloNet5
{
    internal class Program
    {
        static void Main ()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine ("Hello, Net 5.0!");

            Console.ResetColor ();
        }
    }
}
