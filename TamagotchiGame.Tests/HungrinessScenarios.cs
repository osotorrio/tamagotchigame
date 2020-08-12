using Shouldly;
using Xbehave;

namespace TamagotchiGame.Tests
{
    public class HungrinessScenarios
    {
        [Scenario]
        public void FeedingYourDragonMakesThemLessHungry(IAmTamagotchi dragon, int hungrinessBefore, int hungrinessAfter)
        {
            "Given a dragon with food needs".x(() =>
            {
                dragon = new Tamagotchi("Dragon");
                dragon.AddNeed(new FoodNeed());
                hungrinessBefore = dragon.Hungriness;
            });

            "When you feed it".x(() =>
            {
                dragon.Feed();
                hungrinessAfter = dragon.Hungriness;
            });

            "Then the dragon is happy".x(() =>
            {
                hungrinessAfter.ShouldBeLessThan(hungrinessBefore);
            });
        }

        [Scenario]
        public void DragonsHungerIncreasesOverTime(IAmTamagotchi dragon, int hungrinessBefore, int hungrinessAfter)
        {
            "Given a dragon with food needs".x(() =>
            {
                dragon = new Tamagotchi("Dragon");
                dragon.AddNeed(new FoodNeed());
                hungrinessBefore = dragon.Hungriness;
            });

            "When time passes".x(() =>
            {
                dragon.TimePassed();
                hungrinessAfter = dragon.Hungriness;
            });

            "Then the dragon is more hungry".x(() =>
            {
                hungrinessAfter.ShouldBeGreaterThan(hungrinessBefore);
            });
        }
    }
}
