using System.Collections.Generic;

namespace TamagotchiGame
{
    public interface IHaveNeeds
    {
        void Satisfy(AbstractTamagotchi tamagotchi);

        void Dissatisfy(AbstractTamagotchi tamagotchi);
    }

    public class FoodNeeds : IHaveNeeds
    {
        private Dictionary<LifeStage, int> _rates => new Dictionary<LifeStage, int> 
        {
            { LifeStage.Baby, 10 }, { LifeStage.Child, 8 }, { LifeStage.Teen, 5 }, { LifeStage.Adult, 3 }
        }; 

        public void Dissatisfy(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.Hungriness += _rates[tamagotchi.LifeStage];
        }

        public void Satisfy(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.Hungriness -= _rates[tamagotchi.LifeStage];
        }
    }

    public class PettingNeeds : IHaveNeeds
    {
        private Dictionary<LifeStage, int> _rates => new Dictionary<LifeStage, int>
        {
            { LifeStage.Baby, 20 }, { LifeStage.Child, 15 }, { LifeStage.Teen, 10 }, { LifeStage.Adult, 20 }
        };

        public void Dissatisfy(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.Happiness -= _rates[tamagotchi.LifeStage];
        }

        public void Satisfy(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.Happiness += _rates[tamagotchi.LifeStage];
        }
    }
}
