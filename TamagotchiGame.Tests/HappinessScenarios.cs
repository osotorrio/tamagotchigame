using Shouldly;
using Xbehave;

namespace TamagotchiGame.Tests
{
    public class HappinessScenarios
    {
        [Scenario]
        public void PettingYourDragonMakesThemHappy(Tamagotchi dragon, int happinessBefore, int happinessAfter)
        {
            "Given a dragon with petting needs".x(() =>
            {
                dragon = new Tamagotchi("Dragon");
                dragon.AddNeed(new PettingNeeds());
                happinessBefore = dragon.Happiness;
            });

            "When you pet it".x(() =>
            {
                dragon.Pet();
                happinessAfter = dragon.Happiness;
            });

            "Then the dragon is more happy".x(() =>
            {
                happinessAfter.ShouldBeGreaterThan(happinessBefore);
            });
        }

        [Scenario]
        public void DragonsHappinessDecreasesOverTime(Tamagotchi dragon, int happinessBefore, int happinessAfter)
        {
            "Given a dragon with petting needs".x(() =>
            {
                dragon = new Tamagotchi("Dragon");
                dragon.AddNeed(new PettingNeeds());
                happinessBefore = dragon.Happiness;
            });

            "When time passes without attention".x(() =>
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
