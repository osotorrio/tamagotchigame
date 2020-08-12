using Shouldly;
using Xunit;

namespace TamagotchiGame.Tests
{
    public class LifeStageUnitTests
    {
        [Theory]
        [InlineData(0, LifeStage.Baby)]
        [InlineData(1, LifeStage.Child)]
        [InlineData(2, LifeStage.Child)]
        [InlineData(3, LifeStage.Child)]
        [InlineData(4, LifeStage.Child)]
        [InlineData(5, LifeStage.Child)]
        [InlineData(6, LifeStage.Child)]
        [InlineData(7, LifeStage.Child)]
        [InlineData(8, LifeStage.Child)]
        [InlineData(9, LifeStage.Child)]
        [InlineData(10, LifeStage.Child)]
        [InlineData(11, LifeStage.Child)]
        [InlineData(12, LifeStage.Teen)]
        [InlineData(13, LifeStage.Teen)]
        [InlineData(14, LifeStage.Teen)]
        [InlineData(15, LifeStage.Teen)]
        [InlineData(16, LifeStage.Teen)]
        [InlineData(17, LifeStage.Teen)]
        [InlineData(18, LifeStage.Adult)]
        public void LifeStageBasedOnAgeUnitTest(int age, LifeStage expectedLifeStage)
        {
            // Arrange
            var dragon = new Tamagotchi("Dragon");

            // Act
            dragon.Age = age;

            // Assert
            dragon.LifeStage.ShouldBe(expectedLifeStage);
        }
    }
}
