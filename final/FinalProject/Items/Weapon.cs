namespace RPG.Items
{
    public class Weapon : Item
    {
        private int damageBoost;

        public Weapon(string name, int value, int damageBoost) : base(name, value)
        {
            this.damageBoost = damageBoost;
        }

        public override void Use(RPG.Characters.Character target)
        {
        }
    }
}
