using DotnetLightsaberFight.Fighter;

namespace DotnetLightsaberFight.Test.Fighter
{
    public class UnknownFighter : AbstractFighter
    {
        public UnknownFighter() : base("unknown bladiblub-string", 1, new[] { Aim.Attack })
        {
        }
    }
}
