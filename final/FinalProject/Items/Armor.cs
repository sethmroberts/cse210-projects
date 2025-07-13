namespace RPG.Items
{
    public class Armor : Item
    {
        private int defense;

        public Armor(string name, int value, int defense) : base(name, value)
        {
            this.defense = defense;
        }

        public override void Use(RPG.Characters.Character target)
        {
        }
    }
}
