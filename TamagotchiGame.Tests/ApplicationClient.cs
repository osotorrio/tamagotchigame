using Shouldly;
using Xunit;

namespace TamagotchiGame.Tests
{
    public class ApplicationClient
    {
        [Fact]
        public void ExampleOfUse()
        {
            // Dragon is born and it is a baby
            var dragon = new Tamagotchi("Needy dragon");

            var needForFood = new FoodNeeds();
            var needForPetting = new PettingNeeds();

            dragon.AddNeed(needForFood);
            dragon.AddNeed(needForPetting);

            // TimePassed could be called each hour (or something like that) to age the pet
            dragon.TimePassed(); 
            dragon.TimePassed();
            dragon.TimePassed();

            // At this point it is 3 years old, very unhappy and hungry
            dragon.Age.ShouldBe(3);
            dragon.Happiness.ShouldBe(-45);
            dragon.Hungriness.ShouldBe(24);

            // Let's feed it first
            dragon.Feed();
            dragon.Feed();
            dragon.Hungriness.ShouldBe(8); // It is less hungy now

            // Let's give it some attention
            dragon.Pet();
            dragon.Pet();
            dragon.Happiness.ShouldBe(-15); // It is less unhappy now

            // At this point we could add a new need. For example the need for a diet (Implemented below)
            dragon.AddNeed(new DietNeeds());

            dragon.Weight.ShouldBe(7);

            // 50 years passed
            for (int i = 0; i < 50; i++)
            {
                dragon.TimePassed();
            }

            dragon.Age.ShouldBe(53);
            dragon.Weight.ShouldBe(107);
        }
    }

    public class DietNeeds : IHaveNeeds
    {
        public void Dissatisfy(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.Weight += 2;
        }

        public void Satisfy(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.Weight -= 2;
        }
    }
}
