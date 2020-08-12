using System.Collections.Generic;
using System.Linq;

namespace TamagotchiGame
{
    public class Tamagotchi : AbstractTamagotchi, ICanGetOlder, ICanBePetted, ICanBeFeed
    {
        private int _age;

        private readonly Dictionary<int, LifeStage> _lifeStageThresholds = new Dictionary<int, LifeStage>
        {
            { (int)LifeStage.Baby, LifeStage.Baby },
            { (int)LifeStage.Child, LifeStage.Child },
            { (int)LifeStage.Teen, LifeStage.Teen },
            { (int)LifeStage.Adult, LifeStage.Adult }
        };

        public Tamagotchi(string name) : base(name){}

        public override int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                SetLifeStage(value);
            }
        }

        public void TimePassed()
        {
            Age++;
            Needs.ForEach(need => need.Dissatisfy(this));
        }

        public void Pet()
        {
            Needs.Single(need => need is PettingNeeds).Satisfy(this);
        }

        public void Feed()
        {
            Needs.Single(need => need is FoodNeeds).Satisfy(this);
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
