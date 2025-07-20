using System;
using System.Collections.Generic;
using RPG.Items;

namespace RPG.Characters
{
    public class Player : Character
    {
        private Weapon _equippedWeapon;

        public Player(string name) : base(name, 100, 10)
        {
        }

        public override int Attack()
        {
            int totalDamage = baseDamage;
            if (_equippedWeapon != null)
            {
                totalDamage += _equippedWeapon.GetDamageBoost();
            }
            return totalDamage;
        }

        public override string MakeSound()
        {
            return "Let's do this!";
        }

        public List<Item> GetInventory()
        {
            return inventory;
        }

        public void EquipWeapon(Weapon weapon)
        {
            _equippedWeapon = weapon;
        }
    }
}
