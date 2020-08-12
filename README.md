# Implementation of Tamagotchi Game

For this implementation the Observer pattern has been used. Following is the description of the actors involved.

- Subject -> [AbstractTamagotchi](https://github.com/osotorrio/tamagotchigame/blob/master/TamagotchiGame/AbstractTamagotchi.cs)
- ConcreteSubject -> [Tamagotchi](https://github.com/osotorrio/tamagotchigame/blob/master/TamagotchiGame/Tamagotchi.cs)
- Observer -> [IHaveNeeds](https://github.com/osotorrio/tamagotchigame/blob/master/TamagotchiGame/IHaveNeeds.cs)
- ConcreteObserver -> [FoodNeeds, PettingNeeds](https://github.com/osotorrio/tamagotchigame/blob/master/TamagotchiGame/IHaveNeeds.cs)

# Change of state and notification to observers

This behaviour can be observer in the [TimePassed() method](https://github.com/osotorrio/tamagotchigame/blob/master/TamagotchiGame/Tamagotchi.cs#L30). When time passed, the tamagotchi age and all needs (observers) are notified. In this implementaion, observers has the faculty of change the state of the tamagotchi (concrete subject).

# Testing

Two types of unit tests have been used. Scenarios describing the behaviour of the tamagotchi. And when the functionality to be tested had too many outcomes, then AAA pattern unit test has been used. 

# Application Client

An example of this API library is described in the [application client test class](https://github.com/osotorrio/tamagotchigame/blob/master/TamagotchiGame.Tests/ApplicationClient.cs).



