namespace DotnetLightsaberFight.Fighter
{
    public class DarthVader : AbstractFighter
    {
        public DarthVader() : base("DarthVader",
            100,
            new[] { Aim.Attack, Aim.Attack, Aim.Attack, Aim.Rest })
        {
        }
    }
}
