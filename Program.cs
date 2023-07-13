using System;
using Classes101;

namespace Classes101
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("james");
            Console.WriteLine("Commands : (A)ttack (E)xit (I)dle) (D)escriptions");

            Level level1 = new Level(p1);
            level1.CreateLevel(1, 2);

        }
    }
}
