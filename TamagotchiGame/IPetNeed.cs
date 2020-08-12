using System.Collections.Generic;

namespace TamagotchiGame
{
    public interface IPetNeed
    {
        void Satisfy(IAmTamagotchi tamagotchi);

        void Dissatisfy(IAmTamagotchi tamagotchi);
    }

    public class FoodNeed : IPetNeed
    {
        private Dictionary<LifeStage, int> _rates => new Dictionary<LifeStage, int> 
        {
            { LifeStage.Baby, 10 }, { LifeStage.Child, 8 }, { LifeStage.Teen, 5 }, { LifeStage.Adult, 3 }
        }; 

        public void Dissatisfy(IAmTamagotchi tamagotchi)
        {
            tamagotchi.Hungriness += _rates[tamagotchi.LifeStage];
        }

        public void Satisfy(IAmTamagotchi tamagotchi)
        {
            tamagotchi.Hungriness -= _rates[tamagotchi.LifeStage];
        }
    }

    public class PettingNeed : IPetNeed
    {
        private Dictionary<LifeStage, int> _rates => new Dictionary<LifeStage, int>
        {
            { LifeStage.Baby, 20 }, { LifeStage.Child, 15 }, { LifeStage.Teen, 10 }, { LifeStage.Adult, 20 }
        };

        public void Dissatisfy(IAmTamagotchi tamagotchi)
        {
            tamagotchi.Happiness -= _rates[tamagotchi.LifeStage];
        }

        public void Satisfy(IAmTamagotchi tamagotchi)
        {
            tamagotchi.Happiness += _rates[tamagotchi.LifeStage];
        }
    }
}
