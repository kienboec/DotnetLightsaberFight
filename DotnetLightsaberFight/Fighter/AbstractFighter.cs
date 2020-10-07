using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetLightsaberFight.Fighter
{
    public abstract class AbstractFighter : IFighter
    {
        public Lightsaber Lightsaber { get; private set; }

        public AbstractFighter(String name)
        {
            // determine Lightsaber with color by name

            if (name == "Yoda")
            {
                Lightsaber = new Lightsaber(LightsaberColor.Blue);
            }
            else if (name == "DarthVader")
            {
                Lightsaber = new Lightsaber(LightsaberColor.Red);
            }
            else if (name == "Luke")
            {
                Lightsaber = new Lightsaber(LightsaberColor.Green);
            }
            else
            {
                Lightsaber = new Lightsaber(LightsaberColor.Unknown);
            }
        }
    }
}
