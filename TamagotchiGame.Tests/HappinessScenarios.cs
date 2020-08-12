using Shouldly;
using Xbehave;

namespace TamagotchiGame.Tests
{
    public class HappinessScenarios
    {
        [Scenario]
        public void PettingYourDragonMakesThemHappy(IAmTamagotchi dragon, int happinessBefore, int happinessAfter)
        {
            "Given a dragon with petting needs".x(() =>
            {
                dragon = new Tamagotchi("Dragon");
                dragon.AddNeed(new PettingNeed());
                happinessBefore = dragon.Happiness;
            });

            "When you pet it".x(() =>
            {
                dragon.Pet();
                happinessAfter = dragon.Happiness;
            });

            "Then the dragon is happy".x(() =>
            {
                happinessAfter.ShouldBeGreaterThan(happinessBefore);
            });
        }

        [Scenario]
        public void DragonsHappinessDecreasesOverTime(IAmTamagotchi dragon, int happinessBefore, int happinessAfter)
        {
            "Given a dragon with petting needs".x(() =>
            {
                dragon = new Tamagotchi("Dragon");
                dragon.AddNeed(new PettingNeed());
                happinessBefore = dragon.Happiness;
            });

            "When time passes".x(() =>
            {
                dragon.TimePassed();
                happinessAfter = dragon.Happiness;
            });

            "Then the dragon is less happy".x(() =>
            {
                happinessAfter.ShouldBeLessThan(happinessBefore);
            });
        }
    }
}
