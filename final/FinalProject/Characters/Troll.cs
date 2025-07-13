namespace RPG.Characters
{
    public class Troll : Character
    {
        public Troll() : base("Troll", 120, 15) { }

        public override int Attack() => baseDamage;

        public override string MakeSound() => "Grrr...";
    }
}
