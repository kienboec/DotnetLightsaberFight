namespace DotnetLightsaberFight.Fighter
{
    public class Luke : AbstractFighter
    {
        public Luke() : base("Luke", 
            80, 
            new[] { Aim.Attack, Aim.Attack, Aim.Defense })
        {
        }
    }
}
