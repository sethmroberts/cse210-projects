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

        public Character(string name, int health, int baseDamage)
        {
            this.name = name;
            this.health = health;
            this.baseDamage = baseDamage;
            this.inventory = new List<Items.Item>();
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            if (health < 0) health = 0;
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
            return "Generic grunt.";
        }

        public void Equip(Items.Item item)
        {
            inventory.Add(item);
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Inventory: {inventory.Count} item(s)");
        }
    }
}
