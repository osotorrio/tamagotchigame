using Shouldly;
using Xbehave;

namespace TamagotchiGame.Tests
{
    public class DefaultStateScenarios
    {
        [Scenario]
        public void DragonStartsOffAsNeutralMetricsAsBaby(AbstractTamagotchi dragon)
        {
            "Given a dragon".x(() =>
            {
                dragon = new Tamagotchi("Dragon");
            });

            "When the dragon starts its life".x(() => {});

            "Then the dragon is a baby".x(() =>
            {
                dragon.LifeStage.ShouldBe(LifeStage.Baby);
            });

            "And dragon weight is 7 beautiful kilograms".x(() =>
            {
                dragon.Weight.ShouldBe(7);
            });

            "And dragon happiness is neutral".x(() =>
            {
                dragon.Happiness.ShouldBe(0);
            });

            "And dragon hungriness is neutral".x(() =>
            {
                dragon.Hungriness.ShouldBe(0);
            });
        }
    }
}
