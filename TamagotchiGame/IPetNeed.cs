using System;
using System.Collections.Generic;
using System.Text;

namespace TamagotchiGame
{
    public interface IPetNeed
    {
        void Satisfy(IAmTamagotchi tamagotchi);

        void Dissatisfy(IAmTamagotchi tamagotchi);
    }

    public class FoodNeed : IPetNeed
    {
        public void Dissatisfy(IAmTamagotchi tamagotchi)
        {
            tamagotchi.Hungriness++;
        }

        public void Satisfy(IAmTamagotchi tamagotchi)
        {
            tamagotchi.Hungriness--;
        }
    }

    public class PettingNeed : IPetNeed
    {
        public void Dissatisfy(IAmTamagotchi tamagotchi)
        {
            tamagotchi.Happiness--;
        }

        public void Satisfy(IAmTamagotchi tamagotchi)
        {
            tamagotchi.Happiness++;
        }
    }
}
