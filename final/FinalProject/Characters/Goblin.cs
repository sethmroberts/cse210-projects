namespace RPG.Characters
{
    public class Goblin : Character
    {
        public Goblin() : base("Goblin", 30, 5) { }

        public override int Attack() => baseDamage;

        public override string MakeSound() => "Screech!";
    }
}
