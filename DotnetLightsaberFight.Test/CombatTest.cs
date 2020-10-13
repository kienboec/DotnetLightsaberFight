using DotnetLightsaberFight.Fighter;
using Moq;
using NUnit.Framework;

namespace DotnetLightsaberFight.Test
{
    // https://github.com/Moq/moq4/wiki/Quickstart
    public class CombatTest
    {
        [Test]
        public void TestMove_Attack2Attack()
        {
            // arrange
            var mockedA = new Mock<IFighter>();
            var mockedB = new Mock<IFighter>();
            
            // Once created, a mock will remember all interactions.
            // Then you can selectively verify whatever interactions you are interested in.
            var combat = new Mock<Combat>(mockedA.Object, mockedB.Object);

            // act
            combat.Object.GameMechanics(Aim.Attack, Aim.Attack);    // the game-mechs for one round is applied

            // assert
            mockedA.Verify(mock => mock.ChangeVitality(-1), Times.Exactly(1));
            mockedA.Verify(mock => mock.ChangeVitality(-1), Times.Exactly(1));
        }

        [Test]
        public void TestMove_Attack2Rest()
        {
            // arrange
            var mockedA = new Mock<IFighter>();
            var mockedB = new Mock<IFighter>();
            var combat = new Mock<Combat>(mockedA.Object, mockedB.Object);

            // act
            combat.Object.GameMechanics(Aim.Attack, Aim.Rest);

            // assert
            mockedA.Verify(mock => mock.ChangeVitality(0), Times.Exactly(0));
            mockedB.Verify(mock => mock.ChangeVitality(-2), Times.AtLeastOnce);
        }

        [Test]
        public void testGetWinner_one2one()
        {
            // arrange
            var mockedA = new Mock<IFighter>();
            var mockedB = new Mock<IFighter>();
            mockedA.Setup(mock => mock.Vitality).Returns(1);
            mockedB.Setup(mock => mock.Vitality).Returns(1);

            // act
            var combat = new Mock<Combat>(mockedA.Object, mockedB.Object);

            // assert
            Assert.IsNull(combat.Object.GetWinner(), "There should not be a winner!");
        }
    }
}
