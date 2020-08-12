using System.Collections.Generic;
using System.Linq;

namespace TamagotchiGame
{
    public enum LifeStage
    {
        Baby = 0,
        Child = 1,
        Teen = 12,
        Adult = 18
    }

    public class Tamagotchi : IAmTamagotchi
    {
        private int _age;

        private readonly List<IPetNeed> _needs = new List<IPetNeed>();

        public Tamagotchi(string name)
        {
            Name = name;
            Weight = 7;
        }

        public string Name { get; set; }

        public int Age 
        {
            get { return _age; }
            set 
            {
                _age = value;

                // this is bananas
                if (value >= (int)LifeStage.Baby && value < (int)LifeStage.Child)
                {
                    LifeStage = LifeStage.Baby;
                }

                if (value > (int)LifeStage.Child && value < (int)LifeStage.Teen)
                {
                    LifeStage = LifeStage.Child;
                }

                if (value > (int)LifeStage.Teen && value < (int)LifeStage.Adult)
                {
                    LifeStage = LifeStage.Teen;
                }

                if (value > (int)LifeStage.Adult)
                {
                    LifeStage = LifeStage.Adult;
                }
            }
        }

        public int Weight { get; set; }

        public int Happiness { get; set; }

        public int Hungriness { get; set; }

        public LifeStage LifeStage { get; set; }

        public void AddNeed(IPetNeed need)
        {
            _needs.Add(need);
        }

        public void RemoveNeed(IPetNeed need)
        {
            _needs.Remove(need);
        }

        public void TimePassed()
        {
            Age++;
            _needs.ForEach(need => need.Dissatisfy(this));
        }

        public void Pet()
        {
            _needs.Single(need => need is PettingNeed).Satisfy(this);
        }

        public void Feed()
        {
            _needs.Single(need => need is FoodNeed).Satisfy(this);
        }
    }
}
