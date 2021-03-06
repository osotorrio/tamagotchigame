﻿using Shouldly;
using Xbehave;

namespace TamagotchiGame.Tests
{
    public class HungrinessScenarios
    {
        [Scenario]
        public void FeedingYourDragonMakesThemLessHungry(Tamagotchi dragon, int hungrinessBefore, int hungrinessAfter)
        {
            "Given a dragon with food needs".x(() =>
            {
                dragon = new Tamagotchi("Dragon");
                dragon.AddNeed(new FoodNeeds());
                hungrinessBefore = dragon.Hungriness;
            });

            "When you feed it".x(() =>
            {
                dragon.Feed();
                hungrinessAfter = dragon.Hungriness;
            });

            "Then the dragon is less hungry".x(() =>
            {
                hungrinessAfter.ShouldBeLessThan(hungrinessBefore);
            });
        }

        [Scenario]
        public void DragonsHungerIncreasesOverTime(Tamagotchi dragon, int hungrinessBefore, int hungrinessAfter)
        {
            "Given a dragon with food needs".x(() =>
            {
                dragon = new Tamagotchi("Dragon");
                dragon.AddNeed(new FoodNeeds());
                hungrinessBefore = dragon.Hungriness;
            });

            "When time passes without food".x(() =>
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
