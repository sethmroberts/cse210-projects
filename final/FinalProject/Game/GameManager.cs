using System;
using RPG.Characters;

namespace RPG.Game
{
    public class GameManager
    {
        private Player player;
        private Character enemy;
        private Random rng = new Random();

        public GameManager()
        {
            player = new Player("Hero");
        }

        public void Run()
        {
            Console.WriteLine("Game starting...");
            enemy = GenerateRandomEnemy();
            Console.WriteLine($"A wild {enemy.GetType().Name} appears!");
            Console.WriteLine();

            HandleTurn();

            Console.WriteLine();
            Console.WriteLine("Battle over.");
            player.DisplayStats();
            enemy.DisplayStats();
        }

        public void HandleTurn()
        {
            Console.WriteLine("Your turn!");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Do nothing");
            Console.Write("Choose an action: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                int playerDamage = player.Attack();
                enemy.TakeDamage(playerDamage);
                Console.WriteLine($"You dealt {playerDamage} damage to the {enemy.GetType().Name}.");
            }
            else
            {
                Console.WriteLine("You hesitate...");
            }

            if (!enemy.IsAlive())
            {
                Console.WriteLine($"The {enemy.GetType().Name} has been defeated!");
                return;
            }

            Console.WriteLine($"{enemy.GetType().Name}'s turn!");
            int enemyDamage = enemy.Attack();
            player.TakeDamage(enemyDamage);
            Console.WriteLine($"You took {enemyDamage} damage!");
        }


        public Character GenerateRandomEnemy()
        {
            int roll = rng.Next(4);
            switch (roll)
            {
                case 0: return new Goblin();
                case 1: return new Dragon();
                case 2: return new Rock();
                case 3: return new Troll();
                default: return new Goblin();
            }
        }

        public RPG.Items.Item GenerateRandomItem()
        {
            return null;
        }
    }
}
