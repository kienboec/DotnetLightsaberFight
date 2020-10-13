using System;
using DotnetLightsaberFight.Fighter;

namespace DotnetLightsaberFight
{
    public class Combat
    {
        private readonly IFighter _opponentA;
        private readonly IFighter _opponentB;

        public Combat(IFighter opponentA, IFighter opponentB)
        {
            this._opponentA = opponentA;
            this._opponentB = opponentB;
        }

        public IFighter FightForLifeAndDeath()
        {
            return LimitedFightImplementation(false, 0);
        }

        public IFighter LimitedFight(int turns)
        {
            return LimitedFightImplementation(true, turns);
        }

        private IFighter LimitedFightImplementation(bool checkTurns, int turns)
        {
            if (checkTurns && turns < 1)
            {
                throw new ArgumentOutOfRangeException("Number of turns must be greater than 0!");
            }

            Console.WriteLine($"{_opponentA.Name} fights against {_opponentB.Name}");
            Console.WriteLine("Let the fight begin!");
            for (int turn = 1; ((!checkTurns) || turn <= turns) &&
                    (!_opponentA.IsDead()) &&
                    (!_opponentB.IsDead()); turn++)
            {

                Aim aimA = _opponentA.NextAim();
                Aim aimB = _opponentB.NextAim();
                Console.WriteLine($"{turn}. turn: {aimA} <---> {aimB}");

                GameMechanics(aimA, aimB);
            }
            IFighter optWinner = GetWinner();
            if (optWinner == null)
            {
                Console.WriteLine("There is no winner");
            }
            else
            {
                Console.WriteLine($"The winner is {optWinner.Name}");
            }

            return optWinner;
        }

        public void GameMechanics(Aim aimA, Aim aimB)
        {
            if (aimA == Aim.Attack && aimB == Aim.Attack)
            {
                _opponentA.ChangeVitality(-1);
                _opponentB.ChangeVitality(-1);
            }
            else if (aimA == Aim.Attack && aimB == Aim.Defense)
            {
                _opponentA.ChangeVitality(-2);
            }
            else if (aimA == Aim.Attack && aimB == Aim.Rest)
            { // REST
                _opponentB.ChangeVitality(-2);
            }
            else if (aimA == Aim.Defense && aimB == Aim.Attack)
            {
                _opponentB.ChangeVitality(-2);
            }
            else if (aimA == Aim.Defense && aimB == Aim.Defense)
            {
                _opponentA.ChangeVitality(-1);
                _opponentB.ChangeVitality(-1);
            }
            else if (aimA == Aim.Defense && aimB == Aim.Rest)
            {
                _opponentB.ChangeVitality(+1);
            }
            else if (aimA == Aim.Rest && aimB == Aim.Attack)
            {
                _opponentA.ChangeVitality(-2);
            }
            else if (aimA == Aim.Rest && aimB == Aim.Defense)
            {
                _opponentA.ChangeVitality(+1);
            }
            else if (aimA == Aim.Rest && aimB == Aim.Rest)
            {
                _opponentA.ChangeVitality(+1);
                _opponentB.ChangeVitality(+1);
            }
        }

        public IFighter GetWinner()
        {
            if (_opponentA.IsDead() && _opponentB.IsDead())
                return null;    // all are dead - no winner
            if (_opponentA.IsDead())
                return _opponentB;
            if (_opponentB.IsDead())
                return _opponentA;

            if (_opponentA.Vitality == _opponentB.Vitality)
                return null;    // both equal - still no winner

            return _opponentA.Vitality > _opponentB.Vitality
                ? _opponentA
                : _opponentB;
        }
    }
}
