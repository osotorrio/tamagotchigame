namespace TamagotchiGame
{
    public interface IAmTamagotchi
    {
        string Name { get; set; }

        int Age { get; set; }

        int Weight { get; set; }

        int Happiness { get; set; }

        int Hungriness { get; set; }

        LifeStage LifeStage { get; set; }

        void AddNeed(IPetNeed need);

        void RemoveNeed(IPetNeed need);

        void TimePassed();

        void Pet();

        void Feed();
    }
}
