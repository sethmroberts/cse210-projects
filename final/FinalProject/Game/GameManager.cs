using System;
using RPG.Characters;
using RPG.Items;

namespace RPG.Game
{
    public class GameManager
    {
        private Player player = null;
        private Character enemy;
        private Random rng = new Random();
        private int enemiesDefeated = 0;
        private int totalDamageDealt = 0;

        public GameManager()
        {
            player = new Player("Hero");
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the RPG Adventure!");
            Console.Write("Enter your hero's name: ");
            string name = Console.ReadLine();
            player = new Player(name);

            Console.WriteLine();
            Console.WriteLine("You awaken at a quiet campfire with two items before you:");
            var starterWeapon = new Club();
            var starterPotion = new HealingPotion("Small Healing Potion", 10, 15);
            Console.WriteLine($"1. {starterWeapon.GetName()}");
            Console.WriteLine($"2. {starterPotion.GetName()}");

            Console.Write("Choose one to take with you (1 or 2): ");
            string starterChoice = Console.ReadLine();
            if (starterChoice == "2")
            {
                player.Equip(starterPotion);
            }
            else
            {
                player.Equip(starterWeapon);
            }

            Console.WriteLine("You tuck the item into your pack.");
            Console.WriteLine("Press Enter to enter the campfire and prepare...");
            Console.ReadLine();

            new Campfire(player).Enter();

            Console.Clear();
            Console.WriteLine("You head out on your adventure!");
            Console.WriteLine();

            while (player.IsAlive())
            {
                enemy = GenerateRandomEnemy();
                Console.Clear();
                Console.WriteLine($"A wild {enemy.GetName()} appears!");
                Console.WriteLine($"Health: {enemy.GetHealth()}");
                Console.WriteLine();
                Console.WriteLine("Press Enter to begin the fight...");
                Console.ReadLine();
                Console.Clear();

                while (enemy.IsAlive() && player.IsAlive())
                {
                    var battle = new BattleManager(player, enemy);
                    totalDamageDealt += battle.StartBattle();
                }

                if (!player.IsAlive()) break;

                enemiesDefeated++;
                Console.WriteLine($"You defeated the {enemy.GetType().Name}!");
                Console.WriteLine($"{enemy.GetType().Name}'s last words: \"{enemy.MakeSound()}\"");  // 👈 Add this line

                var reward = RewardManager.ChooseReward();
                player.Equip(reward);
                Console.WriteLine($"{reward.GetName()} added to your inventory.");
                Console.WriteLine();

                if (enemiesDefeated % 2 == 0)
                {
                    new Campfire(player).Enter();
                }
            }

            Console.WriteLine("You have fallen...");
            Console.WriteLine("Final Stats:");
            player.DisplayStats();
            Console.WriteLine($"Enemies defeated: {enemiesDefeated}");
            Console.WriteLine($"Total damage dealt: {totalDamageDealt}");
        }

        public Character GenerateRandomEnemy()
        {
            int tier = enemiesDefeated;

            if (tier < 2)
            {
                return rng.Next(2) == 0 ? new Goblin() : new Rock();
            }
            else if (tier < 4)
            {
                int roll = rng.Next(3);
                return roll switch
                {
                    0 => new Goblin(),
                    1 => new Rock(),
                    2 => new Troll(),
                    _ => new Goblin()
                };
            }
            else
            {
                int roll = rng.Next(4);
                return roll switch
                {
                    0 => new Goblin(),
                    1 => new Rock(),
                    2 => new Troll(),
                    3 => new Dragon(),
                    _ => new Goblin()
                };
            }
        }
    }
}
