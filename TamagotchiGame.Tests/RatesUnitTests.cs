using Shouldly;
using System;
using Xunit;

namespace TamagotchiGame.Tests
{
    public class RatesUnitTests
    {
        [Theory]
        [InlineData(LifeStage.Baby, 10)]
        [InlineData(LifeStage.Child, 8)]
        [InlineData(LifeStage.Teen, 5)]
        [InlineData(LifeStage.Adult, 3)]
        public void FoodNeedRatesBaseOnLifeStageTest(LifeStage lifeStage, int rate)
        {
            // Arrange
            var dragon = new Tamagotchi("Dragon");
            dragon.LifeStage = lifeStage;
            var hungrinessBefore = dragon.Hungriness;

            var need = new FoodNeed();

            // Act
            need.Satisfy(dragon);
            var hungrinessAfter = dragon.Hungriness;

            // Assert
            Math.Abs(hungrinessAfter - hungrinessBefore).ShouldBe(rate);
        }

        [Theory]
        [InlineData(LifeStage.Baby, 20)]
        [InlineData(LifeStage.Child, 15)]
        [InlineData(LifeStage.Teen, 10)]
        [InlineData(LifeStage.Adult, 20)]
        public void PettingNeedRatesBaseOnLifeStageTest(LifeStage lifeStage, int rate)
        {
            // Arrange
            var dragon = new Tamagotchi("Dragon");
            dragon.LifeStage = lifeStage;
            var happinessBefore = dragon.Happiness;

            var need = new PettingNeed();

            // Act
            need.Satisfy(dragon);
            var happinessAfter = dragon.Happiness;

            // Assert
            Math.Abs(happinessAfter - happinessBefore).ShouldBe(rate);
        }
    }
}
