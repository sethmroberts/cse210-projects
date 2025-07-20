using System;
using RPG.Items;

namespace RPG.Game
{
    public static class RewardManager
    {
        private static Random rng = new Random();

        public static Item GetRandomItem()
        {
            int roll = rng.Next(5);
            return roll switch
            {
                0 => new Sword(),
                1 => new Club(),
                2 => new Bow(),
                3 => new HealingPotion("Healing Potion", 25, 20),
                4 => new Armor("Leather Armor", 30, 5),
                _ => new Club()
            };
        }

        public static Item ChooseReward()
        {
            var item1 = GetRandomItem();
            var item2 = GetRandomItem();

            Console.WriteLine("Choose a reward:");
            Console.WriteLine($"1. {item1.GetName()}");
            Console.WriteLine($"2. {item2.GetName()}");
            Console.Write("Pick 1 or 2: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            return input == "2" ? item2 : item1;
        }
    }
}
