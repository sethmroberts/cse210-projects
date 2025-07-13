using System;
using RPG.Items;

namespace RPG.Characters
{
    public class Player : Character
    {
        public Player(string name) : base(name, 100, 10)
        {
        }

        public override int Attack()
        {
            return baseDamage;
        }

        public override string MakeSound()
        {
            return "Let's do this!";
        }
    }
}
