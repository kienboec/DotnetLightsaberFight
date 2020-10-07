using System;
using DotnetLightsaberFight.Fighter;

namespace DotnetLightsaberFight
{
    class Program
    {
        static void Main(string[] args)
        {
            Yoda yoda = new Yoda();
            DarthVader vader = new DarthVader();
            Luke luke = new Luke();

            Console.WriteLine("Yoda has a lightsaber with color: " + yoda.Lightsaber.Color);
            Console.WriteLine("DarthVader has a lightsaber with color: " + vader.Lightsaber.Color);
            Console.WriteLine("Luke has a lightsaber with color: " + luke.Lightsaber.Color);
        }
    }
}
