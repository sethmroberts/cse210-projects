using System;
using RPG.Characters;

namespace RPG.Game
{
    public class BattleManager
    {
        private Player _player;
        private Character _enemy;
        private int _totalDamageDealt;

        public BattleManager(Player player, Character enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public int StartBattle()
        {
            while (_enemy.IsAlive() && _player.IsAlive())
            {
                HandleTurn();
            }

            return _totalDamageDealt;
        }

        private void HandleTurn()
        {
            bool turnTaken = false;

            while (!turnTaken && _player.IsAlive() && _enemy.IsAlive())
            {
                Console.Clear();
                Console.WriteLine($"Hero:  {_player.GetName()}    HP: {_player.GetHealth()}");
                Console.WriteLine($"Enemy: {_enemy.GetName()}    HP: {_enemy.GetHealth()}");
                Console.WriteLine();
                Console.WriteLine($"1. Attack (Damage: {_player.Attack()})");
                Console.WriteLine("2. Use Item");
                Console.WriteLine("3. View Stats");
                Console.Write("Choose an action: ");
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        int damage = _player.Attack();
                        _enemy.TakeDamage(damage);
                        _totalDamageDealt += damage;
                        Console.WriteLine($"You dealt {damage} damage to the {_enemy.GetName()}.");
                        turnTaken = true;
                        break;

                    case "2":
                        var inventory = _player.GetInventory();
                        if (inventory.Count == 0)
                        {
                            Console.WriteLine("You have no items.");
                            Console.WriteLine("Press Enter to return...");
                            Console.ReadLine();
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("Your inventory:");
                        for (int i = 0; i < inventory.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {inventory[i].GetName()}");
                        }

                        Console.Write("Select an item number to use or press Enter to go back: ");
                        string itemInput = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(itemInput)) break;

                        if (int.TryParse(itemInput, out int index) &&
                            index >= 1 && index <= inventory.Count)
                        {
                            var item = inventory[index - 1];
                            item.Use(_player);
                            inventory.RemoveAt(index - 1);
                            Console.WriteLine($"You used {item.GetName()}.");
                            turnTaken = true;
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid item selection. Press Enter to return...");
                            Console.ReadLine();
                        }
                        break;

                    case "3":
                        Console.Clear();
                        _player.DisplayStats();
                        Console.WriteLine("Press Enter to return...");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Invalid input. Press Enter to try again...");
                        Console.ReadLine();
                        break;
                }
            }

            if (!_enemy.IsAlive() || !_player.IsAlive()) return;

            Console.WriteLine($"{_enemy.GetName()}'s turn!");
            int enemyDamage = _enemy.Attack();
            _player.TakeDamage(enemyDamage);
            Console.WriteLine($"You took {enemyDamage} damage!");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
