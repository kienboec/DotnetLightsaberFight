namespace DotnetLightsaberFight.Fighter
{
    public class Yoda : AbstractFighter
    {
        public Yoda() : base("Yoda",
            120,
            new[] { Aim.Defense, Aim.Attack })
        {
        }
    }
}
