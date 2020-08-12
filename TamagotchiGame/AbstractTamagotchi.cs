using System.Collections.Generic;

namespace TamagotchiGame
{
    public interface ICanGetOlder
    {
        void TimePassed();
    }

    public interface ICanBePetted
    {
        void Pet();
    }

    public interface ICanBeFeed
    {
        void Feed();
    }

    public abstract class AbstractTamagotchi
    {
        public AbstractTamagotchi(string name)
        {
            Name = name;
            Weight = 7;
        }

        protected List<IHaveNeeds> Needs = new List<IHaveNeeds>();

        public string Name { get; set; }

        public abstract int Age { get; set; }

        public LifeStage LifeStage { get; set; }

        public int Happiness { get; set; }

        public int Hungriness { get; set; }

        public int Weight { get; set; }

        public void AddNeed(IHaveNeeds need)
        {
            Needs.Add(need);
        }

        public void RemoveNeed(IHaveNeeds need)
        {
            Needs.Remove(need);
        }
    }
}
