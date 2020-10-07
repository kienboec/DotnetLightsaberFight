using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetLightsaberFight
{
    public class Lightsaber
    {
        public LightsaberColor Color { get; private set; }

        public Lightsaber(LightsaberColor color)
        {
            this.Color = color;
        }
    }
}
