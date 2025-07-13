namespace RPG.Items
{
    public abstract class Item
    {
        protected string name;
        protected int value;

        public Item(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        public string GetName()
        {
            return name;
        }

        public abstract void Use(RPG.Characters.Character target);
    }
}
