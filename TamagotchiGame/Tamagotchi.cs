using System.Collections.Generic;
using System.Linq;

namespace TamagotchiGame
{
    public class Tamagotchi : IAmTamagotchi
    {
        private int _age;

        private readonly List<IPetNeed> _needs = new List<IPetNeed>();

        private readonly Dictionary<int, LifeStage> _lifeStageThresholds = new Dictionary<int, LifeStage>
        {
            { (int)LifeStage.Baby, LifeStage.Baby }, 
            { (int)LifeStage.Child, LifeStage.Child }, 
            { (int)LifeStage.Teen, LifeStage.Teen }, 
            { (int)LifeStage.Adult, LifeStage.Adult }
        };

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
                SetLifeStage(value);
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

        private void SetLifeStage(int value)
        {
            foreach (var thresholds in _lifeStageThresholds)
            {
                if (value >= thresholds.Key)
                {
                    LifeStage = thresholds.Value;
                }
            }
        }
    }
}
