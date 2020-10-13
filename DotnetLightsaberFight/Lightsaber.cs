namespace DotnetLightsaberFight
{
    public class Lightsaber
    {
        public LightsaberColor Color { get; private set; }

        public Lightsaber() : this(LightsaberColor.Unknown)
        {
        }

        public Lightsaber(LightsaberColor color)
        {
            this.Color = color;
        }
    }
}
