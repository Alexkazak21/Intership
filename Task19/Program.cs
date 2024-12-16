using Task19.Classes;

namespace Task19;

internal class Program
{
    static void Main(string[] args)
    {
        Animal[] herd = new Animal[7];
        herd[0] = new Horse("Tracy", 4, false);
        herd[1] = new Horse("Alen", 4, false);
        herd[2] = new Kangaroo("Tom", 2, false);
        herd[3] = new Kangaroo("Alice", 2, false);
        herd[4] = new Dragonfly("Mik", 6, true);
        herd[5] = new Dragonfly("Nike", 6, true);
        herd[6] = new Animal("Unknown Type", 10, true);


        Horse horse = new Horse("Horse 3", 4, false);
        Kangaroo kangaroo = new Kangaroo("Kangaroo 3", 4, true);
        Dragonfly dragonfly = new Dragonfly("Dragonfly 3", 6, true);

        foreach (var animal in herd)
        {
            animal.Voice();
        }

        horse.Voice();
        kangaroo.Voice();
        dragonfly.Voice();

        foreach (var animal in herd)
        {
            animal.Move();
        }

        horse.Move();
        kangaroo.Move();
        dragonfly.Move();

        foreach (var animal in herd)
        {
            animal.IsHungry();
        }

        horse.IsHungry();
        kangaroo.IsHungry();
        dragonfly.IsHungry();
    }
}