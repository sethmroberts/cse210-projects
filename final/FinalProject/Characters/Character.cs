using System;
using System.Collections.Generic;

namespace RPG.Characters
{
    public abstract class Character
    {
        protected string name;
        protected int health;
        protected int baseDamage;
        protected List<Items.Item> inventory;
        private int _pendingArmorReduction = 0;


        public Character(string name, int health, int baseDamage)
        {
            this.name = name;
            this.health = health;
            this.baseDamage = baseDamage;
            this.inventory = new List<Items.Item>();
        }

        public string GetName()
        {
            return name;
        }

        public int GetHealth()
        {
            return health;
        }

        public void TakeDamage(int amount)
        {
            if (_pendingArmorReduction > 0)
            {
                Console.WriteLine($"{name}'s armor absorbs {_pendingArmorReduction} damage.");
                amount -= _pendingArmorReduction;
                if (amount < 0) amount = 0;
                _pendingArmorReduction = 0;
            }

            health -= amount;
            if (health < 0) health = 0;
        }

        public void Heal(int amount)
        {
            health += amount;
            Console.WriteLine($"{name} heals for {amount} health.");
        }

        public void ApplyArmor(int amount)
        {
            _pendingArmorReduction = amount;
            Console.WriteLine($"{name} braces with armor, ready to absorb {amount} damage.");
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public virtual int Attack()
        {
            return baseDamage;
        }

        public virtual string MakeSound()
        {
            return "Grunt.";
        }

        public void Equip(Items.Item item)
        {
            inventory.Add(item);
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine("Inventory:");
            if (inventory.Count == 0)
            {
                Console.WriteLine("  (empty)");
            }
            else
            {
                foreach (var item in inventory)
                {
                    Console.WriteLine($"  - {item.GetName()}");
                }
            }
        }
    }
}
