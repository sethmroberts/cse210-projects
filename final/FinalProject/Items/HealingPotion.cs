namespace RPG.Items
{
    public class HealingPotion : Item
    {
        private int healAmount;

        public HealingPotion(string name, int value, int healAmount) : base(name, value)
        {
            this.healAmount = healAmount;
        }

        public override void Use(RPG.Characters.Character target)
        {
        }
    }
}
