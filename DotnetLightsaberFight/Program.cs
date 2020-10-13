using System;
using DotnetLightsaberFight.Fighter;

namespace DotnetLightsaberFight
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
            Yoda yoda = new Yoda(); 
            DarthVader vader = new DarthVader();
            Luke luke = new Luke();

            Console.WriteLine("Yoda has a lightsaber with color: " + yoda.Lightsaber.Color);
            Console.WriteLine("DarthVader has a lightsaber with color: " + vader.Lightsaber.Color);
            Console.WriteLine("Luke has a lightsaber with color: " + luke.Lightsaber.Color);
            
             */

            IFighter winningFighter = CreateCombat(
                new Luke(),
                new DarthVader()).FightForLifeAndDeath();

            if (winningFighter==null)
            {
                return;
            }
            Console.WriteLine("--------");

            CreateCombat(
                new Yoda(), 
                winningFighter).LimitedFight(10);
        }

        private static Combat CreateCombat(IFighter f1, IFighter f2)
        {
            return new Combat(f1, f2);
        }
    }
}
