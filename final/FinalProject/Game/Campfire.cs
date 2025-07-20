using System;
using RPG.Characters;
using RPG.Items;
using System.Collections.Generic;

namespace RPG.Game
{
    public class Campfire
    {
        private Player _player;

        public Campfire(Player player)
        {
            _player = player;
        }

        public void Enter()
        {
            _player.Heal(100 - _player.GetHealth());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("You've reached a campfire!");
                Console.WriteLine("You feel refreshed as your wounds heal.");
                Console.WriteLine();
                Console.WriteLine("1. View & Equip Items");
                Console.WriteLine("2. Use Healing or Armor");
                Console.WriteLine("3. View Stats");
                Console.WriteLine("4. Continue Onward");
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        var weapons = _player.GetInventory().FindAll(i => i is Weapon);
                        if (weapons.Count == 0)
                        {
                            Console.WriteLine("You have no weapons.");
                            Console.WriteLine("Press Enter to return...");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("Weapons:");
                        for (int i = 0; i < weapons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {weapons[i].GetName()}");
                        }

                        Console.Write("Choose a weapon to equip or press Enter to go back: ");
                        string wChoice = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(wChoice)) break;

                        if (int.TryParse(wChoice, out int wIndex) &&
                            wIndex >= 1 && wIndex <= weapons.Count)
                        {
                            var weapon = weapons[wIndex - 1] as Weapon;
                            weapon.Use(_player);
                            _player.GetInventory().Remove(weapon);
                            Console.WriteLine($"You equipped the {weapon.GetName()}.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                        }

                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        var usable = _player.GetInventory().FindAll(i => i is not Weapon);
                        if (usable.Count == 0)
                        {
                            Console.WriteLine("You have no usable items.");
                            Console.WriteLine("Press Enter to return...");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("Items:");
                        for (int i = 0; i < usable.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {usable[i].GetName()}");
                        }

                        Console.Write("Choose an item to use or press Enter to go back: ");
                        string iChoice = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(iChoice)) break;

                        if (int.TryParse(iChoice, out int iIndex) &&
                            iIndex >= 1 && iIndex <= usable.Count)
                        {
                            var item = usable[iIndex - 1];
                            item.Use(_player);
                            _player.GetInventory().Remove(item);
                            Console.WriteLine($"You used {item.GetName()}.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                        }

                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        _player.DisplayStats();
                        Console.WriteLine("Press Enter to return...");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("You stoke the fire one last time and move on.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        return;

                    default:
                        Console.WriteLine("Invalid input.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
