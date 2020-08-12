using Shouldly;
using System;
using Xbehave;
using Xunit;

namespace TamagotchiGame.Tests
{
    public class Scenarios
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
        public void DragonStartsOffAsNeutralMetricsAsBaby(IAmTamagotchi dragon)
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

            "And dragon happiness is neutral".x(() =>
            {
                dragon.Happiness.ShouldBe(0);
            });

            "And dragon hungriness is neutral".x(() =>
            {
                dragon.Hungriness.ShouldBe(0);
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
