namespace DotnetLightsaberFight.Fighter
{
    public abstract class AbstractFighter : IFighter
    {
        public string Name { get; }
        public int Vitality { get; private set; }
        public Lightsaber Lightsaber { get; }
        
        private int _currentAimIndex;
        private readonly Aim[] _aims;

        protected AbstractFighter(string name, int vitality, Aim[] aims)
        {
            this.Name = name; // even if only getter, in ctor this operation is possible
            this.Vitality = vitality;
            this._aims = aims;
            this._currentAimIndex = 0;

            // determine Lightsaber with color by name
            switch (name)
            {
                case "Yoda":
                    Lightsaber = new Lightsaber(LightsaberColor.Blue);
                    break;
                case "DarthVader":
                    Lightsaber = new Lightsaber(LightsaberColor.Red);
                    break;
                case "Luke":
                    Lightsaber = new Lightsaber(LightsaberColor.Green);
                    break;
                default:
                    Lightsaber = new Lightsaber(LightsaberColor.Unknown);
                    break;
            }
        }

        public void ChangeVitality(int change)
        {
            Vitality += change;
        }
        public bool IsDead() => Vitality <= 0;
        
        public Aim NextAim()
        {
            return _aims[_currentAimIndex = (_currentAimIndex++) % _aims.Length];
        }
    }
}
