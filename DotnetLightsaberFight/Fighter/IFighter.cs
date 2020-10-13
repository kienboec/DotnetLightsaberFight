namespace DotnetLightsaberFight.Fighter
{
    public interface IFighter
    {
        string Name { get; }
        Lightsaber Lightsaber { get; }
        int Vitality { get; }
        void ChangeVitality(int change);
        bool IsDead();
        Aim NextAim();
    }
}
